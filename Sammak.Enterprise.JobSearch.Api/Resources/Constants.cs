using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SammakEnterprise.JobSearch.Api.Resources
{
    public static class Constants
    {
        public struct AppInfo
        {
            public const string Version = "v1.0";
            public const string RoutePrefix = "api/" + Version;
            public const string AssemblyName = "SammakEnterprise.JobSearch.Api";
            public const string ProductName = "SammakEnterprise.JobSearch";
            public const string DisplayName = "Job Search API";
            public const string Company = "Sammak Enterprise.";
            public const string Description = "Microservice to handle the Job Search related functionalities.";
            public const string Copyright = "Copyright 2018 Sammak Enterprise.";
        }

        public static class AppInfoApi
        {
            public static class SystemInfo
            {
                public const string Rout = "system";
                public const string RoutName = "System Info";
            }

            public static class SystemInfoExt
            {
                public const string Rout = "system.{ext}";
                public const string RoutName = "System Info (with data format extension)";
            }

            public static class VersionInfo
            {
                public const string Rout = "system/version";
                public const string RoutName = "System Version Info";
            }

        }

        public static class EmployeeApi
        {
            public static class GetAll
            {
                public const string Rout = "employee";
                public const string RoutName = "Get All Employees";
            }
        }

        public static class JobTitleApi
        {
            public static class GetAll
            {
                public const string Rout = "jobtitle";
                public const string RoutName = "Get All Job Titles";
            }
            public static class GetJobTitle
            {
                public const string Rout = "jobtitle/{id:guid}";
                public const string RoutName = "Get Job Title By Id";
            }
            public static class CreateJobTitle
            {
                public const string Rout = "jobtitle/{name}";
                public const string RoutName = "Create a new Job Title";
            }
        }

        public static class MethodApi
        {
            public static class GetAll
            {
                public const string Rout = "method";
                public const string RoutName = "Get All Job Approach Methods";
            }
            public static class CreateMethod
            {
                public const string Rout = "method/{name}";
                public const string RoutName = "Create a new Job Approach Method";
            }
        }

    }
}
