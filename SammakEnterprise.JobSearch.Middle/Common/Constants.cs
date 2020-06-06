namespace SammakEnterprise.JobSearchExcel.Middle.Common
{
    internal static class Constants
    {
        #region SQL common defines

        /// <summary>
        /// database common sql type defines
        /// </summary>
        public class SqlType
        {
            public static string Nvarchar = "nvarchar";
            public static string VarBinaryMax = "varbinary(max)";
            public static string Date = "Date";
        }

        #endregion

        #region Defines for Any Entity Tables

        /// <summary>
        ///  table and column info
        /// </summary>
        public class AnyEntityTables
        {
            /// <summary>
            /// The column names defines
            /// </summary>
            public class Column
            {
                public static string Id = "Id";
                public static string ExternalId = "ExternalId";
            }

            /// <summary>
            /// The Index names defines
            /// </summary>
            public class Index
            {
                public static string BaseEntityDbDef_ExternalId = "NCK_BaseEntityDbDef_ExternalId";
            }
        }

        #endregion

        #region JobSearchExcelSchema

        /// <summary>
        /// JobSearchExcel Schema name and tables
        /// </summary>
        public class JobSearchExcelSchema
        {
            /// <summary>
            /// The schema
            /// </summary>
            public static string SchemaName = "JobSearchExcel";

            #region Defines for the IdGenerator Table

            /// <summary>
            ///  table and column info
            /// </summary>
            public class IdGeneratorTable
            {
                public static string Name = "IdGenerator";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string MaxIdValue = "MaxIdValue";
                }

            }

            #endregion

            #region Defines for the Employer Table

            public class EmployerTable
            {
                public static string TableName = "Employer";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                    public static string WebSite = "WebSite";
                }

            }

            #endregion

            #region Defines for the JobTitle Table

            public class JobTitleTable
            {
                public static string TableName = "JobTitle";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                }

            }

            #endregion

            #region Defines for the Location Table

            public class LocationTable
            {
                public static string TableName = "Location";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                }

            }

            #endregion

            #region Defines for the Activity Table

            public class ActivityTable
            {
                public static string TableName = "Activity";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string ActivityDate = "ActivityDate";
                    public static string ActivityNote = "ActivityNote";
                    public static string PhoneInterview = "PhoneInterview";
                    public static string FaceToFaceInterview = "FaceToFaceInterview";
                    public static string TestInterview = "TestInterview";
                    public static string ApproachId = "ApproachId";
                }

            }

            #endregion

            #region Defines for the Method Table

            public class MethodTable
            {
                public static string TableName = "Method";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                }

            }

            #endregion

            #region Defines for the Agency Table

            public class AgencyTable
            {
                public static string TableName = "Agency";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                    public static string WebSite = "WebSite";
                }

            }

            #endregion

            #region Defines for the Agent Table

            public class AgentTable
            {
                public static string TableName = "Agent";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                    public static string Email = "Email";
                    public static string MobilePhone = "MobilePhone";
                    public static string OfficePhone = "OfficePhone";
                    public static string AgencyId = "AgencyId";
                }

            }

            #endregion

            #region Defines for the Approach Table

            public class ApproachTable
            {
                public static string TableName = "Approach";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string InitialDate = "InitialDate";
                    public static string AgentId = "AgentId";
                    public static string LocationId = "LocationId";
                    public static string MethodId = "MethodId";
                    public static string JobTitleId = "JobTitleId";
                    public static string EmployerId = "EmployerId";
                }

            }

            #endregion

        }

        #endregion JobSearchExcelSchema
    }
}
