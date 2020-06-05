using FluentValidation;
//using Nlog;
using SammakEnterprise.JobSearch.Middle.Enums;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
{
    public class Recruiter : DomainBase<Recruiter>
    {
        #region Protected variables

        //protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected readonly IList<JobSearch> _jobSearches = new List<JobSearch>();

        #endregion

        #region Properties

        public virtual string RecruiterName { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual DateTime InitialContactDate { get; set; }

        public virtual string RecruiterOfficePhone { get; set; }

        public virtual string RecruiterMobilePhone { get; set; }

        public virtual string RecruiterEmail { get; set; }

        public virtual IList<JobSearch> JobSearches
        {
            get { return new List<JobSearch>(_jobSearches); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Recruiter"/> class.
        /// </summary>
        protected Recruiter()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Recruiter Create(
            string recruiterName,
            DateTime initialContactDate,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new Recruiter
            {
                RecruiterName = recruiterName,
                InitialContactDate = initialContactDate,
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
            var other = obj as Recruiter;
            if (null == other)
                return false;

            return
                RecruiterName.Equals(other.RecruiterName, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RecruiterName;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class RecruiterValidator : ValidatorBase<Recruiter>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RecruiterValidator"/> class.
            /// </summary>
            public RecruiterValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.RecruiterName)
                    .NotEmpty()
                    .WithMessage("Recruiter Name is required");
            }
        }

        #endregion

        protected internal virtual bool AddJobSearch(JobSearch jobSearch)
        {
            if (_jobSearches.Contains(jobSearch))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _jobSearches.Add(jobSearch);
            return true;
        }

    }

    internal class RecruiterMap : ClassMap<Recruiter>
    {
        public RecruiterMap()
        {
            Schema("JobSearchAccess");
            Table("Recruiter");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
              .Not.Nullable()
                .Index("NCK_Recruiter_ExternalId")
                .Unique();

            Map(x => x.RecruiterEmail);
            Map(x => x.RecruiterMobilePhone);
            Map(x => x.RecruiterName);
            Map(x => x.RecruiterOfficePhone);
            Map(x => x.InitialContactDate);

            References(x => x.Agency)
                .Column("AgencyId");

            HasMany(x => x.JobSearches)
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }

}
