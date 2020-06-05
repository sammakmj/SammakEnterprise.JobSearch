using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;
using NLog;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public abstract class Person : DomainBase<Person>
    {
        #region Protected variables

        /// <summary>
        /// The logger handle
        /// </summary>
        protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The list of <see cref="Employee"/> 
        /// </summary>
        protected readonly IList<Phone> _phones = new List<Phone>();

        #endregion

        #region Properties

        /// <summary>
        ///  property FirstName of the Person Entity class
        /// </summary>
        public virtual string FirstName { get; protected internal set; }

        /// <summary>
        /// property LastName of the Person Entity class
        /// </summary>
        public virtual string LastName { get; protected internal set; }

        /// <summary>
        /// property EmailAddress of the Person Entity class
        /// </summary>
        public virtual EmailAddress EmailAddress { get; protected internal set; }

        /// <summary>
        /// property  of the Person Entity class
        /// </summary>
        public virtual string OfficePhone { get; protected internal set; }

        /// <summary>
        /// property  of the Person Entity class
        /// </summary>
        public virtual string MobilePhone { get; protected internal set; }

        /// <summary>
        /// property Phones of the Person Entity class
        /// </summary>
        public virtual IList<Phone> Phones
        {
            get { return new List<Phone>(_phones); }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        protected Person()
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
            var other = obj as Person;
            if (null == other)
                return false;

            return
                FirstName == other.FirstName &&
                LastName == other.LastName;
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
        public class PersonValidator : ValidatorBase<Person>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PersonValidator"/> class.
            /// </summary>
            public PersonValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(e => e.FirstName).NotNull();
                RuleFor(e => e.LastName).NotNull();
                RuleFor(x => x.EmailAddress).SetValidator(ValidationFactory.GetValidatorInstance<EmailAddress>());
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddPhone(Phone phone)
        {
            if (_phones.Contains(phone))
            {
                Logger.Warn($"Trying to Add an phone '{phone.ToString()}' which is already in the Phones List collection.");
                return false;
            }
            _phones.Add(phone);
            return true;
        }

        #endregion

    }
}
