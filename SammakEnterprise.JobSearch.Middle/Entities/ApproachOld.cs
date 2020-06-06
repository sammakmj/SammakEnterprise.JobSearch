using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Enums;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class ApproachOld : DomainBase<ApproachOld>
    {
        #region Protected variables

        /// <summary>
        /// The list of <see cref="ApproachStatus"/> 
        /// </summary>
        protected readonly IList<ApproachStatus> _approachStatuses = new List<ApproachStatus>();

        #endregion

        #region Properties

        /// <summary>
        ///  property InitialDate of the Approach Entity class
        /// </summary>
        public virtual DateTime InitialDate { get; protected internal set; }

        /// <summary>
        ///  property JobTitle of the Approach Entity class
        /// </summary>
        public virtual string JobTitle { get; protected internal set; }

        /// <summary>
        ///  property ApproachType of the Approach Entity class
        /// </summary>
        public virtual ApproachType ApproachType { get; protected internal set; }

        
        /// <summary>
        ///  property Approaches of the Approach Entity class
        /// </summary>
        public virtual IList<ApproachStatus> ApproachStatuses
        {
            get { return new List<ApproachStatus>(_approachStatuses); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproachOld"/> class.
        /// </summary>
        protected ApproachOld()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ApproachOld Create(
            DateTime initialDate,
            Employee recruiter,
            string jobTitle,
            Company targetCompany,
            ApproachType ApproachType,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new ApproachOld
            {
                InitialDate = initialDate,
                JobTitle = jobTitle,
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
            var other = obj as ApproachOld;
            if (null == other)
                return false;

            return
                InitialDate == other.InitialDate &&
                ApproachType == other.ApproachType &&
                JobTitle == other.JobTitle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString(); // $"+{} {} {} {} {} {} ";
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class ApproachValidator : ValidatorBase<ApproachOld>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ApproachValidator"/> class.
            /// </summary>
            public ApproachValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                //RuleFor(x => x.AreaCode).NotNull();
                //RuleFor(x => x.Number).NotNull().NotEmpty();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddApproachStatus(ApproachStatus approachStatus)
        {
            if (_approachStatuses.Contains(approachStatus))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _approachStatuses.Add(approachStatus);
            return true;
        }

        #endregion

    }
}
