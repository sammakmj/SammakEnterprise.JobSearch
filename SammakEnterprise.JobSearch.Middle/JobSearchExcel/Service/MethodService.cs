using AutoMapper;
using SammakEnterprise.Core.Persistence.Services;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Common.Shared;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service
{
    #region Method Service Interface
    public interface IMethodService : IService<Entity.Method>
    {
        MethodExposeCollection GetAll();

        MethodExpose CreateMethod(string name);
    }
    #endregion

    #region Method Service Implementation
    public class MethodService : ServiceBase<Entity.Method, IMethodRepository>, IMethodService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodService"/> class.
        /// </summary>
        /// <param name="repository">The exam repo.</param>
        /// <param name="validationFactory">The exam repo.</param>
        public MethodService(
            IMethodRepository repository,
            IValidationFactory validationFactory)
            : base(repository, validationFactory)
        {
        }

        public MethodExposeCollection GetAll()
        {
            var all = Search();
            var col = Mapper.Map<IEnumerable<Entity.Method>, MethodExposeCollection>(all);
            return col;

        }

        public MethodExpose CreateMethod(string name)
        {
            var jobTitle = Entity.Method.Create(name);

            Repository.Add(jobTitle);

            jobTitle = Repository.GetMethod(name);
            return Mapper.Map<Entity.Method, MethodExpose>(jobTitle);
        }

    }
    #endregion

    #region Method Expose Mapping
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
            CreateMap<Entity.Method, MethodExpose>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;

            CreateMap<IEnumerable<Entity.Method>, MethodExposeCollection>(MemberList.Destination)
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
                        dest.Data.Add(Mapper.Map<Entity.Method, MethodExpose>(entry));
                    }

                });

        }
    }
    #endregion
}
