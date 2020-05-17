using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SammakEnterprise.JobSearch.Api.Extensions
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The error text
        /// </summary>
        public const string ErrorText = "[Serialization Error]";

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Determines whether this instance is serializable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is serializable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSerializable<T>(this T instance)
        {
            try
            {
                string testForCycles = JsonConvert.SerializeObject(instance);
                return true;
            }
            catch (Exception ex)
            {
                //often means the object is cyclic
                return false;
            }
        }

        /// <summary>
        /// Does a safe serialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static string SafeSerialize<T>(this T instance)
        {
            try
            {
                return JsonConvert.SerializeObject(instance);
            }
            catch (Exception ex)
            {
                return FlatJson(instance);
            }
        }

        /// <summary>
        /// Does a safe dump.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static string SafeDump<T>(this T instance)
        {
            try
            {
                if (instance.IsSerializable())
                    return ServiceStack.Text.TypeSerializer.Dump(instance);
                else
                    return FlatJson(instance);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error in SafeDump of {0}: {1}", typeof(T).Name, ex.Stringify()));
                //since this is a SAFE dump call, we never throw an exception
                return string.Format("(the {0} could not be serialized)", typeof(T).Name);
            }
        }

        /// <summary>
        /// Stringifies the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private static string StringifyObject(Object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch (Exception ex)
            {
                return ErrorText;
            }
        }

        /// <summary>
        /// Provides a flat json representation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="skipFailedProperties">if set to <c>true</c> [skip failed properties].</param>
        /// <returns></returns>
        public static string FlatJson<T>(this T instance, bool skipFailedProperties = true)
        {
            try
            {
                var members = new Dictionary<string, string>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    try
                    {
                        members[prop.Name] = StringifyObject(prop.GetValue(instance));
                    }
                    catch (Exception ex3)
                    {
                        if (!skipFailedProperties) throw;
                    }
                }
                foreach (var field in typeof(T).GetFields())
                {
                    try
                    {
                        members[field.Name] = StringifyObject(field.GetValue(instance));
                    }
                    catch (Exception ex4)
                    {
                        if (!skipFailedProperties) throw;
                    }
                }
                string json = null;
                try
                {
                    json = string.Format("{{{0}}}", string.Join(", ", members.Select(kvp => string.Format("\"{0}\": \"{1}\"", kvp.Key, kvp.Value)).ToArray()));
                }
                catch (Exception ex1)
                {
                    return ErrorText;
                }
                return json;
            }
            catch (Exception ex2)
            {
                return ErrorText;
            }
        }
    }
}
