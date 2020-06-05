using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System.Collections.Generic;
using JobSearchAccessEntity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Status
{
    public class StatusExpose : EntityExpose
    {
        #region Properties

        public string StatusDate { get; set; }

        public string Description { get; set; }

        public string RecruiterName { get; set; }

        public string EmployerName { get; set; }

        public bool InterviewF2F { get; set; }

        public bool InterviewPhone { get; set; }

        public bool OnlineTest { get; set; }

        #endregion
    }

    public class StatusExposeCollection
    {
        public StatusExposeCollection()
        {
            Data = new List<StatusExpose>();
        }

        public List<StatusExpose> Data { get; set; }
    }

    public class StatusExposeMapping : Profile
    {
        public StatusExposeMapping()
        {
            CreateMap<JobSearchAccessEntity.Status, StatusExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.StatusDate, opt => opt.MapFrom(src => src.StatusDate.ToString(Common.Utilities.DateFormat)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.InterviewF2F, opt => opt.MapFrom(src => src.InterviewF2F))
                .ForMember(dest => dest.InterviewPhone, opt => opt.MapFrom(src => src.InterviewPhone))
                .ForMember(dest => dest.OnlineTest, opt => opt.MapFrom(src => src.OnlineTest))

                .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.JobSearch.Recruiter))
                .ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.JobSearch.Employer))
                ;

            CreateMap<IEnumerable<JobSearchAccessEntity.Status>, StatusExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchAccessEntity.Status, StatusExpose>(entry));
                    }

                });

        }

    }
}
