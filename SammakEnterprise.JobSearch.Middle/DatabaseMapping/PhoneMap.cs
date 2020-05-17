using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Phone
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{PhoneMap}" />
    internal class PhoneMap : SubclassMap<Entities.Phone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Phone"/> class.
        /// </summary>
        public PhoneMap()
        {
            Schema(Name);
            Table(PhoneTable.Name);

            // indicates that the base class is abstract
            Abstract();

            Map(x => x.CountryCode)
                .Column(PhoneTable.Column.CountryCode)
                .Not.Nullable();

            Map(x => x.AreaCode)
                .Column(PhoneTable.Column.AreaCode)
                .Not.Nullable();

            Map(x => x.Number)
                .Column(PhoneTable.Column.Number)
                .Not.Nullable()
                .Length(40);

            Map(x => x.Extension)
                .Column(PhoneTable.Column.Extension)
                .Length(10);

            Map(x => x.PhoneType)
                .Column(PhoneTable.Column.PhoneType)
                .Not.Nullable()
                .Length(40);

        }
    }
}
