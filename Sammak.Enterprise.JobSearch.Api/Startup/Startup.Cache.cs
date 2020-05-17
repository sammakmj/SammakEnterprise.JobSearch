using CacheManager.Core;
using StackExchange.Redis;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        /// <summary>
        /// UseServiceCacheManagement method.
        /// </summary>
        /// <returns></returns>
        public static ICacheManagerConfiguration UseServiceCacheManagement()
        {
            Logger.Trace("UseServiceCacheManagement: Initializing cache.");

            var cfg = new System.Configuration.Abstractions.ConfigurationManager();

            var config = ConfigurationBuilder.BuildConfiguration(settings =>
            {
                settings.WithSystemRuntimeCacheHandle("inprocess")
                .And
                .WithRedisConfiguration("redis", c =>
                {
                    c.WithAllowAdmin()
                        .WithDatabase(0)
                        .WithEndpoint(cfg.AppSettings["Redis.Host"], int.Parse(cfg.AppSettings["Redis.Port"]));
                })
                .WithMaxRetries(100)
                .WithRetryTimeout(50)
                .WithRedisBackplane("redis")
                .WithRedisCacheHandle("redis", true);
            });

            Logger.Trace("UseServiceCacheManagement: Cache Initialized.");
            return config;
        }

        ///// <summary>
        ///// UseOrmCache method.
        ///// </summary>
        //public static void UseOrmCache()
        //{
        //    var cfg = new System.Configuration.Abstractions.ConfigurationManager();
        //    var connectionMultiplexer = StackExchange.Redis.ConnectionMultiplexer.Connect("localhost:32768,allowAdmin=true");

        //    connectionMultiplexer.GetServer(cfg.AppSettings["Redis.Host"], int.Parse(cfg.AppSettings["Redis.Port"])).FlushAllDatabases();

        //    RedisCacheProvider.SetConnectionMultiplexer(connectionMultiplexer);
        //    RedisCacheProvider.SetOptions(new RedisCacheProviderOptions()
        //    {
        //        Serializer = new NetDataContractCacheSerializer()
        //    });

        //    //TODO: Dispose connectionMultiplexor on application exit.
        //}
    }
}
