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
    #region AgentService Interface
    public interface IAgentService : IService<Entity.Agent>
    {
        AgentExposeCollection GetAll();

        AgentExpose GetById(Guid id);

        AgentExpose CreateAgent(string name);
    }
    #endregion

    #region AgentService Implementation
    public class AgentService : EntityService<Entity.Agent, IAgentRepository>, IAgentService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public AgentService(
            IAgentRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public AgentExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Agent>, AgentExposeCollection>(all);
            return col;

        }

        public AgentExpose GetById(Guid id)
        {
            var jobTitle = Load(id);
            var output = Mapper.Map<Entity.Agent, AgentExpose>(jobTitle);
            return output;

        }

        public AgentExpose CreateAgent(string name)
        {
            var jobTitle = Entity.Agent.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetAgent(name);
            return Mapper.Map<Entity.Agent, AgentExpose>(jobTitle);
        }

    }
    #endregion

    #region Agent Expose Mapping
    public class AgentExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }
        public string Email { get; internal set; }
        public string MobilePhone { get; internal set; }
        public string OfficePhone { get; internal set; }
        public ChildExpose Agency { get; set; }

        public List<ChildExpose> Approaches { get; set; }

        #endregion
    }

    public class AgentExposeCollection
    {
        public AgentExposeCollection()
        {
            Data = new List<AgentExpose>();
        }

        public List<AgentExpose> Data { get; set; }
    }

    public class AgentExposeMapping : Profile
    {
        public AgentExposeMapping()
        {
            CreateMap<Agent, AgentExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.OfficePhone, opt => opt.MapFrom(src => src.OfficePhone))
                .ForMember(dest => dest.Agency, opt => opt.Ignore())
                .ForMember(dest => dest.Approaches, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                {
                    if (src.Agency != null)
                    {
                        dest.Agency = new ChildExpose
                        {
                            Id = src.Agency.ExternalId,
                            Description = src.Agency.ToString()
                        };
                    }
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

            CreateMap<IEnumerable<Agent>, AgentExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Agent, AgentExpose>(entry));
                    }

                }
            );
        }

    }
    #endregion
}
