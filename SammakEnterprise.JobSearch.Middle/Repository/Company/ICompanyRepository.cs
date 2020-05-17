using SammakEnterprise.Core.Persistence.Repository;

namespace SammakEnterprise.JobSearch.Middle.Repository.Company
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface ICompanyRepository : IRepository<Entities.Company, int>
    //, IEntity<int>
    //, IDomainValidationHandler<Entities.Company>
    {

        ///// <summary>
        ///// Determines if the target company exist in the repository
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //bool Exists(string email);
    }
}
