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
    public class ActivityController : ControllerBase
    {
        #region Properties

        private readonly IActivityService _activityService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityController"/> class.
        /// </summary>
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.ActivityApi.GetAll.Rout, Name = Resources.Constants.ActivityApi.GetAll.RoutName)]
        public IHttpActionResult GetAllActivitys()
        {
            try
            {
                var activitys = _activityService.GetAll();
                return Ok(activitys);
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
        [Route(Resources.Constants.ActivityApi.GetActivity.Rout, Name = Resources.Constants.ActivityApi.GetActivity.RoutName)]
        public IHttpActionResult GetActivity(Guid id)
        {
            try
            {
                var activity = _activityService.GetById(id);
                if (activity == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Activity by id", id));

                return Ok(activity);
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
        //[Route(Resources.Constants.ActivityApi.CreateActivity.Rout, Name = Resources.Constants.ActivityApi.CreateActivity.RoutName)]
        //public IHttpActionResult CreateActivity(string name)
        //{
        //    try
        //    {
        //        var activityName = Util.Utilities.ReplaceDashesWithSpaces(name);
        //        var activity = _activityService.CreateActivity(activityName);
        //        return Ok(activity);
        //    }

        //    catch (Exception ex)
        //    {
        //        return ExceptionError(ex);
        //    }
        //}

        #endregion
    }
}
