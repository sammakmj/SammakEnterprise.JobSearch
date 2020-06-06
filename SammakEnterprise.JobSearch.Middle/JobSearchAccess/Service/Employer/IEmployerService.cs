using SammakEnterprise.Core.Persistence.Services;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Employer
{
    public interface IEmployerService : IService<Middle.JobSearchAccess.Entity.HiringCompany>
    {
        EmployerExposeCollection GetAll();
    }
}
