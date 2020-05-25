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
    public class Employer : DomainBase<Employer>
    {
        #region Protected variables

        //protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected readonly IList<JobSearch> _jobSearches = new List<JobSearch>();

        #endregion

        #region Properties

        public virtual string EmployerName { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Email { get; set; }

        public virtual string EmployerWebSite { get; set; }

        public virtual string EmployerContact { get; set; }

        public virtual string HiringManager { get; set; }

        public virtual DateTime ApplicationDate { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual State State { get; set; }

        public virtual string Zip { get; set; }

        public virtual IList<JobSearch> JobSearches
        {
            get { return new List<JobSearch>(_jobSearches); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Employer"/> class.
        /// </summary>
        protected Employer()
        {
            //ExternalId = Guid.NewGuid();
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Employer Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new Employer
            {
                EmployerName = name,
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
            var other = obj as Employer;
            if (null == other)
                return false;

            return
                EmployerName == other.EmployerName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EmployerName;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class EmployerValidator : ValidatorBase<Employer>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EmployerValidator"/> class.
            /// </summary>
            public EmployerValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.EmployerName)
                    .NotEmpty()
                    .WithMessage("Employer Name is required");
            }
        }

        #endregion

        #region Public Methods

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

        #endregion

    }

    #region FluentNhibernate Mapping

    internal class EmployerMap : ClassMap<Employer>
    {
        public EmployerMap()
        {
            Schema("JobSearchAccess");
            Table("Employer");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
              .Not.Nullable()
                .Index("NCK_Employer_ExternalId")
                .Unique();

            Map(x => x.EmployerName);
            Map(x => x.PhoneNumber);
            Map(x => x.Email);
            Map(x => x.EmployerWebSite);
            Map(x => x.EmployerContact);
            Map(x => x.HiringManager);
            Map(x => x.ApplicationDate);
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.Street);
            Map(x => x.City);
            References(x => x.State)
                .Column("StateId");
            Map(x => x.Zip);

            HasMany(x => x.JobSearches)
                //.KeyColumn("EmployerId")  // the FK column name in the child table
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }
    #endregion

}
