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
    public interface IApproachRepository : IRepository<Approach, int>
    {
        Approach GetApproach(DateTime initialDate);
    }
    #endregion

    #region Implementation
    public class ApproachRepository : RepositoryBase<Approach, int>, IApproachRepository
    {
        public ApproachRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Approach GetApproach(DateTime initialDate) =>
            Query(x => x.InitialDate == initialDate).FirstOrDefault();
    }
    #endregion

}
