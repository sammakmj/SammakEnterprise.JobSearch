namespace SammakEnterprise.JobSearch.Middle.DatabaseMapping
{
    /// <summary>
    /// Database info constants class
    /// </summary>  
    internal static class DbConstants
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

        #region JobSearchSchema

        /// <summary>
        /// JobSearch Schema name and tables
        /// </summary>
        public class JobSearchSchema
        {
            /// <summary>
            /// The schema
            /// </summary>
            public static string Name = "JobSearch";

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

            #region Defines for the Person Table

            /// <summary>
            /// Person table and column info
            /// </summary>
            public class PersonTable
            {
                public static string Name = "Person";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string FirstName = "FirstName";
                    public static string LastName = "LastName";
                    public static string EmailAddressId = "EmailAddressId";
                    public static string OfficePhone = "OfficePhone";
                    public static string MobilePhone = "MobilePhone";
                }

            }

            #endregion

            #region Defines for the Phone Table

            /// <summary>
            /// Phone table and column info
            /// </summary>
            public class PhoneTable
            {
                public static string Name = "Phone";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string CountryCode = "CountryCode";
                    public static string AreaCode = "AreaCode";
                    public static string Number = "Number";
                    public static string Extension = "Extension";
                    public static string PhoneType = "PhoneType";
                    public static string PersonId = "PersonId";
                }

            }

            #endregion

            #region Defines for the Address Table

            /// <summary>
            /// Address table and column info
            /// </summary>
            public class AddressTable
            {
                public static string Name = "Address";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string StreetAddress = "StreetAddress";
                    public static string City = "City";
                    public static string State = "State";
                    public static string ZipCode = "ZipCode";
                }

            }

            #endregion

            #region Defines for the EmailAddress Table

            /// <summary>
            /// EmailAddress table and column info
            /// </summary>
            public class EmailAddressTable
            {
                public static string Name = "EmailAddress";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Email = "Email";
                }

            }

            #endregion

            #region Defines for the Login Table

            /// <summary>
            /// Login table and column info
            /// </summary>
            public class LoginTable
            {
                public static string Name = "Login";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string UserName = "UserName";
                    public static string Password = "Password";
                    public static string Url = "Url";
                }

            }

            #endregion

            #region Defines for the Company Table

            /// <summary>
            /// Company table and column info
            /// </summary>
            public class CompanyTable
            {
                public static string Name = "Company";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Name = "Name";
                    public static string Description = "Description";
                    public static string WebSite = "WebSite";
                    public static string ApplicationDate = "ApplicationDate";
                    public static string AddressId = "AddressId";
                    public static string LoginId = "LoginId";
                    public static string PhoneId = "PhoneId";
                    public static string ContactId = "ContactId";
                    public static string HiringManagerId = "HiringManagerId";
                }

            }

            #endregion

            #region Defines for the Employee Table

            /// <summary>
            /// Employee table and column info
            /// </summary>
            public class EmployeeTable
            {
                public static string Name = "Employee";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string Role = "Role";
                    public static string InitialContactDate = "InitialContactDate";
                    public static string CompanyId = "CompanyId";
                }

            }

            #endregion

            #region Defines for the Approach Table

            /// <summary>
            /// Approach table and column info
            /// </summary>
            public class ApproachTable
            {
                public static string Name = "Approach";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string InitialDate = "InitialDate";
                    public static string JobTitle = "JobTitle";
                    public static string TargetCompanyId = "TargetCompanyId";
                    public static string ApproachType = "ApproachType";
                    public static string EmployeeId = "EmployeeId";
                    public static string CompanyId = "CompanyId";
                }

            }

            #endregion

            #region Defines for the ApproachStatus Table

            /// <summary>
            /// ApproachStatus table and column info
            /// </summary>
            public class ApproachStatusTable
            {
                public static string Name = "ApproachStatus";

                /// <summary>
                /// The column names defines
                /// </summary>
                public class Column
                {
                    public static string ActivityDate = "ActivityDate";
                    public static string ActivityNote = "ActivityNote";
                    public static string FaceToFaceInterview = "FaceToFaceInterview";
                    public static string PhoneInterview = "PhoneInterview";
                    public static string OnlineTest = "OnlineTest";
                    public static string ApproachId = "ApproachId";
                }

            }

            #endregion

        }
        #endregion JobSearchSchema
    }
}
