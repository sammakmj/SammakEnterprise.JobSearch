using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.EmailAddress
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{EmailAddress}" />
    internal class EmailAddressMap : ComponentMap<Entities.EmailAddress>
    {
        public EmailAddressMap()
        {
            Map(x => x.Email)
                .Column(EmailAddressTable.Column.Email)
                .Length(80);

        }
    }
}
