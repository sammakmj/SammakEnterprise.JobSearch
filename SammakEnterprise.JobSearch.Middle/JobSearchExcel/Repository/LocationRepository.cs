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
    public interface ILocationRepository : IRepository<Location, int>
    {
        Location GetLocation(string locationName);
    }
    #endregion

    #region Implementation
    public class LocationRepository : RepositoryBase<Location, int>, ILocationRepository
    {
        public LocationRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Location GetLocation(string locationName) =>
            Query(x => x.Name == locationName).FirstOrDefault();
    }
    #endregion

}
