using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Agency;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.ApproachTypeEntity;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Employer;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.JobSearch;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Recruiter;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Status;
using System;
using System.Collections.Generic;
using ServiceStack;
using ApproachType = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Enums.ApproachType;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.JobSearch
{
    public class JobSearchService : ServiceBase<Entity.JobSearch, IJobSearchRepository>, IJobSearchService
    {

        private readonly IRecruiterRepository _recruiterRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IApproachTypeRepository _approachTypeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="approachTypeRepository"></param>
        /// <param name="validationFactory">The exam repo.</param>
        /// <param name="agencyRepository"></param>
        /// <param name="recruiterRepository"></param>
        /// <param name="employerRepository"></param>
        /// <param name="statusRepository"></param>
        public JobSearchService(
            IJobSearchRepository repository,
            IAgencyRepository agencyRepository,
            IRecruiterRepository recruiterRepository,
            IEmployerRepository employerRepository,
            IStatusRepository statusRepository,
            IApproachTypeRepository approachTypeRepository,
            IValidationFactory validationFactory)
                : base(repository, validationFactory)
        {
            _agencyRepository = agencyRepository;
            _recruiterRepository = recruiterRepository;
            _employerRepository = employerRepository;
            _statusRepository = statusRepository;
            _approachTypeRepository = approachTypeRepository;
        }

        public JobSearchExposeCollection GetAll()
        {
            var all = Search();
            return Mapper.Map<IEnumerable<Entity.JobSearch>, JobSearchExposeCollection>(all);

        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="jobSearchDescription"></param>
        /// <returns></returns>
        public JobSearchExpose CreateApproach(string jobSearchDescription)
        {
            var approachType = _approachTypeRepository.GetApproachTypeEntity(ApproachType.MyApproach);
            var employer = _employerRepository.GetEmployer("Nortrup Gorman");
            var recuiter = _recruiterRepository.GetRecruiter("Kristin Gorman");
            var agency = recuiter.Agency;

            var approach = Entity.JobSearch.Create(DateTime.Now, approachType, "my desc");
            approach.Recruiter = recuiter;
            approach.Employer = employer;
            approach.JobTitle = "Developer";

            Repository.Add(approach);

            approach = Repository.GetByRecruiterAnEmployer(recuiter.Id, employer.Id);
            approach = Repository.GetByRecruiterAnEmployer(recuiter, employer);

            return Mapper.Map<Entity.JobSearch, JobSearchExpose>(approach);
        }
    }
}
