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
    public interface IMethodRepository : IRepository<Method, int>
    {
        Method GetMethod(string jobTitleName);
    }
    #endregion

    #region Implementation
    public class MethodRepository : RepositoryBase<Method, int>, IMethodRepository
    {
        public MethodRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Method GetMethod(string jobTitleName) =>
            Query(x => x.Name == jobTitleName).FirstOrDefault();
    }
    #endregion

}
