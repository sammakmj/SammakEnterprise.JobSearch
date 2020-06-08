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

        public static class ActivityApi
        {
            public static class GetAll
            {
                public const string Rout = "activity";
                public const string RoutName = "Get All Activities";
            }
            public static class GetActivity
            {
                public const string Rout = "activity/{id:guid}";
                public const string RoutName = "Get Activity By Id";
            }
            public static class CreateActivity
            {
                public const string Rout = "activity/{name}";
                public const string RoutName = "Create a new Activity";
            }
        }

        public static class EmployerApi
        {
            public static class GetAll
            {
                public const string Rout = "employer";
                public const string RoutName = "Get All Employers";
            }
            public static class GetEmployer
            {
                public const string Rout = "employer/{id:guid}";
                public const string RoutName = "Get Employer By Id";
            }
            public static class CreateEmployer
            {
                public const string Rout = "employer/{name}";
                public const string RoutName = "Create a new Employer";
            }
        }

        public static class AgencyApi
        {
            public static class GetAll
            {
                public const string Rout = "agency";
                public const string RoutName = "Get All Agencies";
            }
            public static class GetAgency
            {
                public const string Rout = "agency/{id:guid}";
                public const string RoutName = "Get Agency By Id";
            }
            public static class CreateAgency
            {
                public const string Rout = "agency/{name}";
                public const string RoutName = "Create a new Agency";
            }
        }

        public static class AgentApi
        {
            public static class GetAll
            {
                public const string Rout = "agent";
                public const string RoutName = "Get All Agents";
            }
            public static class GetAgent
            {
                public const string Rout = "agent/{id:guid}";
                public const string RoutName = "Get Agent By Id";
            }
            public static class CreateAgent
            {
                public const string Rout = "agent/{name}";
                public const string RoutName = "Create a new Agent";
            }
        }

        public static class LocationApi
        {
            public static class GetAll
            {
                public const string Rout = "location";
                public const string RoutName = "Get All locations";
            }
            public static class GetLocation
            {
                public const string Rout = "location/{id:guid}";
                public const string RoutName = "Get Job Location By Id";
            }
            public static class CreateLocation
            {
                public const string Rout = "location/{name}";
                public const string RoutName = "Create a new Job Location";
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

        public static class ApproachApi
        {
            public static class GetAll
            {
                public const string Rout = "approach";
                public const string RoutName = "Get All Job Approaches";
            }
            public static class GetApproach
            {
                public const string Rout = "approach/{id:guid}";
                public const string RoutName = "Get Job Approach By Id";
            }
            public static class CreateApproach
            {
                public const string Rout = "jobtitle/{name}";
                public const string RoutName = "Create a new Job Approach";
            }
        }

    }
}
