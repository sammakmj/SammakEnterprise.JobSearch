using System;
using NLog;
using SammakEnterprise.JobSearch.Api.Extensions;
using Topshelf;

namespace SammakEnterprise.JobSearch.Api
{
    internal class Program
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += ExceptionHandler;

            var config = System.Configuration.ConfigurationManager.AppSettings;
            var exitCode = HostFactory.Run(host =>
            {
                host.SetDescription(Resources.Constants.AppInfo.Description);
                host.SetDisplayName(Resources.Constants.AppInfo.DisplayName);
                host.SetServiceName(Resources.Constants.AppInfo.AssemblyName);
                host.StartAutomatically();
                host.UseNLog();

                host.BeforeInstall(() =>
                {
                    Log.Info("Beginning Install");
                });
                host.AfterInstall(() =>
                {
                    Log.Info("Completed Install");
                });
                host.BeforeRollback(() =>
                {
                    Log.Info("Beginning Rollback");
                });
                host.AfterRollback(() =>
                {
                    Log.Info("Completed Rollback");
                });
                host.BeforeUninstall(() =>
                {
                    Log.Info("Beginning Uninstall");
                });
                host.AfterUninstall(() =>
                {
                    Log.Info("Completed Uninstall");
                });

                host.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                    rc.RestartService(3);
                    rc.RestartService(5);
                });

                host.Service<JobSearchApiApp>(service =>
                {
                    service.ConstructUsing(() => new JobSearchApiApp());
                    service.WhenStarted(a => a.Start());
                    service.WhenStopped(a => a.Stop());
                    service.WhenPaused(s => s.Pause());
                    service.WhenContinued(s => s.Continue());
                    service.WhenShutdown(s => s.Shutdown());
                });
            });

            Environment.Exit((int)exitCode);
        }

        /// <summary>
        /// Exceptions the handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var e = args.ExceptionObject as Exception;
            if (e == null)
            {
                Log.Error("This exception was not an exception");
            }
            else
            {
                Log.Error(e.Stringify());
            }
        }

        const string INDENT = "   ";

        static void ShowException(Exception ex, string indent)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"{indent}Exception Message: {ex.Message}");
                Console.WriteLine($"{indent}Exception Type: {ex.GetType().Name.ToString()}");
                Console.WriteLine($"{indent}Exception Source: {ex.Source}");

                // format the stack trace string items and indent them accoring to the exception level
                var stackTrace = ex.StackTrace;
                var separators = new string[] {"\n", "\r\n"};
                var myList = stackTrace.Split(separators, StringSplitOptions.None);
                Console.WriteLine($"{indent}Stack Trace:");
                foreach (var item in myList)
                {
                    Console.WriteLine($"{indent}{item}");
                }

                // recursively display the inner exceptions, if any
                if (ex.InnerException == null)
                    return;

                Console.Write($"{indent}Inner Exception:");
                ex = ex.InnerException;
                indent += INDENT;
            }
        }
    }
}
