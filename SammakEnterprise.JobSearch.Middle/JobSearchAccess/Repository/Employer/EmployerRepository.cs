﻿using System.Linq;
using NHibernate;
using SammakEnterprise.Core.Persistence.Queries;
using SammakEnterprise.Core.Persistence.Repository.Base;
using SammakEnterprise.Core.Persistence.Validation;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Repository.Employer
{
    public class EmployerRepository : RepositoryBase<Entity.Employer, int>, IEmployerRepository
    {
        public EmployerRepository(ISession session, IQueryFactory queryFactory, IValidationFactory validationFactory)
        : base(session, queryFactory, validationFactory)
        {
        }

        public Entity.Employer GetEmployer(string employerName) =>
            Query(x => x.EmployerName == employerName).FirstOrDefault();
    }
}
