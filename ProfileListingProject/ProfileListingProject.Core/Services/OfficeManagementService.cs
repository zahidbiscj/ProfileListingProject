using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProfileListingProject.Core.Services
{
    public class OfficeManagementService: IOfficeManagementService
    {
        private IOfficeUnitOfWork _officeUnitOfWork;
        public OfficeManagementService(IOfficeUnitOfWork officeUnitOfWork)
        {
            _officeUnitOfWork = officeUnitOfWork;
        }

        public void AddNewCompany(Company company)
        {
            _officeUnitOfWork.CompanyRepository.Add(new Company
            {
                Name = company.Name,
                ShortDescription = company.ShortDescription,
                Address = company.Address,
                LogoImageUrl = company.LogoImageUrl,
                Phone = company.Phone
            });
            _officeUnitOfWork.Save();
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCompany(Company Company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _officeUnitOfWork.CompanyRepository.GetAllCompanies();
        }

        public IEnumerable<Company> GetCompanies(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            return _officeUnitOfWork.CompanyRepository.GetCompaniesIncludingChild(id);
        }

        public Company GetCompanyByName(string name)
        {
            throw new NotImplementedException();
        }

        
    }
}
