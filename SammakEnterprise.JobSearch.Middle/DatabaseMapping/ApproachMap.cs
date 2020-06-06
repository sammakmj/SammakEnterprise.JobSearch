using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Approach
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.SubclassMap{Approach}" />
    internal class ApproachMap : SubclassMap<Entities.ApproachOld>
    {
        public ApproachMap()
        {
            Schema(Name);
            Table(ApproachTable.Name);

            // indicates that the base class is abstract
            Abstract();

            Map(x => x.InitialDate)
                .Column(ApproachTable.Column.InitialDate);

            Map(x => x.JobTitle)
                .Column(ApproachTable.Column.JobTitle)
                .Length(80);

            Map(x => x.ApproachType)
                .Column(ApproachTable.Column.ApproachType);

            HasMany(x => x.ApproachStatuses)
                .KeyColumns.Add(ApproachStatusTable.Column.ApproachId)
                .AsBag()
                .Cascade.All();

        }
    }
}
