using System.Linq;
using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository
{
    #region Interface
    public interface IEmployerRepository : IRepository<Employer, int>
    {
        Employer GetEmployer(string employerName);
    }
    #endregion

    #region Implementation
    public class EmployerRepository : RepositoryBase<Employer, int>, IEmployerRepository
    {
        public EmployerRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Employer GetEmployer(string employerName) =>
            Query(x => x.Name == employerName).FirstOrDefault();
    }
    #endregion

}
