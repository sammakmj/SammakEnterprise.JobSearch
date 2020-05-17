using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using NLog;
using Owin;

namespace SammakEnterprise.JobSearch.Api.Startup
{
    /// <summary>
    /// Startup and Configuration for the SammakEnterprise.JobSearch.Api
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// A development flag. Will be false in production
        /// </summary>
        protected static readonly bool IsDevelopment;

        /// <summary>
        /// The logger
        /// </summary>
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        static Startup()
        {
#if DEBUG
            IsDevelopment = true;
#endif
        }

        /// <summary>
        /// Configurations the application.
        /// </summary>
        /// <param name="app">The application.</param>
        public virtual void Configuration(IAppBuilder app)
        {
            Logger.Debug("Configuration Initialized.");

            UseIoc();
            UseHttpConfig(app);
            UseFileServer(app);
            UseWelcomePage(app);
            UseErrorPage(app);
            UseMetrics(app);
            UseMappings(app);
            //UseServiceBus();
            //UseOwinHangfire(app);
            //UseIdentityClientConfig(app);
            //UseResourceAuthorization(app);
        }

        /// <summary>
        /// Uses the file server.
        /// </summary>
        /// <param name="app">The application.</param>
        protected static void UseFileServer(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                FileSystem = new PhysicalFileSystem(IsDevelopment ? "../../assets" : "assets"),
                RequestPath = new PathString("")
            });
        }

    }
}
