using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface IServiceManagement
    {
        IEnumerable<CompanyService> GetCompanyServices(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        void AddNewCompanyService(CompanyService companyService);
        CompanyService GetCompanyService(int id);
        void EditCompanyService(CompanyService companyService);
        void DeleteCompanyService(int id);
        CompanyService GetCompanyServiceByName(string name);
        IEnumerable<CompanyService> GetAllCompanyServices(int companyId, int pageIndex, int pageSize,
            string searchText, out int total,
            out int totalFiltered);
        IList<CompanyService> GetAllServicesOfCompany(int companyId);
    }
}
