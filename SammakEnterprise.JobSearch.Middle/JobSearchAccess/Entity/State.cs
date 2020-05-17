using FluentValidation;
//using Nlog;
using SammakEnterprise.JobSearch.Middle.Enums;
using SammakEnterprise.Core.Persistence.Domain;
using SammakEnterprise.Core.Persistence.Domain.Types;
using SammakEnterprise.Core.Persistence.Validation;
using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Entity
{
    public class State : DomainBase<State>
    {
        public virtual string StateAbbreviation { get; set; }

        public virtual string StateName { get; set; }

        public override string ToString()
        {
            return StateAbbreviation;
        }
    }

    internal class StateMap : ClassMap<State>
    {
        public StateMap()
        {
            Schema("JobSearchAccess");
            Table("State");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.StateAbbreviation);
            Map(x => x.StateName);

            Component(x => x.AuditData);
        }
    }

}
