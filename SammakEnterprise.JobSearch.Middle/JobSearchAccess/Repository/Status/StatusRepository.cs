using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Status
{
    public class StatusRepository : RepositoryBase<Entity.Status, int>, IStatusRepository
    {
        public StatusRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public IEnumerable<Entity.Status> GetStatusesPerRecruiter(string recruiterName)
        {
            var statuses = Query(x => x.JobSearch != null)
                .Where(y => y.JobSearch.Recruiter != null)
                .Where(y => y.JobSearch.Recruiter.RecruiterName == recruiterName)
                .OrderBy(x => x.StatusDate);

            //var statuses = Query(x => x.JobSearch.Recruiter.RecruiterName == recruiterName);
            return statuses;
        }
    }
}
