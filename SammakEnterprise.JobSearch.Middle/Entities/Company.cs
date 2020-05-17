using FluentValidation;
//using Nlog;
using SammakEnterprise.JobSearch.Middle.Enums;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Entities
{
    public class Company : DomainBase<Company>
    {
        #region Protected variables

        ///// <summary>
        ///// The logger handle
        ///// </summary>
        //protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The list of <see cref="Employee"/> 
        /// </summary>
        protected readonly IList<Employee> _employees = new List<Employee>();

        /// <summary>
        /// The list of <see cref="Employee"/> 
        /// </summary>
        protected readonly IList<Approach> _approaches = new List<Approach>();

        #endregion

        #region Properties

        /// <summary>
        ///  property Name of the Company Entity class
        /// </summary>
        public virtual string Name { get; protected internal set; }

        /// <summary>
        ///  property Name of the Company Entity class
        /// </summary>
        public virtual int Employers_EmployerId { get; protected internal set; }

        /// <summary>
        ///  property Name of the Company Entity class
        /// </summary>
        public virtual int Agencies_AgencyId { get; protected internal set; }

        /// <summary>
        ///  property Description of the Company Entity class
        /// </summary>
        public virtual string Description { get; protected internal set; }

        /// <summary>
        ///  property WebSite of the Company Entity class
        /// </summary>
        public virtual string WebSite { get; protected internal set; }

        /// <summary>
        ///  property CompanyType of the Company Entity class
        /// </summary>
        public virtual CompanyType CompanyType { get; protected internal set; }

        /// <summary>
        ///  property EmailAddress of the Company Entity class
        /// </summary>
        public virtual EmailAddress EmailAddress { get; protected internal set; }

        /// <summary>
        ///  property Address of the Company Entity class
        /// </summary>
        public virtual Address Address { get; protected internal set; }

        /// <summary>
        ///  property Phone of the Company Entity class
        /// </summary>
        public virtual Phone Phone { get; protected internal set; }

        /// <summary>
        ///  property Login of the Company Entity class
        /// </summary>
        public virtual Login Login { get; protected internal set; }

        /// <summary>
        ///  property Login of the Company Entity class
        /// </summary>
        public virtual IList<Employee> Employees
        {
            get { return new List<Employee>(_employees);  }
        }

        /// <summary>
        ///  property Approaches of the Approach Entity class
        /// </summary>
        public virtual IList<Approach> Approaches
        {
            get { return new List<Approach>(_approaches); }
        }

        /// <summary>
        ///  property HiringManager of the Company Entity class
        /// </summary>
        public virtual Employee HiringManager { get; protected internal set; }

        /// <summary>
        ///  property Contact of the Company Entity class
        /// </summary>
        public virtual Employee Contact { get; protected internal set; }

        /// <summary>
        ///  property  of the Company Entity class
        /// </summary>
        public virtual DateTime? ApplicationDate { get; protected internal set; }

        //        public virtual IList<JobSearch> JobSearches { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        protected Company()
        {
            ExternalId = Guid.NewGuid();
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Company Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            return Company.Create(name, null, createdBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Company Create(
            string name,
            string description,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var sp = new Company
            {
                Name = name,
                Description = description,
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
            var other = obj as Company;
            if (null == other)
                return false;

            return
                Name == other.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class CompanyValidator : ValidatorBase<Company>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CompanyValidator"/> class.
            /// </summary>
            public CompanyValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Company Name is required");

                RuleFor(x => x.EmailAddress).SetValidator(ValidationFactory.GetValidatorInstance<EmailAddress>());
                RuleFor(x => x.Address).SetValidator(ValidationFactory.GetValidatorInstance<Address>());
                RuleFor(x => x.Login).SetValidator(ValidationFactory.GetValidatorInstance<Login>());
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddEmployee(Employee employee)
        {
            if (_employees.Contains(employee))
            {
                //Logger.Warn($"Trying to Add an employee '{employee.FirstName} {employee.LastName}' which is already in the Employees List collection.");
                return false;
            }
            _employees.Add(employee);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool AddApproach(Approach approach)
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
