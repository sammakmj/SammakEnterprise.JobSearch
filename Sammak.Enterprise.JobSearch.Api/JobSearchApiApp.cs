using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Configuration;

namespace SammakEnterprise.JobSearch.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class JobSearchApiApp
    {
        /// <summary>
        /// The HangFire logger
        /// </summary>
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The owin web application
        /// </summary>
        protected IDisposable WebApplication;

        /// <summary>
        /// Start MemberApi Host Server
        /// </summary>
        public virtual void Start()
        {
            try
            {
                Logger.Info($"Starting {Resources.Constants.AppInfo.DisplayName}");

                WebApplication = WebApp.Start<Startup.Startup>(ConfigurationManager.AppSettings["OwinUrl"]);

                Logger.Info($"{Resources.Constants.AppInfo.DisplayName} Started");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error in {Resources.Constants.AppInfo.DisplayName} Start");
            }
        }

        /// <summary>
        /// Method to stop the application.
        /// </summary>
        public virtual void Stop()
        {
            WebApplication.Dispose();
            Logger.Info($"{Resources.Constants.AppInfo.DisplayName} Stopped");
        }

        /// <summary>
        /// Method to pause the application.
        /// </summary>
        public virtual void Pause()
        {
            Logger.Info($"{Resources.Constants.AppInfo.DisplayName} Paused");
        }

        /// <summary>
        /// Method to continue the application.
        /// </summary>
        public virtual void Continue()
        {
            Logger.Info($"{Resources.Constants.AppInfo.DisplayName} Now Running");
        }

        /// <summary>
        /// Method to shut down the application.
        /// </summary>
        public virtual void Shutdown()
        {
            Logger.Info($"{Resources.Constants.AppInfo.DisplayName} Shutdown Completed.");
        }

    }
}
