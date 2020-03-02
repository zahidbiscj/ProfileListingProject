using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void AddAreaOfOperations(IList<AreaOfOperation> areaOfOperations)
        {
            var existAreaOfOperations =_officeUnitOfWork.AreaOfOperationsRepository.GetAllAreaOfOperations();
            foreach (var item in areaOfOperations)
            {
                if (!existAreaOfOperations.Any(x => x.Name == item.Name && x.CompanyId.Equals(item.CompanyId)))
                {
                    _officeUnitOfWork.AreaOfOperationsRepository.Add(item);
                }
                else { continue; }
            }
            _officeUnitOfWork.Save();
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

        public void AddNewTeam(Team team)
        {
            _officeUnitOfWork.TeamRepository.Add(new Team
            {
                Name = team.Name,
                Count = team.Count,
                Company = team.Company
            });
            _officeUnitOfWork.Save();
        }

        public void AddTechnologyInfos(IList<TechnologyInfo> technologyInfos)
        {
            var existTechnologies = _officeUnitOfWork.TechnologyInfoRepository.GetAllTechnologyInfo();
            foreach (var item in technologyInfos)
            {
                if (!existTechnologies.Any(x => x.Name == item.Name && x.CompanyId == item.CompanyId))
                {
                    _officeUnitOfWork.TechnologyInfoRepository.Add(item);
                }
                else { continue; }
            }
            _officeUnitOfWork.Save();
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(int id)
        {
            _officeUnitOfWork.TeamRepository.Remove(id);
            _officeUnitOfWork.Save();
        }

        public void EditCompany(Company company)
        {
            var oldCompany = _officeUnitOfWork.CompanyRepository.GetCompaniesIncludingChild(company.Id);
            oldCompany.Name = company.Name;
            oldCompany.ShortDescription = company.ShortDescription;
            oldCompany.Address = company.Address;
            oldCompany.LogoImageUrl = company.LogoImageUrl;
            oldCompany.Phone = company.Phone;
            oldCompany.OfficePhotoUrl = company.OfficePhotoUrl;

            _officeUnitOfWork.Save();
        }

        public IList<AreaOfOperation> GetAllAreaOfOperations()
        {
            return _officeUnitOfWork.AreaOfOperationsRepository.GetAllAreaOfOperations();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _officeUnitOfWork.CompanyRepository.GetAllCompanies();
        }

        public IList<TechnologyInfo> GetAllTechnologyInfos()
        {
            return _officeUnitOfWork.TechnologyInfoRepository.GetAllTechnologyInfo();
        }

        public IEnumerable<Company> GetCompanies(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            throw new Exception();
        }

        public Company GetCompany(int id)
        {
            return _officeUnitOfWork.CompanyRepository.GetCompaniesIncludingChild(id);
        }

        public Company GetCompanyByName(string name)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyByUserId(string userId)
        {
            return _officeUnitOfWork.CompanyRepository.GetCompanyByUserId(userId);
        }

        public IEnumerable<Team> GetTeams(int companyId, int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _officeUnitOfWork.TeamRepository.Get(
               out total,
               out totalFiltered,
               x => x.Name.Contains(searchText) && x.Company.Id == companyId,
               null,
               "",
               pageIndex,
               pageSize,
               true);
        }
    }
}
