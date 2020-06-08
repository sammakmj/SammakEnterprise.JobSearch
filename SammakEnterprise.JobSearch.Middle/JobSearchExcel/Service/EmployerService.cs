using AutoMapper;
using SammakEnterprise.Core.Persistence.Services;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service
{
    #region Employer Service Interface
    public interface IEmployerService : IService<Entity.Employer>
    {
        EmployerExposeCollection GetAll();

        EmployerExpose CreateEmployer(string name);

        EmployerExpose GetById(Guid id);
    }
    #endregion

    #region Employer Service Implementation
    public class EmployerService : ServiceBase<Entity.Employer, IEmployerRepository>, IEmployerService
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
            var col = Mapper.Map<IEnumerable<Entity.Employer>, EmployerExposeCollection>(all);
            return col;

        }

        public EmployerExpose CreateEmployer(string name)
        {
            var employer = Entity.Employer.Create(name);

            Repository.Add(employer);

            employer = Repository.GetEmployer(name);
            return Mapper.Map<Entity.Employer, EmployerExpose>(employer);
        }

        public EmployerExpose GetById(Guid id)
        {
            var employer = Repository.Load(id);
            return Mapper.Map<Entity.Employer, EmployerExpose>(employer);
        }
    }
    #endregion

    #region Employer Expose Mapping
    public class EmployerExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }
        public string WebSite { get; set; }

        public List<ChildExpose> Approaches { get; set; }

        #endregion
    }

    public class EmployerExposeCollection
    {
        public EmployerExposeCollection()
        {
            Data = new List<EmployerExpose>();
        }

        public List<EmployerExpose> Data { get; set; }
    }

    public class EmployerExposeMapping : Profile
    {
        public EmployerExposeMapping()
        {
            CreateMap<Entity.Employer, EmployerExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.WebSite, opt => opt.MapFrom(src => src.WebSite))
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

            CreateMap<IEnumerable<Entity.Employer>, EmployerExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Entity.Employer, EmployerExpose>(entry));
                    }

                });

        }
    }
    #endregion
}
