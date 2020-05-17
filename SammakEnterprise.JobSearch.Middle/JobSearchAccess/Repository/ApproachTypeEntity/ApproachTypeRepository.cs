using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Enums;
using System.Linq;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.ApproachTypeEntity
{
    public class ApproachTypeRepository : RepositoryBase<Entity.ApproachTypeEntity, int>, IApproachTypeRepository
    {
        public ApproachTypeRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="approachType"></param>
        /// <returns></returns>
        public Entity.ApproachTypeEntity GetApproachTypeEntity(ApproachType approachType)
        {
            var t = approachType.ToString();
            return Query(x => x.ApproachMethod == approachType.ToString()).FirstOrDefault();
        }
    }
}
