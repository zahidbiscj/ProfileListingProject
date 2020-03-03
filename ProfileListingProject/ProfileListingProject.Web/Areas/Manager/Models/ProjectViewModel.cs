using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;
using System;
using System.Linq;
using BaseModel = ProfileListingProject.Web.Areas.Manager.Models.BaseModel;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    public class ProjectViewModel : BaseModel
    {
        private IProjectManagementService _projectManagementService;
        private IOfficeManagementService _officeManagementService;
        public ProjectViewModel()
        {
            _projectManagementService = Startup.AutoFacContainer.Resolve<IProjectManagementService>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }
        public ProjectViewModel(IProjectManagementService projectManagementService,IOfficeManagementService officeManagementService)
        {
            _projectManagementService = projectManagementService;
            _officeManagementService = officeManagementService;
        }

        public object GetProjects(DataTablesAjaxRequestModel tableModel, int companyId)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _projectManagementService.GetProjects(
                companyId,
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