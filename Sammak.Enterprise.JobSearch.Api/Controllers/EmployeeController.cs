using SammakEnterprise.Core.Common.Api.Controllers;
using SammakEnterprise.JobSearch.Middle.Services.Employee;
using System;
using System.Web.Http;

namespace SammakEnterprise.JobSearch.Api.Controllers
{
    [RoutePrefix(Resources.Constants.AppInfo.RoutePrefix)]
    public class EmployeeController : ControllerBase
    {
        #region Properties

        private readonly IEmployeeService _employeeService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        #region Read-only endpoints

        /// <summary>
        /// GetSystemInfo method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Resources.Constants.EmployeeApi.GetAll.Rout, Name = Resources.Constants.EmployeeApi.GetAll.RoutName)]
        public IHttpActionResult GetAllPersons()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return Ok(employees);
            }

            catch (Exception ex)
            {
                return ExceptionError(ex);
            }
        }

        #endregion
    }
}
