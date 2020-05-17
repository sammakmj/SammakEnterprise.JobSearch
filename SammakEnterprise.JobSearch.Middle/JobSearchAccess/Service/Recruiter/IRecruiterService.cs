using SammakEnterprise.Core.Persistence.Services;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Recruiter
{
    public interface IRecruiterService : IService<Middle.JobSearchAccess.Entity.Recruiter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        RecruiterExposeCollection GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recruiterName"></param>
        /// <returns></returns>
        RecruiterExpose GetRecruiter(string recruiterName);
    }
}
