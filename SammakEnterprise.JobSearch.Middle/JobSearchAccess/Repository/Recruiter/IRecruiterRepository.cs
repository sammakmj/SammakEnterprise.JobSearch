using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Recruiter
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IRecruiterRepository : IRepository<Entity.Recruiter, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recruiterName"></param>
        /// <returns></returns>
        Entity.Recruiter GetRecruiter(string recruiterName);
    }
}
