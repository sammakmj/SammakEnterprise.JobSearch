using System.Linq;
using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.JobSearch
{
    public class JobSearchRepository : RepositoryBase<Entity.JobSearch, int>, IJobSearchRepository
    {
        public JobSearchRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Entity.JobSearch GetByRecruiterAnEmployer(Entity.Recruiter recuiter, Entity.HiringCompany employer)
        {
            var jobSearch = Query().FirstOrDefault(x => x.Recruiter == recuiter && x.Employer == employer);
            //var jobSearch = Query(x => x.Recruiter.Id == recuiterId && x.Employer.Id == employerId).FirstOrDefault();
            return jobSearch;
        }

        public Entity.JobSearch GetByRecruiterAnEmployer(int recuiterId, int employerId)
        {
            var jobSearch = Query().FirstOrDefault(x => x.Recruiter.Id == recuiterId && x.Employer.Id == employerId);
            //var jobSearch = Query(x => x.Recruiter.Id == recuiterId && x.Employer.Id == employerId).FirstOrDefault();
            return jobSearch;
        }
    }
}
