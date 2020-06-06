using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearch.Middle.Enums;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class Employee : Person
    {
        #region Protected variables

        /// <summary>
        /// The list of <see cref="Employee"/> 
        /// </summary>
        protected readonly IList<ApproachOld> _approaches = new List<ApproachOld>();

        #endregion

        #region Properties

        /// <summary>
        ///  property Role of the Employee Entity class
        /// </summary>
        public virtual Role Role { get; protected internal set; }

        /// <summary>
        ///  property InitialContactDate of the Approach Entity class
        /// </summary>
        public virtual DateTime? InitialContactDate { get; protected internal set; }

        /// <summary>
        ///  property Approaches of the Approach Entity class
        /// </summary>
        public virtual IList<ApproachOld> Approaches
        {
            get { return new List<ApproachOld>(_approaches); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        protected Employee()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Employee Create(
            string firstName,
            string lastName,
            Role role = Role.Recruiter,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var emp = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Role = role,
                AuditData = AuditData.Create(createdBy)
            };

            return emp;
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
            var other = obj as Employee;
            if (null == other)
                return false;

            return
                base.Equals(obj) &&
                Role == other.Role;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class EmployeeValidator : ValidatorBase<Employee>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EmployeeValidator"/> class.
            /// </summary>
            public EmployeeValidator(IValidationFactory validationFactory) : base (validationFactory)
            {
                //RuleFor(x => x.Company)
                //    .NotNull()
                //    .WithMessage("User Name is required");

                //RuleFor(x => x.Role)
                //    .NotEmpty()
                //    .WithMessage("Role is required");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddApproach(ApproachOld approach)
        {
            if (_approaches.Contains(approach))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _approaches.Add(approach);
            return true;
        }

        #endregion

    }
}
