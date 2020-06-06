using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System;
using System.Collections.Generic;
using JobSearchAccessEntity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Employer
{
    public class EmployerExpose : EntityExpose
    {
        #region Properties

        public string EmployerName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string EmployerWebSite { get; set; }

        public string EmployerContact { get; set; }

        public string HiringManager { get; set; }

        public DateTime ApplicationDate { get; set; }

        public bool HasBeenApproached { get; set; }

        public string UserName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

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
            CreateMap<JobSearchAccessEntity.HiringCompany, EmployerExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.EmployerName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmployerWebSite, opt => opt.MapFrom(src => src.EmployerWebSite))
                .ForMember(dest => dest.EmployerContact, opt => opt.MapFrom(src => src.EmployerContact))
                .ForMember(dest => dest.HiringManager, opt => opt.MapFrom(src => src.HiringManager))
                .ForMember(dest => dest.ApplicationDate, opt => opt.MapFrom(src => src.ApplicationDate))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip))
                .ForMember(dest => dest.HasBeenApproached, opt => opt.MapFrom(src => src.JobSearches != null && src.JobSearches.Count > 0))
                ;

            CreateMap<IEnumerable<JobSearchAccessEntity.HiringCompany>, EmployerExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchAccessEntity.HiringCompany, EmployerExpose>(entry));
                    }

                });

        }

    }
}
