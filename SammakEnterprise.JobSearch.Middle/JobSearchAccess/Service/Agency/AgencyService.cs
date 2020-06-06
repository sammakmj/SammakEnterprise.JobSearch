using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Agency;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Employer;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Recruiter;
using System.Collections.Generic;
using Entity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Agency
{
    public class AgencyService : ServiceBase<Middle.JobSearchAccess.Entity.AgencyCompany, IAgencyRepository>, IAgencyService
    {
        private IRecruiterRepository _recruiterRepository;
        private IEmployerRepository _employerRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public AgencyService(
            IAgencyRepository agencyRepository,
            IRecruiterRepository recruiterRepository,
            IEmployerRepository employerRepository,
            IValidationFactory validationFactory)
            : base(agencyRepository, validationFactory)
        {
            _recruiterRepository = recruiterRepository;
            _employerRepository  = employerRepository;
       }

        public AgencyExpose CreateAgency(string agencyName)
        {
            var agency = Entity.AgencyCompany.Create(agencyName);

            Repository.Add(agency);

            agency = Repository.GetAgency(agencyName);
            return Mapper.Map<Entity.AgencyCompany, AgencyExpose>(agency);

        }


        public AgencyExpose GetAgency(string agencyName)
        {
            var agency = Repository.GetAgency(agencyName);
            return Mapper.Map<Entity.AgencyCompany, AgencyExpose>(agency);
        }

        public AgencyExposeCollection GetAll()
        {
            var allAgencies = Search();
            return Mapper.Map<IEnumerable<Entity.AgencyCompany>, AgencyExposeCollection>(allAgencies);

        }

    }
}
