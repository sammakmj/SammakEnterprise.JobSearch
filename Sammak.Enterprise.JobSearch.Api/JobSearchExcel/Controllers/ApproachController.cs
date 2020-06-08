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
    public class ApproachController : ControllerBase
    {
        #region Properties

        private readonly IApproachService _approachService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproachController"/> class.
        /// </summary>
        public ApproachController(IApproachService approachService)
        {
            _approachService = approachService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.ApproachApi.GetAll.Rout, Name = Resources.Constants.ApproachApi.GetAll.RoutName)]
        public IHttpActionResult GetAllApproachs()
        {
            try
            {
                var approachs = _approachService.GetAll();
                return Ok(approachs);
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
        [Route(Resources.Constants.ApproachApi.GetApproach.Rout, Name = Resources.Constants.ApproachApi.GetApproach.RoutName)]
        public IHttpActionResult GetApproach(Guid id)
        {
            try
            {
                var approach = _approachService.GetById(id);
                if (approach == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Approach by id", id));

                return Ok(approach);
            }
            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        ///// <summary>
        ///// GetSystemInfo method.
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route(Resources.Constants.ApproachApi.CreateApproach.Rout, Name = Resources.Constants.ApproachApi.CreateApproach.RoutName)]
        //public IHttpActionResult CreateAgency(string name)
        //{
        //    try
        //    {
        //        var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
        //        var approach = _approachService.CreateApproach(agencyName);
        //        return Ok(approach);
        //    }

        //    catch (Exception ex)
        //    {
        //        return ExceptionError(ex);
        //    }
        //}

        #endregion
    }
}
