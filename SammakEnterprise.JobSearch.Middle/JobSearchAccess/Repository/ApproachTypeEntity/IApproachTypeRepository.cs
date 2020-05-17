using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Enums;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.ApproachTypeEntity
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IApproachTypeRepository : IRepository<Entity.ApproachTypeEntity, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="approachType"></param>
        /// <returns></returns>
        Entity.ApproachTypeEntity GetApproachTypeEntity(ApproachType approachType);
    }
}
