using AutoMapper;
using SammakEnterprise.Core.Persistence.Services;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using SammakEnterprise.JobSearch.Middle.Services.Shared;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service
{
    #region JobTitleService Interface
    public interface IJobTitleService : IService<Entity.JobTitle>
    {
        JobTitleExposeCollection GetAll();

        JobTitleExpose GetById(Guid id);

        JobTitleExpose CreateJobTitle(string name);
    }
    #endregion

    #region JobTitleService Implementation
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

    #region JobTitle Expose Mapping
    public class JobTitleExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }

        public List<ChildExpose> Approaches { get; set; }

        #endregion
    }

    public class JobTitleExposeCollection
    {
        public JobTitleExposeCollection()
        {
            Data = new List<JobTitleExpose>();
        }

        public List<JobTitleExpose> Data { get; set; }
    }

    public class JobTitleExposeMapping : Profile
    {
        public JobTitleExposeMapping()
        {
            CreateMap<JobTitle, JobTitleExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Approaches, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                {
                    if (src.Approaches != null)
                    {
                        dest.Approaches = new List<ChildExpose>();
                        foreach (var entry in src.Approaches)
                        {
                            dest.Approaches.Add(new ChildExpose
                            {
                                Id = entry.ExternalId,
                                Description = entry.ToString()
                            });
                        }
                    }
                })
                ;

            CreateMap<IEnumerable<JobTitle>, JobTitleExposeCollection>(MemberList.Destination)
                .ForMember(dest => dest.Data, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                {
                    //Add the collection entries
                    foreach (var entry in src)
                    {
                        if (entry == null)
                        {
                            dest.Data.Add(null);
                            continue;
                        }
                        dest.Data.Add(Mapper.Map<JobTitle, JobTitleExpose>(entry));
                    }

                }
            );
        }

    }
    #endregion
}
