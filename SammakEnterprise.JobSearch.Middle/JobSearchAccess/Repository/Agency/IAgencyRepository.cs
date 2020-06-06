using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Agency
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IAgencyRepository : IRepository<Entity.AgencyCompany, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        Entity.AgencyCompany GetAgency(string agencyName);
    }
}
