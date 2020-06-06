using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service;
using System;
using System.Net;
using System.Web.Http;
using SammakEnterprise.Core.Common.Api.Constants.Messages;

namespace SammakEnterprise.JobSearch.Api.JobSearchExcel.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class JobTitleController : ControllerBase
    {
        #region Properties

        private readonly IJobTitleService _jobTitleService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitleController"/> class.
        /// </summary>
        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.JobTitleApi.GetAll.Rout, Name = Resources.Constants.JobTitleApi.GetAll.RoutName)]
        public IHttpActionResult GetAllJobTitles()
        {
            try
            {
                var jobTitles = _jobTitleService.GetAll();
                return Ok(jobTitles);
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
        [Route(Resources.Constants.JobTitleApi.GetJobTitle.Rout, Name = Resources.Constants.JobTitleApi.GetJobTitle.RoutName)]
        public IHttpActionResult GetJobTitle(Guid id)
        {
            try
            {
                var jobTitle = _jobTitleService.GetById(id);
                if (jobTitle == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("JobTitle by id", id));

                return Ok(jobTitle);
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
        [Route(Resources.Constants.JobTitleApi.CreateJobTitle.Rout, Name = Resources.Constants.JobTitleApi.CreateJobTitle.RoutName)]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var jobTitle = _jobTitleService.CreateJobTitle(agencyName);
                return Ok(jobTitle);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
