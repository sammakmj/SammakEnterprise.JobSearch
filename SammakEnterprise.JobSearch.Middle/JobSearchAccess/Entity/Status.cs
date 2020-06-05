using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Enums;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
{
    public class Status : DomainBase<Status>
    {
        #region Properties

        public virtual JobSearch JobSearch { get; set; }

        public virtual DateTime StatusDate { get; set; }

        /// <summary>
        ///  property JobTitle of the Status Entity class
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///  property StatusType of the Status Entity class
        /// </summary>
        public virtual bool InterviewF2F { get; set; }

        public virtual bool InterviewPhone { get; set; }

        public virtual bool OnlineTest { get; set; }

        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        protected Status()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Status Create(
            DateTime statusDate,
            string description,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new Status
            {
                StatusDate = statusDate,
                Description = description,
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
            var other = obj as Status;
            if (null == other)
                return false;

            return
                StatusDate == other.StatusDate &&
                Description == other.Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"StatusDate: {StatusDate.ToString(Common.Utilities.DateFormat)}";
            if (JobSearch != null && JobSearch.Recruiter != null)
            {
                result += $", Recruiter: {JobSearch.Recruiter}";
            }
            if (JobSearch != null && JobSearch.Employer != null)
            {
                result += $", Employer: {JobSearch.Employer}";
            }
            return result;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class StatusValidator : ValidatorBase<Status>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public StatusValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.StatusDate)
                    .NotEmpty()
                    .WithMessage("StatusDate is required");
                RuleFor(x => x.Description)
                    .NotEmpty()
                    .WithMessage("Status Description is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }
    internal sealed class StatusMap : ClassMap<Status>
    {
        public StatusMap()
        {
            Schema("JobSearchAccess");
            Table("Status");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
              .Not.Nullable()
                .Index("NCK_Status_ExternalId")
                .Unique();

            Map(x => x.StatusDate);
            Map(x => x.Description)
                .Length(4001); // makes the column size to max (nvarchar)
            Map(x => x.InterviewF2F);
            Map(x => x.InterviewPhone);
            Map(x => x.OnlineTest);

            References(x => x.JobSearch)
                .Column("JobSearchId");

            Component(x => x.AuditData);
        }
    }

}
