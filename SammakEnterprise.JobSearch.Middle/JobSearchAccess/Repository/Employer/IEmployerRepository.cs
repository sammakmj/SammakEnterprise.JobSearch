using SammakEnterprise.Core.Persistence.Repository;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Employer
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IEmployerRepository : IRepository<Entity.Employer, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        Entity.Employer GetEmployer(string employerName);
    }
}
