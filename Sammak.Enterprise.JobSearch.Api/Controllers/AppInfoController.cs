using SammakEnterprise.Core.Common.Api.Constants;
using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.Core.Common.Api.Response;
using SammakEnterprise.Core.Common.Api.Response.AppInfo;
using System.Configuration.Abstractions;
using System.Diagnostics;
using System.Reflection;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppInfoController : ControllerBase
    {
        #region Properties

        //private readonly IBusControl _busControl;
        private readonly IConfigurationManager _configurationManager;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AppInfoController"/> class.
        /// </summary>
        /// <param name="enumService">The enum service.</param>
        /// <param name="busControl">The bus control.</param>
        /// <param name="configurationManager">The configuration manager.</param>
        public AppInfoController(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpOptions]
        [Route(Resources.Constants.AppInfoApi.SystemInfo.Rout, Name = Resources.Constants.AppInfoApi.SystemInfo.RoutName)]
        [Route(Resources.Constants.AppInfoApi.SystemInfoExt.Rout, Name = Resources.Constants.AppInfoApi.SystemInfoExt.RoutName)]
        public IHttpActionResult GetSystemInfo()
        {
            string owinUrl = (_configurationManager.AppSettings["OwinUrl"] ?? "").TrimEnd('/');
            //return Ok("system Options");
            return Ok(new SystemInfo
            {
                links = new Link[]
                {
                    new Link(){ Name = "self", Href = Url.Link(Resources.Constants.AppInfoApi.SystemInfo.RoutName, null), Method = HttpVerbs.Options.ToString().ToUpper() },
                    new Link(){ Name = "Metrics", Href = owinUrl + "/v2/json", Method = HttpVerbs.Get.ToString().ToUpper() },
                    new Link(){ Name = "Metrics UI", Href = owinUrl + "/metrics", Method = HttpVerbs.Get.ToString().ToUpper() /*, Enabled = new MetricsEndpoint().FeatureEnabled*/ },
                    new Link(){ Name = "Job UI", Href = owinUrl + "/jobs", Method = HttpVerbs.Get.ToString().ToUpper() /*, Enabled = new HangfireDashboard().FeatureEnabled*/ },
                    new Link(){ Name = Resources.Constants.AppInfoApi.VersionInfo.RoutName, Href = Url.Link(Resources.Constants.AppInfoApi.VersionInfo.RoutName, null), Method = HttpVerbs.Get.ToString().ToUpper() },
                }
            });
        }

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.AppInfoApi.VersionInfo.Rout, Name = Resources.Constants.AppInfoApi.VersionInfo.RoutName)]
        public IHttpActionResult GetVersionInfo()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName().Version;
            var file = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            var product = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

            return Ok($"Assembly: {assembly}, File: {file}, Product: {product}");
        }

    }
}
