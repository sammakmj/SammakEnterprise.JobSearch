using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Employer;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Employer
{
    public class EmployerService : ServiceBase<Middle.JobSearchAccess.Entity.Employer, IEmployerRepository>, IEmployerService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployerService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public EmployerService(
            IEmployerRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public EmployerExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Middle.JobSearchAccess.Entity.Employer>, EmployerExposeCollection>(all);
            return col;

        }

    }
}
