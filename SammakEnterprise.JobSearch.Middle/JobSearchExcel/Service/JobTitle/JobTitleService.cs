using SammakEnterprise.Core.Persistence.Services;
using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using System.Collections.Generic;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using SammakEnterprise.JobSearch.Middle.Services.Shared;
using System;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service.JobTitle
{
    #region Interface
    public interface IJobTitleService : IService<Entity.JobTitle>
    {
        JobTitleExposeCollection GetAll();

        JobTitleExpose GetById(Guid id);
        
        JobTitleExpose CreateJobTitle(string name);
   }
    #endregion

    #region Implementation
    public class JobTitleService : EntityService<Entity.JobTitle, IJobTitleRepository>, IJobTitleService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitleService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public JobTitleService(
            IJobTitleRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public JobTitleExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.JobTitle>, JobTitleExposeCollection>(all);
            return col;

        }

        public JobTitleExpose GetById(Guid id)
        {
            var jobTitle = Load(id);
            var output = Mapper.Map<Entity.JobTitle, JobTitleExpose>(jobTitle);
            return output;

        }

        public JobTitleExpose CreateJobTitle(string name)
        {
            var jobTitle = Entity.JobTitle.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetJobTitle(name);
            return Mapper.Map<Entity.JobTitle, JobTitleExpose>(jobTitle);
        }

    }
    #endregion

}
