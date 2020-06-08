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
    public class AgentController : ControllerBase
    {
        #region Properties

        private readonly IAgentService _agentService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentController"/> class.
        /// </summary>
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.AgentApi.GetAll.Rout, Name = Resources.Constants.AgentApi.GetAll.RoutName)]
        public IHttpActionResult GetAllAgents()
        {
            try
            {
                var agents = _agentService.GetAll();
                return Ok(agents);
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
        [Route(Resources.Constants.AgentApi.GetAgent.Rout, Name = Resources.Constants.AgentApi.GetAgent.RoutName)]
        public IHttpActionResult GetAgent(Guid id)
        {
            try
            {
                var agent = _agentService.GetById(id);
                if (agent == null)
                    return Content(HttpStatusCode.NotFound, ErrorMessages.NotFound("Agent by id", id));

                return Ok(agent);
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
        [Route(Resources.Constants.AgentApi.CreateAgent.Rout, Name = Resources.Constants.AgentApi.CreateAgent.RoutName)]
        public IHttpActionResult CreateAgency(string name)
        {
            try
            {
                var agencyName = Util.Utilities.ReplaceDashesWithSpaces(name);
                var agent = _agentService.CreateAgent(agencyName);
                return Ok(agent);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
