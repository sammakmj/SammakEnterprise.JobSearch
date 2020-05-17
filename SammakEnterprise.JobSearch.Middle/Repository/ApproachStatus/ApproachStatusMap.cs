using FluentNHibernate.Mapping;
//using static SammakEnterprise.JobSearch.Middle.Data.Repository.DatabaseMapping.DbConstants.JobSearchSchema;
//using static SammakEnterprise.JobSearch.Middle.Data.Repository.DbConstants.JobSearchSchema;
using static SammakEnterprise.JobSearch.Middle.DatabaseMapping.DbConstants.JobSearchSchema;

namespace SammakEnterprise.JobSearch.Middle.Data.Repository.Login
{
    /// <summary>
    /// FluentNHibernate class mapping file for ExamResponse objects
    /// </summary>
    /// <seealso cref="FluentNHibernate.Mapping.ClassMap{ApproachStatus}" />
    internal class ApproachStatusMap : SubclassMap<Entities.ApproachStatus>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entities.Login"/> class.
        /// </summary>
        public ApproachStatusMap()
        {
            Schema(Name);
            Table(ApproachStatusTable.Name);

            // indicates that the base class is abstract
            Abstract();

            Map(x => x.ActivityDate)
                .Column(ApproachStatusTable.Column.ActivityDate)
                .Not.Nullable();

            Map(x => x.ActivityNote)
                .Column(ApproachStatusTable.Column.ActivityNote)
                .Not.Nullable();

            Map(x => x.FaceToFaceInterview)
                .Column(ApproachStatusTable.Column.FaceToFaceInterview);

            Map(x => x.PhoneInterview)
                .Column(ApproachStatusTable.Column.PhoneInterview);

            Map(x => x.OnlineTest)
                .Column(ApproachStatusTable.Column.OnlineTest);

        }
    }
}
