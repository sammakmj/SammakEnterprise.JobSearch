using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Employee
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.SubclassMap{EmployeeMap}" />
    internal class EmployeeMap : SubclassMap<Entities.Employee>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Employee"/> class.
        /// </summary>
        public EmployeeMap()
        {
            Schema(Name);
            Table(EmployeeTable.Name);

            // indicates that the base class is abstract
            Abstract();

            Map(x => x.Role)
                .Column(EmployeeTable.Column.Role)
                .Not.Nullable()
                .Length(40);

            Map(x => x.InitialContactDate)
                .Column(EmployeeTable.Column.InitialContactDate);

            HasMany(x => x.Approaches)
                .KeyColumns.Add(ApproachTable.Column.EmployeeId)
                .AsBag()
                .Cascade.All();

        }
    }
}
