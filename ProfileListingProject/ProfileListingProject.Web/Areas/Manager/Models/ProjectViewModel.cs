using Autofac;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;
using System;
using System.Linq;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    public class ProjectViewModel : BaseModel
    {
        private IProjectManagementService _projectManagementService;
        public ProjectViewModel()
        {
            _projectManagementService = Startup.AutoFacContainer.Resolve<IProjectManagementService>();
        }
        public ProjectViewModel(IProjectManagementService projectManagementService)
        {
            _projectManagementService = projectManagementService;
        }

        public object GetProjects(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _projectManagementService.GetProjects(
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
    }
}