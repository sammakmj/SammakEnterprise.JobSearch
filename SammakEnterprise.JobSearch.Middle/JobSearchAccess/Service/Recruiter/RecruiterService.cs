using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Recruiter;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Recruiter
{
    public class RecruiterService : ServiceBase<Middle.JobSearchAccess.Entity.Recruiter, IRecruiterRepository>, IRecruiterService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RecruiterService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public RecruiterService(
            IRecruiterRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public RecruiterExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Middle.JobSearchAccess.Entity.Recruiter>, RecruiterExposeCollection>(all);
            return col;

        }

        public RecruiterExpose GetRecruiter(string recruiterName)
        {
            var recruiter = Repository.GetRecruiter(recruiterName);
            return Mapper.Map<Middle.JobSearchAccess.Entity.Recruiter, RecruiterExpose>(recruiter);
        }
    }
}
