using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
{
    public class AgencyCompany : DomainBase<AgencyCompany>
    {
        #region Protected variables

        //protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected readonly IList<Recruiter> _recruiters = new List<Recruiter>();

        #endregion

        #region Properties

        public virtual string AgencyName { get; set; }

        public virtual string WebSite { get; set; }

        public virtual IList<Recruiter> Recruiters
        {
            get { return new List<Recruiter>(_recruiters); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AgencyCompany"/> class.
        /// </summary>
        protected AgencyCompany()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AgencyCompany Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new AgencyCompany
            {
                AgencyName = name,
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
            var other = obj as AgencyCompany;
            if (null == other)
                return false;

            return
                AgencyName == other.AgencyName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AgencyName;
        }

        #endregion

        protected internal virtual bool AddRecruiter(Recruiter recruiter)
        {
            if (_recruiters.Contains(recruiter))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _recruiters.Add(recruiter);
            return true;
        }

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class AgencyValidator : ValidatorBase<AgencyCompany>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AgencyValidator"/> class.
            /// </summary>
            public AgencyValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.AgencyName)
                    .NotEmpty()
                    .WithMessage("Agency Name is required");
            }
        }

        #endregion

    }
    internal class AgencyMap : ClassMap<AgencyCompany>
    {
        public AgencyMap()
        {
            Schema("JobSearchAccess");
            Table("Agency");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
              .Not.Nullable()
                .Index("NCK_Agency_ExternalId")
                .Unique();

            Map(x => x.AgencyName);
            Map(x => x.WebSite);

            HasMany(x => x.Recruiters)
                .Inverse()
                .Cascade.All();
            //.Cascade.AllDeleteOrphan();

            Component(x => x.AuditData);
        }
    }

}
