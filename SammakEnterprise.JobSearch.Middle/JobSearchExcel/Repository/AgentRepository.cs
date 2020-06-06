using System.Linq;
using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository
{
    #region Interface
    public interface IAgentRepository : IRepository<Agent, int>
    {
        Agent GetAgent(string agentName);
    }
    #endregion

    #region Implementation
    public class AgentRepository : RepositoryBase<Agent, int>, IAgentRepository
    {
        public AgentRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Agent GetAgent(string agentName) =>
            Query(x => x.Name == agentName).FirstOrDefault();
    }
    #endregion

}
