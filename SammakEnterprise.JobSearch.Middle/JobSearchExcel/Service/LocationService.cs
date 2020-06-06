using AutoMapper;
using SammakEnterprise.Core.Persistence.Services;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service
{
    #region Location Service Interface
    public interface ILocationService : IService<Entity.Location>
    {
        LocationExposeCollection GetAll();

        LocationExpose CreateLocation(string name);
    }
    #endregion

    #region Location Service Implementation
    public class LocationService : ServiceBase<Entity.Location, ILocationRepository>, ILocationService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public LocationService(
            ILocationRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public LocationExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Location>, LocationExposeCollection>(all);
            return col;

        }

        public LocationExpose CreateLocation(string name)
        {
            var jobTitle = Entity.Location.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetLocation(name);
            return Mapper.Map<Entity.Location, LocationExpose>(jobTitle);
        }

    }
    #endregion

    #region Location Expose Mapping
    public class LocationExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }

        #endregion
    }

    public class LocationExposeCollection
    {
        public LocationExposeCollection()
        {
            Data = new List<LocationExpose>();
        }

        public List<LocationExpose> Data { get; set; }
    }

    public class LocationExposeMapping : Profile
    {
        public LocationExposeMapping()
        {
            CreateMap<Entity.Location, LocationExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;

            CreateMap<IEnumerable<Entity.Location>, LocationExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Entity.Location, LocationExpose>(entry));
                    }

                });

        }
    }
    #endregion
}
