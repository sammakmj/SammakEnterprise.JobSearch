using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Address
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{AddressMap}" />
    internal class AddressMap : ComponentMap<Entities.Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Address"/> class.
        /// </summary>
        public AddressMap()
        {
            Map(x => x.StreetAddress)
                .Column(AddressTable.Column.StreetAddress)
                .Length(80);

            Map(x => x.City)
                .Column(AddressTable.Column.City)
                .Length(40);

            Map(x => x.State)
                .Column(AddressTable.Column.State)
                .Length(40);

            Map(x => x.ZipCode)
                .Column(AddressTable.Column.ZipCode)
                .Length(40);

        }
    }
}
