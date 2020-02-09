using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services
{
    public class ProjectManagementService : IProjectManagementService
    {
        private IOfficeUnitOfWork _officeUnitOfWork;
        public ProjectManagementService(IOfficeUnitOfWork officeUnitOfWork)
        {
            _officeUnitOfWork = officeUnitOfWork;
        }
        public void AddNewProject(Project project)
        {
            _officeUnitOfWork.ProjectRepository.Add(new Project
            {
                Name = project.Name,
                ImageUrl = project.ImageUrl,
                DemoAccount = project.DemoAccount,
                CompanyId = project.CompanyId
            });
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(Project Project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Project GetProject(int id)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _officeUnitOfWork.ProjectRepository.Get(
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
