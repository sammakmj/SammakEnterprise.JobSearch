using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Repository.Company;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Services.Company
{
    public class CompanyService : ServiceBase<Entities.Company, ICompanyRepository>, ICompanyService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public CompanyService(
            ICompanyRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        IEnumerable<Entities.Company> ICompanyService.GetAllCompanys()
        {
            //var p1 = Entities.Company.Create("Comcast", Common.Utilities.DefaultUser());
            //if (!Repository.Exists(p1))
            //{
            //    Repository.Add(p1);
            //}

            //var p2 = Entities.Company.Create("Second Company", Common.Utilities.DefaultUser());
            //if (!Repository.Exists(p2))
            //{
            //    Repository.Add(p2);
            //}
            return Search();
        }
    }
}
