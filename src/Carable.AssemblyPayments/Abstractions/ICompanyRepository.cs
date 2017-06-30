using Carable.AssemblyPayments.Entities;
using System.Collections.Generic;

namespace Carable.AssemblyPayments.Abstractions
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> ListCompanies();

        Company GetCompanyById(string companyId);

        Company CreateCompany(Company company, string userId);

        Company EditCompany(Company company);
    }
}
