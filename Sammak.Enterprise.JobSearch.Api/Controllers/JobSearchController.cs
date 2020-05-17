using Newtonsoft.Json;
using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.JobSearch;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class JobSearchController : ControllerBase
    {
        #region Properties

        private readonly IJobSearchService _jobSearchService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchController"/> class.
        /// </summary>
        public JobSearchController(IJobSearchService jobSearchService)
        {
            _jobSearchService = jobSearchService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("approach", Name = "Create a JobSearch")]
        public IHttpActionResult CreateApproach()
        {
            try
            {
                var jobSearch = _jobSearchService.CreateApproach();
                return Ok(jobSearch);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("jobSearches", Name = "Get All JobSearches")]
        public IHttpActionResult GetAllJobSearchs()
        {
            try
            {
                var jobSearchs = _jobSearchService.GetAll();
                return Ok(jobSearchs);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
