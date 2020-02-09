using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services
{
    public class ServiceManagement : IServiceManagement
    {
        private IOfficeUnitOfWork _officeUnitOfWork;
        public ServiceManagement(IOfficeUnitOfWork officeUnitOfWork)
        {
            _officeUnitOfWork = officeUnitOfWork;
        }

        public void AddNewCompanyService(CompanyService companyService)
        {
            _officeUnitOfWork.CompanyServiceRepository.Add(new CompanyService
            {
                Name = companyService.Name,
                ImageUrl = companyService.ImageUrl,
                Description = companyService.Description,
                PricingRate = companyService.PricingRate,
                CompanyId = companyService.CompanyId
            });
            _officeUnitOfWork.Save();
        }

        public void DeleteCompanyService(int id)
        {
            _officeUnitOfWork.CompanyServiceRepository.Remove(id);
            _officeUnitOfWork.Save();
        }

        public void EditCompanyService(CompanyService companyService)
        {
            _officeUnitOfWork.CompanyServiceRepository.Edit(new CompanyService
            {
                Description = companyService.Description,
                Name = companyService.Name,
                PricingRate = companyService.PricingRate,
                CompanyId = companyService.CompanyId
            });
            _officeUnitOfWork.Save();
        }

        public IEnumerable<CompanyService> GetAllCompanyServices()
        {
            throw new NotImplementedException();
        }

        public CompanyService GetCompanyService(int id)
        {
            return _officeUnitOfWork.CompanyServiceRepository.GetServiceWithPricingRate(id);
        }

        public CompanyService GetCompanyServiceByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyService> GetCompanyServices(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _officeUnitOfWork.CompanyServiceRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
