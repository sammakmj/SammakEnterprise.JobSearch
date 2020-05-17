using SammakEnterprise.Core.Persistence.Services;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Services.Employee
{
    public interface IEmployeeService : IService<Entities.Employee>
    {
        IEnumerable<Entities.Employee> GetAllEmployees();
    }
}
