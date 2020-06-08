using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearchExcel.Middle.Common;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity
{
    public class Approach : DomainBase<Approach>
    {
        #region Protected variables

        protected readonly IList<Activity> _activities = new List<Activity>();

        #endregion

        #region Properties

        public virtual DateTime InitialDate { get; set; }

        protected internal virtual Agent Agent { get; set; }

        protected internal virtual Method Method { get; set; }

        protected internal virtual JobTitle JobTitle { get; set; }

        protected internal virtual Location Location { get; set; }

        protected internal virtual Employer Employer { get; set; }

        public virtual IList<Activity> Activities
        {
            get { return new List<Activity>(_activities); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Approach"/> class.
        /// </summary>
        protected Approach()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Approach Create(
            DateTime initialDate,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var approach = new Approach
            {
                InitialDate = initialDate,
                AuditData = AuditData.Create(createdBy)
            };

            return approach;
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
            var other = obj as Approach;
            if (null == other)
                return false;

            return
                InitialDate == other.InitialDate;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = Constants.HashSeed;
                hash = hash * Constants.HashSeed + base.GetHashCode();
                hash = InitialDate == null ? hash : hash * Constants.HashSeed + InitialDate.GetHashCode();
                hash = Agent == null ? hash : hash * Constants.HashSeed + Agent.GetHashCode();
                hash = Method == null ? hash * Constants.HashSeed + Method.GetHashCode() : hash;
                hash = Location == null ? hash : hash * Constants.HashSeed + Location.GetHashCode();
                hash = JobTitle == null ? hash : hash * Constants.HashSeed + JobTitle.GetHashCode();
                hash = Employer == null ? hash : hash * Constants.HashSeed + Employer.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{InitialDate:MMMM dd, yyyy}";
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class ApproachValidator : ValidatorBase<Approach>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public ApproachValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.InitialDate)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.ApproachTable.Column.InitialDate} is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }
    internal sealed class ApproachMap : ClassMap<Approach>
    {
        public ApproachMap()
        {
            Schema(Constants.JobSearchExcelSchema.SchemaName);
            Table(Constants.JobSearchExcelSchema.ApproachTable.TableName);

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
                .Not.Nullable()
                .Index(Constants.AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Generated.Insert()
                .ReadOnly()
                .Unique()
                .Not.Nullable();

            Map(x => x.InitialDate)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.InitialDate);

            References(x => x.Agent)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.AgentId)
                .Cascade.All();

            References(x => x.Employer)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.EmployerId)
                .Cascade.All();

            References(x => x.JobTitle)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.JobTitleId)
                .Cascade.All();

            References(x => x.Location)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.LocationId)
                .Cascade.All();

            References(x => x.Method)
                .Column(Constants.JobSearchExcelSchema.ApproachTable.Column.MethodId)
                .Cascade.All();

            HasMany(x => x.Activities)
                .KeyColumns.Add(Constants.JobSearchExcelSchema.ActivityTable.Column.ApproachId)
                .AsBag()
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }

}
