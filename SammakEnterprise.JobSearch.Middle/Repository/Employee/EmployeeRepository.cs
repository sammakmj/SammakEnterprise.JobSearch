using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using System.Collections.Generic;
using System.Linq;

namespace SammakEnterprise.JobSearch.Middle.Repository.Employee
{
    public class EmployeeRepository : RepositoryBase<JobSearch.Middle.Entities.Employee, int>, IEmployeeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="queryFactory"></param>
        /// <param name="validationFactory">validationFactory</param>
        public EmployeeRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
            : base(session, queryFactory, validationFactory)
        {
        }

        /// <summary>
        /// Determines if a person with the given first and last name exist in the repository
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public virtual bool Exists(string firstName, string lastName)
        {
            return Exists(x => x.FirstName == firstName && x.LastName == lastName);
        }

        /// <summary>
        /// returns all employees with the Recruiter role
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JobSearch.Middle.Entities.Employee> GetRecruiters()
        {
            return Query(x => x.Role == JobSearch.Middle.Enums.Role.Recruiter);
        }

        /// <summary>
        /// returns all Recruiter employees with supplied name
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public IEnumerable<JobSearch.Middle.Entities.Employee> GetEmployeesByName(string firstName, string lastName)
        {
            return GetRecruiters()
                .Where(x => x.FirstName == firstName && x.LastName == lastName);
        }

    }
}
