using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearchExcel.Middle.Common;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity
{
    public class JobTitle : DomainBase<JobTitle>
    {
        #region Properties

        public virtual string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitle"/> class.
        /// </summary>
        protected JobTitle()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JobTitle Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var jobTitle = new JobTitle
            {
                Name = name,
                AuditData = AuditData.Create(createdBy)
            };

            return jobTitle;
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
            var other = obj as JobTitle;
            if (null == other)
                return false;

            return
                Name == other.Name;
        }

        public override int GetHashCode()
        {
            const int hashSeed = 486187739;  // a large prime number
            unchecked // Overflow is fine, just wrap
            {
                int hash = hashSeed;
                hash = hash * hashSeed + base.GetHashCode();
                hash = hash * hashSeed + Name.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"Job Title: {Name}";
            return result;
        }

        #endregion

        #region Validators

        /// <summary>
        /// Validates an FileStatus domain object
        /// </summary>
        public class JobTitleValidator : ValidatorBase<JobTitle>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public JobTitleValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.JobTitleTable.Column.Name} is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }
    internal sealed class JobTitleMap : ClassMap<JobTitle>
    {
        public JobTitleMap()
        {
            Schema(Constants.JobSearchExcelSchema.SchemaName);
            Table(Constants.JobSearchExcelSchema.JobTitleTable.TableName);

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
                .Not.Nullable()
                .Index(Constants.AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Unique();

            Map(x => x.Name)
                .Column(Constants.JobSearchExcelSchema.JobTitleTable.Column.Name);

            Component(x => x.AuditData);
        }
    }

}
