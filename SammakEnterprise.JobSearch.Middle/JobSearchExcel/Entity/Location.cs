﻿using FluentNHibernate.Mapping;
using FluentValidation;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using SammakEnterprise.JobSearchExcel.Middle.Common;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.JobSearchExcel.Entity
{
    public class Location : DomainBase<Location>
    {
        #region Protected variables

        protected readonly IList<Approach> _approaches = new List<Approach>();

        #endregion

        #region Properties

        public virtual string Name { get; set; }

        public virtual IList<Approach> Approaches
        {
            get { return new List<Approach>(_approaches); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        protected Location()
        {
        }

        #endregion

        #region Factory

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Location Create(
            string name,
            string createdBy = null)
        {
            createdBy = createdBy ?? Common.Utilities.DefaultUser();
            var location = new Location
            {
                Name = name,
                AuditData = AuditData.Create(createdBy)
            };

            return location;
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
            var other = obj as Location;
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
        public class LocationValidator : ValidatorBase<Location>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusValidator"/> class.
            /// </summary>
            public LocationValidator(IValidationFactory validationFactory) : base(validationFactory)
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage($"{Constants.JobSearchExcelSchema.LocationTable.Column.Name} is required");
            }
        }

        #endregion

        #region Public Methods

        #endregion

    }
    internal sealed class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Schema(Constants.JobSearchExcelSchema.SchemaName);
            Table(Constants.JobSearchExcelSchema.LocationTable.TableName);

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.ExternalId)
                .Not.Nullable()
                .Index(Constants.AnyEntityTables.Index.BaseEntityDbDef_ExternalId)
                .Unique();

            Map(x => x.Name)
                .Column(Constants.JobSearchExcelSchema.LocationTable.Column.Name);

            HasMany(x => x.Approaches)
                .KeyColumns.Add(Constants.JobSearchExcelSchema.ApproachTable.Column.LocationId)
                .AsBag()
                .Inverse()
                .Cascade.All();

            Component(x => x.AuditData);
        }
    }

}