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

        }

        #endregion JobSearchExcelSchema
    }
}
