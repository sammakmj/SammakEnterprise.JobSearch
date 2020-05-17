using FluentValidation;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class Login : IEquatable<Login>
    {
        #region Properties

        /// <summary>
        ///  property UserName of the Login Entity class
        /// </summary>
        public virtual string UserName { get; protected internal set; }

        /// <summary>
        /// property Password of the Login Entity class
        /// </summary>
        public virtual string Password { get; protected internal set; }

        /// <summary>
        /// property Url of the Login Entity class
        /// </summary>
        public virtual string Url { get; protected internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        protected Login()
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
            var other = obj as Login;
            if (null == other)
                return false;

            return other != null &&
                   UserName == other.UserName &&
                   Password == other.Password &&
                   Url == other.Url;
        }

        public override int GetHashCode()
        {
            var hashCode = -870532673;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Url);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{UserName} for: {Url}";
        }

        public bool Equals(Login other)
        {
            return this.Equals(other);
        }

        public static bool operator ==(Login login1, Login login2)
        {
            return EqualityComparer<Login>.Default.Equals(login1, login2);
        }

        public static bool operator !=(Login login1, Login login2)
        {
            return !(login1 == login2);
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class LoginValidator : AbstractValidator<Login>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LoginValidator"/> class.
            /// </summary>
            public LoginValidator(IValidationFactory validationFactory)
            {
                When(x => x != null, () =>
                {
                    RuleFor(x => x.UserName)
                        .NotEmpty().WithMessage("User Name is required");
                    RuleFor(x => x.Password)
                        .NotEmpty().WithMessage("Password is required");
                    RuleFor(x => x.Url)
                        .NotEmpty().WithMessage("Url is required")
                        .Must(url => (url.StartsWith("http://") || url.StartsWith("https://")))
                        .WithMessage("A valid Url is required");
                });
            }
        }

        #endregion

    }
}
