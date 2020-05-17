using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Person
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{PersonMap}" />
    internal class PersonMap : SubclassMap<Entities.Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Person"/> class.
        /// </summary>
        public PersonMap()
        {
            // This class is the base one for the TPC (Table-Per-Concrete) inheritance strategy.
            // in indictes that the values of its properties should
            // be united with the values of derived classes
            Abstract();

            Map(x => x.FirstName)
                .Column(PersonTable.Column.FirstName)
                .Not.Nullable()
                .Length(40);

            Map(x => x.LastName)
                .Column(PersonTable.Column.LastName)
                .Length(40);

            Map(x => x.MobilePhone)
                .Column(PersonTable.Column.MobilePhone)
                .Length(40);

            Map(x => x.OfficePhone)
                .Column(PersonTable.Column.OfficePhone)
                .Length(40);

            Component(x => x.EmailAddress,
                part =>
                {
                    part.Map(y => y.Email, "Email");
                });

            HasMany(x => x.Phones)
                .KeyColumns.Add(PhoneTable.Column.PersonId)
                .AsBag()
                .Cascade.All();

        }
    }
}
