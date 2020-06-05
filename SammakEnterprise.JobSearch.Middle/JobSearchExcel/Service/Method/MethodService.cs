using SammakEnterprise.Core.Persistence.Services;
using AutoMapper;
using SammakEnterprise.Core.Persistence.Services.Impl;
using SammakEnterprise.Core.Persistence.Validation;
using System.Collections.Generic;
using SammakEnterprise.JobSearch.Middle.JobSearchExcel.Repository;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Service.Method
{
    #region Interface
    public interface IMethodService : IService<Middle.JobSearchExcel.Entity.Method>
    {
        MethodExposeCollection GetAll();

        MethodExpose CreateMethod(string name);
    }
    #endregion

    #region Implementation
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

}
