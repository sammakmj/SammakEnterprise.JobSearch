//using FluentNHibernate.Mapping;
//using FluentValidation;
//using SammakEnterprise.Core.Persistence.Domain;
//using SammakEnterprise.Core.Persistence.Domain.Types;
//using SammakEnterprise.Core.Persistence.Validation;
//using System.Collections.Generic;


//namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
//{
//    public class TemplateEntity : DomainBase<TemplateEntity>
//    {
//        #region Properties

//        public virtual string ApproachMethod { get; set; }

//        #endregion

//        #region Constructors

//        /// <summary>
//        /// Initializes a new instance of the <see cref="TemplateEntity"/> class.
//        /// </summary>
//        protected TemplateEntity()
//        {
//        }

//        #endregion

//        #region Factory

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public static TemplateEntity Create(
//            string approachMethod,
//            string createdBy)
//        {
//            var sp = new TemplateEntity
//            {
//                ApproachMethod = approachMethod,
//                AuditData = AuditData.Create(createdBy)
//            };
//            return sp;
//        }

//        #endregion

//        #region Validators

//        /// <summary>
//        /// Validates this domain object
//        /// </summary>
//        public class TemplateEntityValidator : ValidatorBase<TemplateEntity>
//        {
//            /// <summary>
//            /// Initializes a new instance of the <see cref="AgencyValidator"/> class.
//            /// </summary>
//            public TemplateEntityValidator(IValidationFactory validationFactory) : base(validationFactory)
//            {
//                RuleFor(x => x.ApproachMethod)
//                    .NotEmpty()
//                    .WithMessage("ApproachMethod Name is required");
//            }
//        }

//        #endregion

//        #region Object Override Methods

//        /// <summary>
//        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
//        /// </summary>
//        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
//        /// <returns>
//        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
//        /// </returns>
//        public override bool Equals(object obj)
//        {
//            var other = obj as TemplateEntity;
//            if (null == other)
//                return false;

//            return
//                ApproachMethod == other.ApproachMethod;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public override string ToString()
//        {
//            return ApproachMethod;
//        }
//        #endregion
//    }

//    #region FluentNhibernate Mapping

//    internal class TemplateEntityMap : ClassMap<TemplateEntity>
//    {
//        public TemplateEntityMap()
//        {
//            Schema("JobSearchAccess");
//            Table("TemplateEntity");

//            Id(x => x.Id)
//                .GeneratedBy.Identity();

//            Map(x => x.ExternalId)
//              .Not.Nullable()
//                .Index("NCK_Agency_ExternalId")
//                .Unique();

//            Map(x => x.ApproachMethod);
//        }
//    }
//    #endregion
//}
