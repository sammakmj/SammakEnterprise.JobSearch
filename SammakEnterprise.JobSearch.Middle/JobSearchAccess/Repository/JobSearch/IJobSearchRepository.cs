using SammakEnterprise.Core.Persistence.Repository;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.JobSearch
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IJobSearchRepository : IRepository<Entity.JobSearch, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        Entity.JobSearch GetByRecruiterAnEmployer(Entity.Recruiter recuiter, Entity.Employer employer);

        Entity.JobSearch GetByRecruiterAnEmployer(int recuiterId, int employerId);

    }
}
