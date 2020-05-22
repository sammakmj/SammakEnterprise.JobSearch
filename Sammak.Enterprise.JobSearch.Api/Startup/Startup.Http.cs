using Microsoft.Owin.Extensions;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using SammakEnterprise.Core.Common.Api.Configuration.Activators;
using SammakEnterprise.Core.Common.Exceptions;
using SammakEnterprise.Core.Common.Infrastructure.Ioc;
using SammakEnterprise.Core.Common.Infrastructure.Logging.NLog;
using SammakEnterprise.JobSearch.Api.Util;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using WebApiThrottle;
using ITraceWriter = System.Web.Http.Tracing.ITraceWriter;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        /// <summary>
        /// UseWebApi method.
        /// </summary>
        /// <returns></returns>
        public static void UseHttpConfig(IAppBuilder app)
        {
            if (new Feature_RestApi().FeatureEnabled)
            {
                Logger.Info("FEATURE :: WEB API --> ENABLED");
                Logger.Trace("UseWebApi Begin");

                var config = CreateHttpConfiguration();

                ConfigureSwagger(config);

                app.UseStageMarker(PipelineStage.MapHandler);
                app.UseWebApi(config);
            }
            else
            {
                Logger.Warn("FEATURE :: WEB API --> DISABLED");
            }

            Logger.Trace("UseWebApi Complete");
        }

        private static HttpConfiguration CreateHttpConfiguration()
        {
            Logger.Trace("UseHttpConfig: Begin HTTP Configuration.");

            var config = new HttpConfiguration();

            config.EnableCors(new EnableCorsAttribute(origins: "*", headers: "*", methods: "* "));
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ResourceNotFound",
                routeTemplate: Resources.Constants.AppInfo.RoutePrefix + "/{*uri}",
                defaults: new { controller = "AppInfo", action = "ResourceNotFound", uri = RouteParameter.Optional }
            );

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            GlobalExceptionHandler.AppName = Resources.Constants.AppInfo.DisplayName;
            GlobalExceptionHandler.AppVersion = Resources.Constants.AppInfo.Version;

            config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            config.Services.Replace(typeof(ITraceWriter), new NLogTraceWriter());
            config.Services.Replace(typeof(IHttpControllerActivator), new SmServiceActivator(DependencyResolver.Container));

            //config.MessageHandlers.Add(new RequireHttpsHandler());
            //config.MessageHandlers.Add(new PreflightRequestsHandler());

            //*** Register throttling handler *******************************************
            // ++++ for more information: https://github.com/stefanprodan/WebApiThrottle
            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                Policy = ThrottlePolicy.FromStore(new PolicyConfigurationProvider()), // throttle policy defined as xml in App.config (throttlePolicy)
                //PolicyRepository = new PolicyMemoryCacheRepository(), // can be accessed in code like (new PolicyCacheRepository()).FirstOrDefault(ThrottleManager.GetPolicyKey())
                Repository = new MemoryCacheRepository() // uses the runtime memory cache for self-hosting WebApi with Owin. can use also Velocity, Redis or a NoSQL database
            });

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.AddQueryStringMapping("format", "json", "application/json");
            config.Formatters.JsonFormatter.AddRequestHeaderMapping("ReturnType", "json", StringComparison.InvariantCultureIgnoreCase, false, "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "application/xml");
            config.Formatters.XmlFormatter.AddQueryStringMapping("format", "xml", "application/xml");
            config.Formatters.XmlFormatter.AddRequestHeaderMapping("ReturnType", "xml", StringComparison.InvariantCultureIgnoreCase, false, "application/xml");

            DefaultContentNegotiator negotiator = new DefaultContentNegotiator(excludeMatchOnTypeOnly: true);
            config.Services.Replace(typeof(IContentNegotiator), negotiator);

            config.EnsureInitialized();

            Logger.Trace("UseHttpConfig: End HTTP Configuration.");
            return config;
        }

    }

}
