using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service;
using System;
using System.Net;
using System.Web.Http;
using SammakEnterprise.Core.Common.Api.Constants.Messages;
using NHibernate.Mapping;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Api.JobSearchExcel.Controllers
{
    /// <summary>
    /// 
    /// </summary>
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
        [Route(Resources.Constants.EmployerApi.GetAll.Rout, Name = Resources.Constants.EmployerApi.GetAll.RoutName)]
        public IHttpActionResult GetAllEmployers()
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

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.EmployerApi.GetEmployer.Rout, Name = Resources.Constants.EmployerApi.GetEmployer.RoutName)]
        public IHttpActionResult GetEmployer(Guid id)
        {
            try
            {
                var employer = _employerService.GetById(id);
                if (employer == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Employer by id", id));

                return Ok(employer);
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
        [Route(Resources.Constants.EmployerApi.CreateEmployer.Rout, Name = Resources.Constants.EmployerApi.CreateEmployer.RoutName)]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var employer = _employerService.CreateEmployer(agencyName);
                return Ok(employer);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
