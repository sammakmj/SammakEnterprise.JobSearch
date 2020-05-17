using CacheManager.Core;
using FluentValidation;
using NHibernate;
using SammakEnterprise.Core.Common.EnumDefinitions;
using SammakEnterprise.Core.Common.Infrastructure.Ioc;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Queries.Base;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.Core.Persistence.Validation.Impl;
using SammakEnterprise.JobSearch.Middle.Entities;
using SammakEnterprise.JobSearch.Middle.Services.Shared.Impl;
using StructureMap;
using StructureMap.Pipeline;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    /// <summary>
    /// Structuremap IOC Container Setup - PersonSync APP
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Gets or builds the container
        /// </summary>
        /// <returns></returns>
        public static IContainer EnsureIocSetUp()
        {
            if (DependencyResolver.Container == null && !_initializing)
                return UseIoc();
            return DependencyResolver.Container;
        }

        private static bool _initializing;

        /// <summary>
        /// Gets or sets the container (private).
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container { get; set; }

        /// <summary>
        /// Builds the container (private).
        /// </summary>
        /// <returns></returns>
        protected internal static IContainer UseIoc()
        {
            Logger.Trace("UseIoc: Initializing Container.");
            _initializing = true;

            try
            {
                Container = new Container(c =>
                {
                    c.For<System.Configuration.Abstractions.IConfigurationManager>()
                        .Use(() => ConfigurationManager);

                    c.Scan(s =>
                    {
                        s.TheCallingAssembly();
                        s.AssembliesFromApplicationBaseDirectory();
                        s.IncludeNamespace("SammakEnterprise.JobSearch.Middle");
                        s.LookForRegistries();
                        s.WithDefaultConventions();
                    });

                    c.For<ISessionFactory>().Singleton().Use(ConfigureOrm());
                    c.For<ISession>().LifecycleIs(new ThreadLocalStorageLifecycle()).Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
                    c.For<IValidationFactory>().Use<ValidationFactory>().Ctor<IContainer>("container").Is(DependencyResolver.Container);
                    c.For<IQueryFactory>().Use<QueryFactory>().Ctor<IContainer>("container").Is(DependencyResolver.Container);
                    c.For<IEnumService>().Singleton().Use<EnumService>();
                    c.For<IValidator<AuditData>>().Singleton().Use<AuditData.AuditDataValidator>();
                    c.For<ICacheManager<Person>>().Singleton().Use(d => CacheFactory.FromConfiguration<Person>("cache", UseServiceCacheManagement()));
                    //c.For<Core.MassTransit.IBusFactory>().Use<Core.MassTransit.BusFactory>();
                    //c.For<IAccessTokenService>().Singleton().Use<AccessTokenService>();
                    //c.For<IBackgroundJobClient>().Use<BackgroundJobClient>();

                    AssemblyScanner.FindValidatorsInAssemblyContaining<Person.PersonValidator>()
                        .ForEach(r =>
                        {
                            c.For(r.InterfaceType)
                                .Singleton()
                                .Use(r.ValidatorType);
                        });
                });
                DependencyResolver.Container = Container;
            }
            finally
            {
                _initializing = false;
            }
            Logger.Trace("UseIoc: Container initialized.");
            return Container;
        }
    }
}
