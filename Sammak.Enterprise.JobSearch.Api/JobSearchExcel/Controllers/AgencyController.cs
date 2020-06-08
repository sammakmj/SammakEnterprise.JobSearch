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
        [Route(Resources.Constants.AgencyApi.GetAll.Rout, Name = Resources.Constants.AgencyApi.GetAll.RoutName)]
        public IHttpActionResult GetAllAgencys()
        {
            try
            {
                var agencys = _agencyService.GetAll();
                return Ok(agencys);
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
        [Route(Resources.Constants.AgencyApi.GetAgency.Rout, Name = Resources.Constants.AgencyApi.GetAgency.RoutName)]
        public IHttpActionResult GetAgency(Guid id)
        {
            try
            {
                var agency = _agencyService.GetById(id);
                if (agency == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Agency by id", id));

                return Ok(agency);
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
        [Route(Resources.Constants.AgencyApi.CreateAgency.Rout, Name = Resources.Constants.AgencyApi.CreateAgency.RoutName)]
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
