using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Repository.Employee;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Services.Employee
{
    public class EmployeeService : ServiceBase<Entities.Employee, IEmployeeRepository>, IEmployeeService
    {
        private IEmployeeRepository _repository;
        private IEmployeeRepository _repository1;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public EmployeeService(
            IEmployeeRepository repository,
            IEmployeeRepository repository1,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
            _repository = repository;
            _repository1 = repository1;
        }

        IEnumerable<Entities.Employee> IEmployeeService.GetAllEmployees()
        {
            //var p1 = Entities.Employee.Create("M. Jeff", "Sammak");
            //if (!Repository.Exists(p1))
            //{
            //    Repository.Add(p1);
            //}

            //if (!Repository.Exists("Second", "Employee"))
            //{
            //    var p2 = Entities.Employee.Create("Second", "Employee", Common.Utilities.DefaultUser());
            //    Repository.Add(p2);
            //}

            var persons = Search();
            return persons;
            //return null;
        }
    }
}
