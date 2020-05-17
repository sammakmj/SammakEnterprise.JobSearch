using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using JobSearchAccessEntity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.JobSearch
{
    public class JobSearchExpose
    {
        #region Properties

        public DateTime InitialDate { get; set; }

        public string JobTitle { get; set; }

        public string ApproachMethod { get; set; }

        public string RecruiterName { get; set; }

        public string EmployerName { get; set; }

        public bool HasStatuses { get; set; }

        #endregion

    }

    public class JobSearchExposeCollection
    {
        public JobSearchExposeCollection()
        {
            Data = new List<JobSearchExpose>();
        }

        public List<JobSearchExpose> Data { get; set; }
    }

    public class JobSearchExposeMapping : Profile
    {
        public JobSearchExposeMapping()
        {
            CreateMap<JobSearchAccessEntity.JobSearch, JobSearchExpose>(MemberList.Destination)
                .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.ApproachMethod, opt => opt.MapFrom(src => src.ApproachMethod))
                .ForMember(dest => dest.HasStatuses, opt => opt.MapFrom(src => src.Statuses != null && src.Statuses.Count > 0))
                .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.Recruiter))
                .ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.Employer))
                ;

            CreateMap<IEnumerable<JobSearchAccessEntity.JobSearch>, JobSearchExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchAccessEntity.JobSearch, JobSearchExpose>(entry));
                    }

                });

        }

    }
}
