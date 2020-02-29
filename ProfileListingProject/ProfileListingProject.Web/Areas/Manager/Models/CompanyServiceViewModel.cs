using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class CompanyServiceViewModel
    {
        private IServiceManagement _serviceManagement;
        private IOfficeManagementService _officeManagementService;
        public CompanyServiceViewModel()
        {
            _serviceManagement = Startup.AutoFacContainer.Resolve<IServiceManagement>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }
        public CompanyServiceViewModel(IServiceManagement serviceManagement,IOfficeManagementService officeManagementService)
        {
            _serviceManagement = serviceManagement;
            _officeManagementService = officeManagementService;
        }
        public object GetCompanyServices(DataTablesAjaxRequestModel tableModel,Company company)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _serviceManagement.GetAllCompanyServices(
                company.Id,
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.Description,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public Company GetCompany(string userId)
        {
            return _officeManagementService.GetCompanyByUserId(userId);
        }
    }
}
