using SammakEnterprise.Core.Persistence.Repository;

namespace SammakEnterprise.JobSearch.Middle.Repository.Phone
{
    /// <summary>
    /// Interface for NHibernate repositories customized
    /// </summary>
    public interface IPhoneRepository : IRepository<Entities.Phone, int>
    //, IEntity<int>
    //, IDomainValidationHandler<Entities.Phone>
    {

        /// <summary>
        /// Determines if a phone with essential properties exist in the repository
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        bool Exists(Entities.Phone phone);

        /// <summary>
        /// Determines if a phone with the given property values exist in the repository
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        bool Exists(
            short countryCode,
            short areaCode,
            string number,
            string extension);
    }
}
