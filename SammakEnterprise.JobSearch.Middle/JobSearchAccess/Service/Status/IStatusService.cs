using SammakEnterprise.Core.Persistence.Services;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Status
{
    public interface IStatusService : IService<Middle.JobSearchAccess.Entity.Status>
    {
        StatusExposeCollection GetAll();

        StatusExposeCollection GetStatusesPerRecruiter(string recruiterName);
    }
}
