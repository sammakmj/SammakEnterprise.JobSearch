using Swashbuckle.Application;
using System;
using System.Linq;
using System.Web.Http;
//using SammakEnterprise.Core.Swagger;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        public static void ConfigureSwagger(HttpConfiguration config)
        {
            var enableSwagger = ConfigurationManager.AppSettings["EnableSwagger"];
            if (enableSwagger == null || enableSwagger.ToLower() != "true")
                return;

            //config.EnableSwagger("docs/{apiVersion}/swagger", c =>
            //{
            //    c.SingleApiVersion(Resources.Constants.AppInfo.Version, Resources.Constants.AppInfo.ProductName);
            //})
            //    .EnableSwaggerUi();

            //config.EnableSwagger(c =>
            //{
            //    c.SingleApiVersion("v1", "Name.API");
            //})
            //    .EnableSwaggerUi(c =>
            //    {
            //    });

            config.EnableSwagger(/*"docs/{apiVersion}/swagger", */c =>
            {
                c.SingleApiVersion(/*Resources.Constants.AppInfo.Version*/"v1", Resources.Constants.AppInfo.ProductName);
                c.IncludeXmlComments(GetXmlCommentPath());
                c.DescribeAllEnumsAsStrings();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());
                //var authorityUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["Authority"]);
                //c.OAuth2("oauth")
                //    .AuthorizationUrl(authorityUri.ToString())
                //    .TokenUrl(new Uri(authorityUri, "connect/token").ToString())
                //    .Flow("resource_manager");

            })
            //.EnableSwaggerUi();
            .EnableSwaggerUi(x => x.DisableValidator());
            ////.EnableSwaggerUi(x => x.AddResourceOwnerFlowSupport());
        }

        private static string GetXmlCommentPath()
        {
            //Logger.Debug($"BaseDirectory:  {AppDomain.CurrentDomain.BaseDirectory}");
            return AppDomain.CurrentDomain.BaseDirectory + @"SammakEnterprise.JobSearch.Api.xml";
        }
    }

}
