using AutoMapper;
using Owin;
using SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Agency;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        /// <summary>
        /// Configures AutoMapper.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseMappings(IAppBuilder app)
        {
            Mapper.Initialize(cfg =>
            {
                // TODO: Remember to add a  mapping code line for each exposed entity object
                // found a better solution with Automapper ver 6.2 and later; just get one Profile class and use AddProfiles
                cfg.AddProfiles(typeof(AgencyExposeMapping));
            });

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }
    }
}