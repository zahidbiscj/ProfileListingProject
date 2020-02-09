using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface IProjectManagementService
    {
        IEnumerable<Project> GetProjects(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewProject(Project Project);
        Project GetProject(int id);
        void EditProject(Project Project);
        void DeleteProject(int id);

        Project GetProjectByName(string name);
        IEnumerable<Project> GetAllProjects();
    }
}
