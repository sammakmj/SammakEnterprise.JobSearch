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
    public interface IJobTitleRepository : IRepository<JobTitle, int>
    {
        JobTitle GetJobTitle(string jobTitleName);
    }
    #endregion

    #region Implementation
    public class JobTitleRepository : RepositoryBase<JobTitle, int>, IJobTitleRepository
    {
        public JobTitleRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public JobTitle GetJobTitle(string jobTitleName) =>
            Query(x => x.Name == jobTitleName).FirstOrDefault();
    }
    #endregion

}
