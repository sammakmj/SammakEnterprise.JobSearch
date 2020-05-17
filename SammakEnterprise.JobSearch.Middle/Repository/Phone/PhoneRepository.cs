using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;

namespace SammakEnterprise.JobSearch.Middle.Repository.Phone
{
    public class PhoneRepository : RepositoryBase<Entities.Phone, int>, IPhoneRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="queryFactory"></param>
        /// <param name="validationFactory">validationFactory</param>
        public PhoneRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
            : base(session, queryFactory, validationFactory)
        {
        }

        /// <summary>
        /// Determines if a phone with essential properties exist in the repository
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Exists(Entities.Phone phone)
        {
            return Exists(
                phone.CountryCode,
                phone.AreaCode,
                phone.Number,
                phone.Extension);
        }

        /// <summary>
        /// Determines if a phone with the given property values exist in the repository
        /// </summary>
        /// <returns></returns>
        public bool Exists(
            short countryCode,
            short areaCode,
            string number,
            string extension)
        {
            return Exists(x => x.CountryCode == countryCode && x.AreaCode == areaCode && x.Number == number && x.Extension == extension);
        }
    }
}
