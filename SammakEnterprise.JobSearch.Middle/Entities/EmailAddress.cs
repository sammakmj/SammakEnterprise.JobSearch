using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class EmailAddress
    {
        #region Properties

        /// <summary>
        ///  property FirstName of the EmailAddress Entity class
        /// </summary>
        public virtual string Email { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        protected EmailAddress()
        {
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
            var other = obj as EmailAddress;
            if (null == other)
                return false;

            return
                Email == other.Email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Email;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class EmailAddressValidator : AbstractValidator<EmailAddress>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
            /// </summary>
            public EmailAddressValidator(IValidationFactory validationFactory)
            {
                When(x => x != null, () => {
                    RuleFor(s => s.Email)
                        .NotEmpty().WithMessage("Email address is required")
                        .EmailAddress().WithMessage("A valid email is required");
                });
            }
        }

        #endregion

    }
}
