using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service.Method;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.JobSearchExcel.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class MethodController : ControllerBase
    {
        #region Properties

        private readonly IMethodService _methodService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodController"/> class.
        /// </summary>
        public MethodController(IMethodService methodService)
        {
            _methodService = methodService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.MethodApi.GetAll.Rout, Name = Resources.Constants.MethodApi.GetAll.RoutName)]
        public IHttpActionResult GetAllPersons()
        {
            try
            {
                var methods = _methodService.GetAll();
                return Ok(methods);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(Resources.Constants.MethodApi.CreateMethod.Rout, Name = Resources.Constants.MethodApi.CreateMethod.RoutName)]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var method = _methodService.CreateMethod(agencyName);
                return Ok(method);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
