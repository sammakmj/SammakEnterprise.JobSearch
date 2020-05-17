using Newtonsoft.Json;
using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Recruiter;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class RecruiterController : ControllerBase
    {
        #region Properties

        private readonly IRecruiterService _recruiterService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RecruiterController"/> class.
        /// </summary>
        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("recruiter/{firstName}-{lastName}", Name = "Get Recruiter By First Last Name")]
        public IHttpActionResult GetRecruiter(string firstName, string lastName)
        {
            try
            {
                var recruiterName = Util.Utilities.ConcatenateWords(firstName, lastName);
                //var recruiterName = firstName + " " + lastName;
                var recruiter = _recruiterService.GetRecruiter(recruiterName);
                return Ok(recruiter);
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
        [Route("recruiters", Name = "Get All Recruiters")]
        public IHttpActionResult GetAllRecruiters()
        {
            try
            {
                var recruiters = _recruiterService.GetAll();
                return Ok(recruiters);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
