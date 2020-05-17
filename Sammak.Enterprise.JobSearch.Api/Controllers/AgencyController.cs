using Newtonsoft.Json;
using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Agency;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class AgencyController : ControllerBase
    {
        #region Properties

        private readonly IAgencyService _agencyService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyController"/> class.
        /// </summary>
        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("agencies", Name = "Get All Agencies")]
        public IHttpActionResult GetAllAgencies()
        {
            try
            {
                var agencies = _agencyService.GetAll();
                return Ok(agencies);
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
        [HttpGet]
        [Route("agency/{name}", Name = "Get Agency by Name")]
        public IHttpActionResult GetAllAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var agencies = _agencyService.GetAgency(agencyName);
                return Ok(agencies);
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
        [Route("agency/{name}", Name = "Create Agency by Name")]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var agency = _agencyService.CreateAgency(agencyName);
                return Ok(agency);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
