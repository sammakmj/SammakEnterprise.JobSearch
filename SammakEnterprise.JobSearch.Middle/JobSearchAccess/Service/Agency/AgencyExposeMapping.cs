using AutoMapper;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using System.Collections.Generic;
using JobSearchAccessEntity = SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Agency
{
    public class AgencyExpose : EntityExpose
    {
        #region Properties

        public string AgencyName { get; set; }

        public string WebSite { get; set; }

        public IList<string> RecruiterNames { get; set; }

        #endregion
    }

    public class AgencyExposeCollection
    {
        public AgencyExposeCollection()
        {
            Data = new List<AgencyExpose>();
        }

        public List<AgencyExpose> Data { get; set; }
    }

    public class AgencyExposeMapping : Profile
    {
        public AgencyExposeMapping()
        {
            CreateMap<JobSearchAccessEntity.Agency, AgencyExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => src.AgencyName))
                .ForMember(dest => dest.WebSite, opt => opt.MapFrom(src => src.WebSite))
                .ForMember(dest => dest.RecruiterNames, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                {
                    //var urlHelper = context.Options.Items["UrlHelper"] as UrlHelper;

                    //dest.Links.Add(new Link("self", HttpVerbs.Get, urlHelper.Link(
                    //    ESAResourceConstants.ExamResponseApi.GetExamResponse.RoutName,
                    //    new Dictionary<string, object> { { "examResponseGuid", src.ExternalId } }
                    //)));
                    if (src.Recruiters != null && src.Recruiters.Count > 0)
                    {
                        dest.RecruiterNames = new List<string>();
                        foreach (var entry in src.Recruiters)
                        {
                            dest.RecruiterNames.Add(entry.RecruiterName);
                        }
                    }

                });

            CreateMap<IEnumerable<JobSearchAccessEntity.Agency>, AgencyExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<JobSearchAccessEntity.Agency, AgencyExpose>(entry));
                    }

                });

        }

    }
}
