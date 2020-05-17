using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Status;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class StatusController : ControllerBase
    {
        #region Properties

        private readonly IStatusService _statusService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusController"/> class.
        /// </summary>
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("statuses", Name = "Get All Statuses")]
        public IHttpActionResult GetAllAgencies()
        {
            try
            {
                var statuses = _statusService.GetAll();
                return Ok(statuses);
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
        [Route("statuses/{recruiterName}", Name = "Get All Statuses For Recruiter")]
        public IHttpActionResult GetAllAgencies(string recruiterName)
        {
            try
            {
                var name = Util.Utilities.ReplaceDashesWithSpaces(recruiterName);
                var statuses = _statusService.GetStatusesPerRecruiter(name);
                return Ok(statuses);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
