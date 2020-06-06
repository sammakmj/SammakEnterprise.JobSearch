using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearchExcel.Middle.Common;
using System;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity
{
    public class Activity : DomainBase<Activity>
    {
        #region Properties

        /// <summary>
        ///  property ActivityDate of the Activity Entity class
        /// </summary>
        public virtual DateTime ActivityDate { get; protected internal set; }

        /// <summary>
        ///  property ActivityNote of the Activity Entity class
        /// </summary>
        public virtual string ActivityNote { get; protected internal set; }

        /// <summary>
        ///  property PhoneInterview of the Activity Entity class
        /// </summary>
        public virtual bool PhoneInterview { get; protected internal set; }

        /// <summary>
        ///  property FaceToFaceInterview of the Activity Entity class
        /// </summary>
        public virtual bool FaceToFaceInterview { get; protected internal set; }

        /// <summary>
        ///  property TestInterview of the Activity Entity class
        /// </summary>
        public virtual bool TestInterview { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        protected Activity()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Activity Create(
            DateTime activityDate,
            string activityNote,
            string createdBy = null)
        {
                createdBy = createdBy ?? Common.Utilities.DefaultUser();
                var entity = new Activity
                {
                    ActivityDate = activityDate,
                    ActivityNote = activityNote,
                    FaceToFaceInterview = false,
                    PhoneInterview = false,
                    TestInterview = false,
                    AuditData = AuditData.Create(createdBy)
                };

                return entity;
            }

        #endregion

            #region Object Override Methods

            /// <summary>
            /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
            /// <returns>
            ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
            /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as Activity;
            if (null == other)
                return false;

            return
                ActivityDate == other.ActivityDate &&
                ActivityNote == other.ActivityNote;
        }

        public override int GetHashCode()
        {
            const int hashSeed = 486187739;  // a large prime number
            unchecked // Overflow is fine, just wrap
            {
                int hash = hashSeed;
                hash = hash * hashSeed + base.GetHashCode();
                hash = hash * hashSeed + ActivityDate.GetHashCode();
                hash = hash * hashSeed + ActivityNote.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"Job Status: {ActivityDate: MM dd, yyyy}: {ActivityNote}";
            return result;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class JobStatusValidator : ValidatorBase<Activity>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public JobStatusValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.ActivityDate)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.ActivityTable.Column.ActivityDate} is required");
                RuleFor(x => x.ActivityNote)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.ActivityTable.Column.ActivityNote} is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }
    internal sealed class JobStatusMap : ClassMap<Activity>
    {
        public JobStatusMap()
        {
            Schema(Constants.JobSearchExcelSchema.SchemaName);
            Table(Constants.JobSearchExcelSchema.ActivityTable.TableName);

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
                .Not.Nullable()
                .Index(Constants.AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Unique();

            Map(x => x.ActivityDate)
                .Column(Constants.JobSearchExcelSchema.ActivityTable.Column.ActivityDate);

            Map(x => x.ActivityNote)
                .Column(Constants.JobSearchExcelSchema.ActivityTable.Column.ActivityNote);

            Map(x => x.PhoneInterview)
                .CustomSqlType("BIT")
                .Column(Constants.JobSearchExcelSchema.ActivityTable.Column.PhoneInterview);

            Map(x => x.FaceToFaceInterview)
                .CustomSqlType("BIT")
                .Column(Constants.JobSearchExcelSchema.ActivityTable.Column.FaceToFaceInterview);

            Map(x => x.TestInterview)
                .CustomSqlType("BIT")
                .Column(Constants.JobSearchExcelSchema.ActivityTable.Column.TestInterview);

            Component(x => x.AuditData);
        }
    }

}
