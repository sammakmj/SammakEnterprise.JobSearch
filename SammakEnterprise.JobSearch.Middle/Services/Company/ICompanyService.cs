using SammakEnterprise.Core.Persistence.Services;
using System.Collections.Generic;

namespace SammakEnterprise.JobSearch.Middle.Services.Company
{
    public interface ICompanyService : IService<Entities.Company>
    {
        IEnumerable<Entities.Company> GetAllCompanys();
    }
}
