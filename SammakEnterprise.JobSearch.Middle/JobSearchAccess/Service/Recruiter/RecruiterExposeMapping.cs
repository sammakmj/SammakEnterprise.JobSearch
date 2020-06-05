using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System;
using System.Collections.Generic;
using JobSearchAccessEntity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Recruiter
{
    public class RecruiterExpose : EntityExpose
    {
        #region Properties

        public string RecruiterName { get; set; }

        public string AgencyName { get; set; }

        public DateTime InitialContactDate { get; set; }

        public bool HasJobSearches { get; set; }

        public string RecruiterOfficePhone { get; set; }

        public string RecruiterMobilePhone { get; set; }

        public string RecruiterEmail { get; set; }

        #endregion

    }

    public class RecruiterExposeCollection
    {
        public RecruiterExposeCollection()
        {
            Data = new List<RecruiterExpose>();
        }

        public List<RecruiterExpose> Data { get; set; }
    }

    public class RecruiterExposeMapping : Profile
    {
        public RecruiterExposeMapping()
        {
            CreateMap<JobSearchAccessEntity.Recruiter, RecruiterExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.RecruiterName))
                .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.Agency))
                .ForMember(dest => dest.RecruiterEmail, opt => opt.MapFrom(src => src.RecruiterEmail))
                .ForMember(dest => dest.HasJobSearches, opt => opt.MapFrom(src => src.JobSearches != null && src.JobSearches.Count > 0))
                .ForMember(dest => dest.InitialContactDate, opt => opt.MapFrom(src => src.InitialContactDate))
                .ForMember(dest => dest.RecruiterMobilePhone, opt => opt.MapFrom(src => src.RecruiterMobilePhone))
                .ForMember(dest => dest.RecruiterOfficePhone, opt => opt.MapFrom(src => src.RecruiterOfficePhone))
                ;

            CreateMap<IEnumerable<JobSearchAccessEntity.Recruiter>, RecruiterExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchAccessEntity.Recruiter, RecruiterExpose>(entry));
                    }

                });

        }

    }
}
