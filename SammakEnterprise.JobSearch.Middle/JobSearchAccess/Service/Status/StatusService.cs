using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Status;
using System.Collections.Generic;
using Entity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Status
{
    public class StatusService : ServiceBase<Middle.JobSearchAccess.Entity.Status, IStatusRepository>, IStatusService
    {
        private IStatusRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public StatusService(
            IStatusRepository repository,
            IStatusRepository repository1,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
            _repository = repository;
        }

        //public StatusExpose GetStatus(string statusName)
        //{
        //    var status = Repository.GetStatus(statusName);
        //    return Mapper.Map<Entity.Status, StatusExpose>(status);
        //}

        public StatusExposeCollection GetAll()
        {
            var statuses = Search();
            return Mapper.Map<IEnumerable<Entity.Status>, StatusExposeCollection>(statuses);

        }

        public StatusExposeCollection GetStatusesPerRecruiter(string recruiterName)
        {
            IEnumerable<Entity.Status> statuses = Repository.GetStatusesPerRecruiter(recruiterName);
            return Mapper.Map<IEnumerable<Entity.Status>, StatusExposeCollection>(statuses);
        }
    }
}
