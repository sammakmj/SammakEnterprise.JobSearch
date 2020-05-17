using FluentNHibernate.Mapping;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.Company
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.SubclassMap{Company}" />
    internal class CompanyMap : SubclassMap<Entities.Company>
    {
        public CompanyMap()
        {
            Schema(Name);
            Table(CompanyTable.Name);

            // indicates that the base class is abstract
            Abstract();

            Map(x => x.Employers_EmployerId);
            Map(x => x.Agencies_AgencyId);

            Map(x => x.Name)
                .Column(CompanyTable.Column.Name)
                .Not.Nullable()
                //.Index(CompanyTable.Index.Company_Name)
                .Unique()
                .Length(80);

            Map(x => x.Description)
                .Column(CompanyTable.Column.Description)
                .Length(512);

            Map(x => x.WebSite)
                .Column(CompanyTable.Column.WebSite);

            Map(x => x.ApplicationDate)
                .Column(CompanyTable.Column.ApplicationDate);

            References(x => x.HiringManager)
                .Column(CompanyTable.Column.HiringManagerId);

            References(x => x.Phone)
                .Column(CompanyTable.Column.PhoneId);

            References(x => x.Contact)
                .Column(CompanyTable.Column.PhoneId);

            Component(x => x.EmailAddress);

            Component(x => x.Address);

            Component(x => x.Login);

            HasMany(x => x.Employees)
                .KeyColumns.Add(EmployeeTable.Column.CompanyId)
                .AsBag()
                .Cascade.All();

            HasMany(x => x.Approaches)
                .KeyColumns.Add(ApproachTable.Column.CompanyId)
                .AsBag()
                .Cascade.All();

        }
    }
}
