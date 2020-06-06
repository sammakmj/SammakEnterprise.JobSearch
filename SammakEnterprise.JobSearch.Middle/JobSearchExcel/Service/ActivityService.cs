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
    #region ActivityService Interface
    public interface IActivityService : IService<Entity.Activity>
    {
        ActivityExposeCollection GetAll();

        ActivityExpose GetById(Guid id);

        ActivityExpose CreateActivity(DateTime activityDate);
    }
    #endregion

    #region ActivityService Implementation
    public class ActivityService : EntityService<Entity.Activity, IActivityRepository>, IActivityService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public ActivityService(
            IActivityRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public ActivityExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Activity>, ActivityExposeCollection>(all);
            return col;

        }

        public ActivityExpose GetById(Guid id)
        {
            var activity = Load(id);
            var output = Mapper.Map<Entity.Activity, ActivityExpose>(activity);
            return output;

        }

        public ActivityExpose CreateActivity(DateTime activityDate)
        {
            return null;
            //var activity = Entity.Activity.Create(activityDate);

            //Repository.Add(activity);

            //activity = Repository.GetActivity(activityDate);
            //return Mapper.Map<Entity.Activity, ActivityExpose>(activity);
        }

    }
    #endregion

    #region Activity Expose Mapping
    public class ActivityExpose : EntityExpose
    {
        #region Properties

        public DateTime ActivityDate { get; set; }

        #endregion
    }

    public class ActivityExposeCollection
    {
        public ActivityExposeCollection()
        {
            Data = new List<ActivityExpose>();
        }

        public List<ActivityExpose> Data { get; set; }
    }

    public class ActivityExposeMapping : Profile
    {
        public ActivityExposeMapping()
        {
            CreateMap<Activity, ActivityExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.ActivityDate, opt => opt.MapFrom(src => src.ActivityDate))
                ;

            CreateMap<IEnumerable<Activity>, ActivityExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Activity, ActivityExpose>(entry));
                    }

                }
            );
        }

    }
    #endregion
}
