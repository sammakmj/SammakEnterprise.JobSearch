using AutoMapper;
using SammakEnterprise.Core.Persistence.Services;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service
{
    #region Location Service Interface
    public interface ILocationService : IService<Location>
    {
        LocationExposeCollection GetAll();

        LocationExpose CreateLocation(string name);

        LocationExpose GetById(Guid id);
    }
    #endregion

    #region Location Service Implementation
    public class LocationService : ServiceBase<Location, ILocationRepository>, ILocationService
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
            var col = Mapper.Map<IEnumerable<Location>, LocationExposeCollection>(all);
            return col;

        }

        public LocationExpose CreateLocation(string name)
        {
            var jobTitle = Location.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetLocation(name);
            return Mapper.Map<Location, LocationExpose>(jobTitle);
        }

        public LocationExpose GetById(Guid id)
        {
            var location = Load(id);
            var output = Mapper.Map<Location, LocationExpose>(location);
            return output;
        }
    }
    #endregion

    #region Location Expose Mapping
    public class LocationExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }

        public List<ChildExpose> Approaches { get; set; }

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
            CreateMap<Location, LocationExpose>(MemberList.Destination)
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

            CreateMap<IEnumerable<Location>, LocationExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Location, LocationExpose>(entry));
                    }

                });

        }
    }
    #endregion
}
