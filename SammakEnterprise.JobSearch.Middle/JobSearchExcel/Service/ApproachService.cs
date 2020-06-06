using AutoMapper;
using FluentNHibernate.Utils;
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
    #region ApproachService Interface
    public interface IApproachService : IService<Entity.Approach>
    {
        ApproachExposeCollection GetAll();

        ApproachExpose GetById(Guid id);

        ApproachExpose CreateApproach(DateTime approachDate);
    }
    #endregion

    #region ApproachService Implementation
    public class ApproachService : EntityService<Entity.Approach, IApproachRepository>, IApproachService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproachService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public ApproachService(
            IApproachRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public ApproachExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Approach>, ApproachExposeCollection>(all);
            return col;

        }

        public ApproachExpose GetById(Guid id)
        {
            var approach = Load(id);
            var output = Mapper.Map<Entity.Approach, ApproachExpose>(approach);
            return output;

        }

        public ApproachExpose CreateApproach(DateTime approachDate)
        {
            return null;
            //var approach = Entity.Approach.Create(approachDate);

            //Repository.Add(approach);

            //approach = Repository.GetApproach(approachDate);
            //return Mapper.Map<Entity.Approach, ApproachExpose>(approach);
        }

    }
    #endregion

    #region Approach Expose Mapping
    public class ApproachExpose : EntityExpose
    {
        #region Properties

        public DateTime InitialDate { get; set; }

        #endregion
    }

    public class ApproachExposeCollection
    {
        public ApproachExposeCollection()
        {
            Data = new List<ApproachExpose>();
        }

        public List<ApproachExpose> Data { get; set; }
    }

    public class ApproachExposeMapping : Profile
    {
        public ApproachExposeMapping()
        {
            CreateMap<Approach, ApproachExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                ;

            CreateMap<IEnumerable<Approach>, ApproachExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Approach, ApproachExpose>(entry));
                    }

                }
            );
        }

    }
    #endregion
}
