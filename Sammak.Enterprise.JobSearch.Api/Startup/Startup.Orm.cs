using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Caches.Redis;
using NHibernate.Tool.hbm2ddl;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.JobSearch.Api.Util;
using SammakEnterprise.JobSearch.Middle.Repository.Employee;
using SammakEnterprise.JobSearch.Middle.Entities;
using System.Diagnostics;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        /// <summary>
        /// Gets or sets the session factory.
        /// </summary>
        /// <value>
        /// The session factory.
        /// </value>
        public static ISessionFactory SessionFactory { get; set; }

        /// <summary>
        /// Configures object-relational mapping.
        /// </summary>
        /// <returns></returns>
        internal static ISessionFactory ConfigureOrm()
        {

            //Logger.Trace("ConfigureOrm: Initializing NHibernate Profiler");
            //NHibernateProfiler.Initialize();
            Logger.Trace("ConfigureOrm: Initializing NHibernate.");

            if (SessionFactory != null) return SessionFactory;

            //bool useCache = (new Feature_RedisCache()).FeatureEnabled;
            //if (useCache) UseOrmCache();

            var connStr = ConfigurationManager.ConnectionStrings["SammakDB"].ConnectionString;
            Debug.Assert(null != connStr);

            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                //.ShowSql()    
                .ConnectionString(connStr))
                    
                .Cache(c => SetupCacheSettingsBuilder(c))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuditData>())
                .Mappings(m => m.HbmMappings.AddFromAssemblyOf<IEmployeeRepository>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();

            Logger.Trace("ConfigureOrm: Finished initializing NHibernate.");
            return SessionFactory;
        }

        private static void SetupCacheSettingsBuilder(CacheSettingsBuilder c)
        {
            c = c.UseQueryCache().UseSecondLevelCache();

            bool useCache = (new Feature_RedisCache()).FeatureEnabled;
            if (useCache) c = c.ProviderClass<RedisCacheProvider>();
        }
    }

}
