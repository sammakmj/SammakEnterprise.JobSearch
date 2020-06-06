using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{DomainBaseMap}" />
    internal class DomainBaseMap : ClassMap<Core.Persistence.Domain.DomainBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Core.Persistence.Domain.DomainBase"/> class.
        /// </summary>
        public DomainBaseMap()
        {
            Schema(Name);

            // This class is the base one for the TPC (Table-Per-Concrete) inheritance strategy.
            // in indictes that the values of its properties should
            // be united with the values of derived classes
            UseUnionSubclassForInheritanceMapping();

            Id(x => x.Id)
                .Column(AnyEntityTables.Column.Id)
                .Not.Nullable()
                .GeneratedBy.HiLo(IdGeneratorTable.Name, IdGeneratorTable.Column.MaxIdValue, "0")
                .Unique();

            Map(x => x.ExternalId)
                .Column(AnyEntityTables.Column.ExternalId)
              .Not.Nullable()
                //.Index(AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Unique();

            Component(x => x.AuditData);

        }
    }
    public class IdGenerationConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.HiLo("MyTableName", "NextHighValue", "1000");
        }
    }
}
