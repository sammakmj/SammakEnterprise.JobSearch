using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Agency
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IAgencyRepository : IRepository<Entity.Agency, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        Entity.Agency GetAgency(string agencyName);
    }
}
