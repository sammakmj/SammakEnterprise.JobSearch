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
    public class LocationController : ControllerBase
    {
        #region Properties

        private readonly ILocationService _locationService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationController"/> class.
        /// </summary>
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.LocationApi.GetAll.Rout, Name = Resources.Constants.LocationApi.GetAll.RoutName)]
        public IHttpActionResult GetAllLocations()
        {
            try
            {
                var locations = _locationService.GetAll();
                return Ok(locations);
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
        [Route(Resources.Constants.LocationApi.GetLocation.Rout, Name = Resources.Constants.LocationApi.GetLocation.RoutName)]
        public IHttpActionResult GetLocation(Guid id)
        {
            try
            {
                var location = _locationService.GetById(id);
                if (location == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Location by id", id));

                return Ok(location);
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
        [Route(Resources.Constants.LocationApi.CreateLocation.Rout, Name = Resources.Constants.LocationApi.CreateLocation.RoutName)]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var location = _locationService.CreateLocation(agencyName);
                return Ok(location);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
