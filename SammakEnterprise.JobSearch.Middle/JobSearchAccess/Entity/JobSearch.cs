using FluentValidation;
using SammakEnterprise.JobSearch.Middle.Enums;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using SammakEnterprise.Core.Persistence.Domain.Mapping.EnumerationMappings;
using SammakEnterprise.JobSearch.Middle.DatabaseMapping;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
{
    public class JobSearch : DomainBase<JobSearch>
    {
        #region Protected variables

        /// <summary>
        /// The list of <see cref="Employee"/> 
        /// </summary>
        protected readonly IList<Status> _statuses = new List<Status>();

        #endregion

        public virtual DateTime InitialDate { get; set; }

        public virtual string JobTitle { get; set; }

        public virtual ApproachTypeEntity ApproachMethod { get; set; }


        public virtual ApproachType? ApproachType { get; set; }

        public virtual Recruiter Recruiter { get; set; }

        public virtual Employer Employer { get; set; }

        public virtual IList<Status> Statuses => new List<Status>(_statuses);

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        protected JobSearch()
        {
            //ExternalId = Guid.NewGuid();
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JobSearch Create(
            DateTime initialDate,
            ApproachTypeEntity approachMethode, 
            string description,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new JobSearch
            {
                InitialDate = initialDate,
                ApproachMethod = approachMethode, 
                AuditData = AuditData.Create(createdBy)
            };

            return sp;
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
            var other = obj as JobSearch;
            if (null == other)
                return false;

            return
                InitialDate == other.InitialDate &&
                ApproachMethod == other.ApproachMethod;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var recruiterName = (Recruiter == null ? "None Assigned" : Recruiter.ToString());
            return $"InitialDate: {InitialDate.ToString(Common.Utilities.DateFormat)}, Recruiter: {recruiterName}, ApproachMethod: {ApproachMethod}";
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class JobSearchValidator : ValidatorBase<JobSearch>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public JobSearchValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.InitialDate)
                    .NotEmpty()
                    .WithMessage("InitialDate is required");

                RuleFor(x => x.ApproachMethod)
                    .NotEmpty()
                    .WithMessage("ApproachMethod is required");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddStatus(Status status)
        {
            if (_statuses.Contains(status))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _statuses.Add(status);
            return true;
        }

        #endregion
    }

    /// <summary>
    /// Defines NHibernate mappings for the <see cref="PearsonFileStoreStatusType"/> enumeration.
    /// </summary>
    /// <seealso cref="CaseInsensitiveEntryBasedEnumTypeMap{T}"/>
    internal class ApproachTypeMapping : CaseInsensitiveEntryBasedEnumTypeMap<ApproachType>
    {
    }

    internal class JobSearchMap : ClassMap<JobSearch>
    {
        public JobSearchMap()
        {
            Schema("JobSearchAccess");
            Table("JobSearch");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.JobTitle);
            Map(x => x.InitialDate)
                .CustomSqlType("Date");

            References(x => x.ApproachMethod)
                .Column("ApproachMethodId");

            Map(a => a.ApproachType).CustomType<ApproachTypeMapping>()
                .Column("ApproachType")
                .CustomSqlType(DbConstants.SqlType.Nvarchar)
                .Length(50);

            References(x => x.Employer)
                .Column("EmployerId");

            References(x => x.Recruiter)
                .Column("RecruiterId");

            HasMany(x => x.Statuses)
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }

 }
