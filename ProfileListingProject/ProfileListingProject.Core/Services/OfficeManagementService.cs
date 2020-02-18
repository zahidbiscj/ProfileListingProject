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
                Phone = company.Phone,
                UserId = company.UserId
            });
            _officeUnitOfWork.Save();
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCompany(Company company)
        {
            var oldCompany = _officeUnitOfWork.CompanyRepository.GetCompaniesIncludingChild(company.Id);

            oldCompany.Name = company.Name;
            oldCompany.ShortDescription = company.ShortDescription;
            oldCompany.Address = company.Address;
            oldCompany.LogoImageUrl = company.LogoImageUrl;
            oldCompany.Phone = company.Phone;
            oldCompany.AreaOfOperations = company.AreaOfOperations;
            oldCompany.Teams = company.Teams;
            oldCompany.TechnologyInfos = company.TechnologyInfos;

            _officeUnitOfWork.Save();
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
