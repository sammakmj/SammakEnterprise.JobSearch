using System;
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
    public interface IActivityRepository : IRepository<Activity, int>
    {
        Activity GetActivity(DateTime activityDate);
    }
    #endregion

    #region Implementation
    public class ActivityRepository : RepositoryBase<Activity, int>, IActivityRepository
    {
        public ActivityRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Activity GetActivity(DateTime activityDate) =>
            Query(x => x.ActivityDate == activityDate).FirstOrDefault();
    }
    #endregion

}
