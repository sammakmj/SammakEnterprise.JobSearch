using FluentValidation;
using SammakEnterprise.Core.Common.Extensions;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Enums;
using System;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class Phone : DomainBase<Phone>
    {
        const short Default_CountryCode = 1; // US code

        #region Properties

        /// <summary>
        ///  property CountryCode of the Phone Entity class
        /// </summary>
        public virtual short CountryCode { get; protected internal set; }

        /// <summary>
        /// property AreaCode of the Phone Entity class
        /// </summary>
        public virtual short AreaCode { get; protected internal set; }

        /// <summary>
        /// property Number of the Phone Entity class
        /// </summary>
        public virtual string Number { get; protected internal set; }

        /// <summary>
        /// property Extension of the Phone Entity class
        /// </summary>
        public virtual string Extension { get; protected internal set; }

        /// <summary>
        /// property Extension of the Phone Entity class
        /// </summary>
        public virtual PhoneType PhoneType { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Phone"/> class.
        /// </summary>
        protected Phone()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Phone Create(
            short countryCode,
            short areaCode,
            string number,
            string extension,
            PhoneType phoneType,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new Phone
            {
                CountryCode = countryCode,
                AreaCode = areaCode,
                Number = number,
                Extension = extension,
                PhoneType = phoneType,
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
            var other = obj as Phone;
            if (null == other)
                return false;

            return
                CountryCode == other.CountryCode &&
                AreaCode == other.AreaCode &&
                Number == other.Number &&
                PhoneType == other.PhoneType &&
                Extension.StringEq(other.Extension);
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
        public class PhoneValidator : ValidatorBase<Phone>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PhoneValidator"/> class.
            /// </summary>
            public PhoneValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.AreaCode).NotNull();
                RuleFor(x => x.Number).NotNull().NotEmpty();
            }
        }

        #endregion

    }
}
