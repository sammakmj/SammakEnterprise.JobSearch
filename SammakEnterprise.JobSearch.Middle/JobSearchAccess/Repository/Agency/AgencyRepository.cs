using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;
using System.Linq;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Agency
{
    public class AgencyRepository : RepositoryBase<Entity.AgencyCompany, int>, IAgencyRepository
    {
        public AgencyRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Entity.AgencyCompany GetAgency(string agencyName)
        {
            return Query(x => x.AgencyName == agencyName).FirstOrDefault();
        }
    }
}
