using System.Configuration.Abstractions;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    public partial class Startup
    {
        /// <summary>
        /// The configuration manager
        /// </summary>
        private static ConfigurationManager _configurationManager;

        /// <summary>
        /// Before the Container has been created, other configs need to access this object to use it themselves
        /// </summary>
        /// <returns></returns>
        public static IConfigurationManager ConfigurationManager
        {
            get
            {
                if (_configurationManager == null)
                    _configurationManager = new ConfigurationManager();
                return _configurationManager;
            }
        }
    }
}
