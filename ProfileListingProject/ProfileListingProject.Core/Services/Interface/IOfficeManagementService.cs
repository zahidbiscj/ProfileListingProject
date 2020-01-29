using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface IOfficeManagementService
    {
        IEnumerable<Company> GetCompanies(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        void AddNewCompany(Company company);
        Company GetCompany(int id);
        void EditCompany(Company Company);
        void DeleteCompany(int id);

        Company GetCompanyByName(string name);
        IEnumerable<Company> GetAllCompanies();
    }
}
