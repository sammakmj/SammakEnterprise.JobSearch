using SammakEnterprise.Core.Persistence.Services;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.JobSearch
{
    public interface IJobSearchService : IService<Middle.JobSearchAccess.Entity.JobSearch>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        JobSearchExposeCollection GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobSearchDescription"></param>
        /// <returns></returns>
        JobSearchExpose CreateApproach(string jobSearchDescription = null);
    }
}
