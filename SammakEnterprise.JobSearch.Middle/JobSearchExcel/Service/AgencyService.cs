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
    #region AgencyService Interface
    public interface IAgencyService : IService<Entity.Agency>
    {
        AgencyExposeCollection GetAll();

        AgencyExpose GetById(Guid id);

        AgencyExpose CreateAgency(string name);
    }
    #endregion

    #region AgencyService Implementation
    public class AgencyService : EntityService<Entity.Agency, IAgencyRepository>, IAgencyService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public AgencyService(
            IAgencyRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public AgencyExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Agency>, AgencyExposeCollection>(all);
            return col;

        }

        public AgencyExpose GetById(Guid id)
        {
            var jobTitle = Load(id);
            var output = Mapper.Map<Entity.Agency, AgencyExpose>(jobTitle);
            return output;

        }

        public AgencyExpose CreateAgency(string name)
        {
            var jobTitle = Entity.Agency.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetAgency(name);
            return Mapper.Map<Entity.Agency, AgencyExpose>(jobTitle);
        }

    }
    #endregion

    #region Agency Expose Mapping
    public class AgencyExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }
        public string WebSite { get; internal set; }

        #endregion
    }

    public class AgencyExposeCollection
    {
        public AgencyExposeCollection()
        {
            Data = new List<AgencyExpose>();
        }

        public List<AgencyExpose> Data { get; set; }
    }

    public class AgencyExposeMapping : Profile
    {
        public AgencyExposeMapping()
        {
            CreateMap<Agency, AgencyExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.WebSite, opt => opt.MapFrom(src => src.WebSite))
                ;

            CreateMap<IEnumerable<Agency>, AgencyExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Agency, AgencyExpose>(entry));
                    }

                }
            );
        }

    }
    #endregion
}
