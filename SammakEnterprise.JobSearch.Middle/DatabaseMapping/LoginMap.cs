using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Login
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{LoginMap}" />
    internal class LoginMap : ComponentMap<Entities.Login>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Login"/> class.
        /// </summary>
        public LoginMap()
        {
            Map(x => x.UserName)
                .Column(LoginTable.Column.UserName)
                .Length(40);

            Map(x => x.Password)
                .Column(LoginTable.Column.Password)
                .Length(40);

            Map(x => x.Url)
                .Column(LoginTable.Column.Url)
                .Length(512);

        }
    }
}
