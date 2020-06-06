using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearchExcel.Middle.Common;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity
{
    public class Agent : DomainBase<Agent>
    {
        #region Protected variables

        protected readonly IList<Approach> _approaches = new List<Approach>();

        #endregion

        #region Properties

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string MobilePhone { get; set; }

        public virtual string OfficePhone { get; set; }

        public virtual IList<Approach> Approaches
        {
            get { return new List<Approach>(_approaches); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Agent"/> class.
        /// </summary>
        protected Agent()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Agent Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var agent = new Agent
            {
                Name = name,
                AuditData = AuditData.Create(createdBy)
            };

            return agent;
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
            var other = obj as Agent;
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
        public class AgentValidator : ValidatorBase<Agent>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public AgentValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.AgentTable.Column.Name} is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }

    internal sealed class AgentMap : ClassMap<Agent>
    {
        public AgentMap()
        {
            Schema(Constants.JobSearchExcelSchema.SchemaName);
            Table(Constants.JobSearchExcelSchema.AgentTable.TableName);

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
                .Not.Nullable()
                .Index(Constants.AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Unique();

            Map(x => x.Name)
                .Column(Constants.JobSearchExcelSchema.AgentTable.Column.Name);

            Map(x => x.Email)
                .Column(Constants.JobSearchExcelSchema.AgentTable.Column.Email);

            Map(x => x.MobilePhone)
                .Column(Constants.JobSearchExcelSchema.AgentTable.Column.MobilePhone);

            Map(x => x.OfficePhone)
                .Column(Constants.JobSearchExcelSchema.AgentTable.Column.OfficePhone);

            HasMany(x => x.Approaches)
                .KeyColumns.Add(Constants.JobSearchExcelSchema.ApproachTable.Column.AgentId)
                .AsBag()
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }

}
