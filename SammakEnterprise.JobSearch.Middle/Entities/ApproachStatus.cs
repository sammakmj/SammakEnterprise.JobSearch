using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Enums;
using System;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class ApproachStatus : DomainBase<ApproachStatus>
    {
        #region Properties

        /// <summary>
        ///  property ActivityDate of the ApproachStatus Entity class
        /// </summary>
        public virtual DateTime ActivityDate { get; protected internal set; }

        /// <summary>
        ///  property ActivityNote of the ApproachStatus Entity class
        /// </summary>
        public virtual string ActivityNote { get; protected internal set; }

        /// <summary>
        ///  property PhoneInterview of the ApproachStatus Entity class
        /// </summary>
        public virtual bool PhoneInterview { get; protected internal set; }

        /// <summary>
        ///  property FaceToFaceInterview of the ApproachStatus Entity class
        /// </summary>
        public virtual bool FaceToFaceInterview { get; protected internal set; }

        /// <summary>
        ///  property OnlineTest of the ApproachStatus Entity class
        /// </summary>
        public virtual bool OnlineTest { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApproachStatus"/> class.
        /// </summary>
        protected ApproachStatus()
        {
            ExternalId = Guid.NewGuid();
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ApproachStatus Create(
            DateTime activityDate,
            string activityNote,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new ApproachStatus
            {
                ActivityDate = activityDate,
                ActivityNote = activityNote,
                FaceToFaceInterview = false,
                PhoneInterview = false,
                OnlineTest = false,
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
            var other = obj as ApproachStatus;
            if (null == other)
                return false;

            return
                ActivityDate == other.ActivityDate &&
                ActivityNote == other.ActivityNote;
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
        public class ApproachStatusValidator : ValidatorBase<ApproachStatus>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ApproachStatusValidator"/> class.
            /// </summary>
            public ApproachStatusValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                //RuleFor(x => x.AreaCode).NotNull();
                //RuleFor(x => x.Number).NotNull().NotEmpty();
            }
        }

        #endregion

    }
}
