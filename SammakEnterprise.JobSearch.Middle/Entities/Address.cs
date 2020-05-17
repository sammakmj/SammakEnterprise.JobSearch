using FluentValidation;
using SammakEnterprise.Core.Common.CommonEnums;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Domain;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class Address : DomainBase<Address>
    {
        #region Properties

        /// <summary>
        ///  property Street of the PostalAddress Entity class
        /// </summary>
        public virtual string StreetAddress { get; protected internal set; }

        /// <summary>
        ///  property City of the PostalAddress Entity class
        /// </summary>
        public virtual string City { get; protected internal set; }

        /// <summary>
        ///  property State of the PostalAddress Entity class
        /// </summary>
        public virtual State State { get; protected internal set; }

        /// <summary>
        ///  property ZipCode of the PostalAddress Entity class
        /// </summary>
        public virtual string ZipCode { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        protected Address()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Address Create(
            string streetNo,
            string street,
            string city,
            State state,
            string zipCode,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var pa = new Address
            {
                StreetAddress = street,
                City = city,
                State = state,
                ZipCode = zipCode,
                AuditData = AuditData.Create(createdBy)
            };

            return pa;
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
            var other = obj as Address;
            if (null == other)
                return false;

            return
                StreetAddress == other.StreetAddress &&
                City == other.City &&
                State == other.State &&
                ZipCode == other.ZipCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{StreetAddress}, {City}, {State}, {ZipCode}";
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class AddressValidator : AbstractValidator<Address>
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="AddressValidator"/> class.
            /// </summary>
            public AddressValidator(IValidationFactory validationFactory)
            {
                RuleFor(x => x.StreetAddress)
                    .NotEmpty()
                    .WithMessage("StreetAddress is required");
                RuleFor(x => x.City)
                    .NotEmpty()
                    .WithMessage("City is required");
                RuleFor(x => x.State)
                    .NotEmpty()
                    .WithMessage("State is required");
                RuleFor(x => x.ZipCode)
                    .NotEmpty()
                    .WithMessage("ZipCode is required");
            }
        }

        #endregion

    }
}
