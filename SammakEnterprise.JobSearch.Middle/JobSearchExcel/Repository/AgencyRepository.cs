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
    public interface IAgencyRepository : IRepository<Agency, int>
    {
        Agency GetAgency(string agencyName);
    }
    #endregion

    #region Implementation
    public class AgencyRepository : RepositoryBase<Agency, int>, IAgencyRepository
    {
        public AgencyRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Agency GetAgency(string agencyName) =>
            Query(x => x.Name == agencyName).FirstOrDefault();
    }
    #endregion

}
