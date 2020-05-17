using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;
using System.Linq;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Recruiter
{
    public class RecruiterRepository : RepositoryBase<Entity.Recruiter, int>, IRecruiterRepository
    {
        public RecruiterRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Entity.Recruiter GetRecruiter(string recruiterName)
        {
            //var recruiter = Query(x => x.RecruiterName.Equals(recruiterName)).FirstOrDefault();
            //var recruiter = Query(x => x.RecruiterName.ToLower() == recruiterName.ToLower()).FirstOrDefault();
            var recruiter = Query(x => x.RecruiterName == recruiterName).FirstOrDefault();
            return recruiter;
        }
    }
}
