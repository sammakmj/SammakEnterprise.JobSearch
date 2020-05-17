using Newtonsoft.Json;
using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Employer;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class EmployerController : ControllerBase
    {
        #region Properties

        private readonly IEmployerService _employerService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployerController"/> class.
        /// </summary>
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("employers", Name = "Get All Employers")]
        public IHttpActionResult GetAllAgencies()
        {
            try
            {
                var employers = _employerService.GetAll();
                return Ok(employers);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
