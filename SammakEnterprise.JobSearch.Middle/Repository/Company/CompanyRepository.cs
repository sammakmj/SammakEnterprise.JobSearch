using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;

namespace SammakEnterprise.JobSearch.Middle.Repository.Company
{
    public class CompanyRepository : RepositoryBase<Entities.Company, int>, ICompanyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="queryFactory"></param>
        /// <param name="validationFactory">validationFactory</param>
        public CompanyRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
            : base(session, queryFactory, validationFactory)
        {
        }

        ///// <summary>
        ///// Determines if the target company exist in the repository
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public bool Exists(string name)
        //{
        //    return Exists(x => x.Name == name);
        //}
    }
}
