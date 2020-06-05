using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System.Collections.Generic;
using JobSearchExcelEntity = SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service.JobTitle
{
    public class JobTitleExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }

        #endregion
    }

    public class JobTitleExposeCollection
    {
        public JobTitleExposeCollection()
        {
            Data = new List<JobTitleExpose>();
        }

        public List<JobTitleExpose> Data { get; set; }
    }

    public class JobTitleExposeMapping : Profile
    {
        public JobTitleExposeMapping()
        {
            CreateMap<JobSearchExcelEntity.JobTitle, JobTitleExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;

            CreateMap<IEnumerable<JobSearchExcelEntity.JobTitle>, JobTitleExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchExcelEntity.JobTitle, JobTitleExpose>(entry));
                    }

                });

        }

    }
}
