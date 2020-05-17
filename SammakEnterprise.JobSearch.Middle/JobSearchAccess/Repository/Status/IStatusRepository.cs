using System.Collections.Generic;
using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Status
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IStatusRepository : IRepository<Entity.Status, int>
    //, IDomainValidationHandler<Entities.Company>
    {
        IEnumerable<Entity.Status> GetStatusesPerRecruiter(string recruiterName);
    }
}
