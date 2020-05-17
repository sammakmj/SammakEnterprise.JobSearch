using SammakEnterprise.Core.Persistence.Repository;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Repository.Employee
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IEmployeeRepository : IRepository<JobSearch.Middle.Entities.Employee, int>
    {
        /// <summary>
        /// Determines if a person with the given first and last name exist in the repository
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        bool Exists(string firstName, string lastName);

        /// <summary>
        /// returns all employees with the Recruiter role
        /// </summary>
        /// <returns></returns>
        IEnumerable<JobSearch.Middle.Entities.Employee> GetRecruiters();

        /// <summary>
        /// returns all Recruiter employees with supplied name
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        IEnumerable<JobSearch.Middle.Entities.Employee> GetEmployeesByName(string firstName, string lastName);
    }
}
