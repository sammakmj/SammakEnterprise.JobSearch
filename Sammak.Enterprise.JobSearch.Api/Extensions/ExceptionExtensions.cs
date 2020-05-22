using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SammakEnterprise.JobSearch.Api.Extensions
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a string containing both the message AND stack trace of an exception, for preservation purposes. Also includes InnerExceptions, LoaderExceptions,
        /// etc. Note that depending what's in the exception, Dump() may not work and SafeDump() may miss some necessary data. This provides a safe alternative with
        /// complete and readable output
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static string Stringify(this Exception ex, bool includeStackTrace = true)
        {
            if (ex == null) return "(this Exception is null)";
            if (ex.Message == null) return "(this Exception has a null Message)";
            try
            {
                //Message
                var str = string.Format("Message: '{0}'", ex.Message);

                //LoaderExceptions
                if (ex is ReflectionTypeLoadException)
                {
                    var loaderExceptions = ((ReflectionTypeLoadException)ex).LoaderExceptions;
                    if (loaderExceptions == null || !loaderExceptions.Any()) str += "; LoaderExceptions: []";
                    else str += string.Format("; LoaderExceptions: [{0}]", string.Join(", ", loaderExceptions.Select(l => l.Stringify()).ToArray()));
                }

                //EntityValidationErrors
                else if (ex.GetType().Name.Contains("DbEntityValidationException"))
                {
                    try
                    {
                        dynamic d = ex as dynamic;
                        if (d.EntityValidationErrors != null)
                        {
                            string validationText = "";
                            foreach (var e in d.EntityValidationErrors)
                            {
                                if (validationText != "") validationText += ", ";
                                string innerValidationText = "";
                                foreach (var v in e.ValidationErrors)
                                {
                                    if (innerValidationText != "") innerValidationText += ", ";
                                    innerValidationText += JsonExtensions.SafeDump(v);
                                }
                                validationText += innerValidationText;
                            }
                            str += string.Format("; EntityValidationErrors: [{0}]", validationText);
                        }
                        else
                            str += string.Format("; EntityValidationErrors: []");
                    }
                    catch (Exception ex3)
                    {
                        str += string.Format("; EntityValidationErrors: (unknown; failed to serialize)");
                    }
                }

                //InnerException
                str += string.Format("; InnerException: '{0}'", ex.InnerException == null ? "null" : ex.InnerException.Stringify());

                //Stack Trace
                if (includeStackTrace)
                    str += string.Format("; Stack Trace: '{0}'", ex.StackTrace ?? "(null)");

                return str;
            }
            catch (Exception ex1)
            {
                try
                {
                    var backupText = ex.SafeDump();
                    return backupText;
                }
                catch (Exception ex2)
                {
                    return (ex.Message ?? "(No exception text)") + " (failed to obtain more verbose logging for this exception)";
                }
            }
        }

        /// <summary>
        /// Logs using multiple streams, for debug purposes only, when logging doesn't seem to be working using the normal routes. Remove calls to this
        /// method afterward.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="log">The log.</param>
        public static void ForceLog(this Exception ex, ILogger log, bool throwNewException)
        {
            if (ex == null) throw new Exception("(this Exception is null)");
            if (ex.Message == null) throw new Exception("(this Exception has a null Message)");
            string text = ex.Stringify();

            try
            {
                if (log != null) 
                    log.Error(ex);
            }
            catch (Exception ex1)
            {
            }

            try
            {
                var filename = "ForcedLog_" + Guid.NewGuid() + ".txt";
                File.WriteAllText(filename, text);
            }
            catch (Exception ex2)
            {
            }

            if (throwNewException) throw new Exception(text, ex);
        }
    }
}
