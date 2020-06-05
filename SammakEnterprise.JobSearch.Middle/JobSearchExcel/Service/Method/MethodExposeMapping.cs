using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System.Collections.Generic;
using JobSearchExcelEntity = SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service.Method
{
    public class MethodExpose : EntityExpose
    {
        #region Properties

        public string Name { get; set; }

        #endregion
    }

    public class MethodExposeCollection
    {
        public MethodExposeCollection()
        {
            Data = new List<MethodExpose>();
        }

        public List<MethodExpose> Data { get; set; }
    }

    public class MethodExposeMapping : Profile
    {
        public MethodExposeMapping()
        {
            CreateMap<JobSearchExcelEntity.Method, MethodExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;

            CreateMap<IEnumerable<JobSearchExcelEntity.Method>, MethodExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchExcelEntity.Method, MethodExpose>(entry));
                    }

                });

        }

    }
}
