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
                Description = project.Description,
                DemoAccount = project.DemoAccount,
                CompanyId = project.CompanyId
            });
            _officeUnitOfWork.Save();
        }

        public void DeleteProject(int id)
        {
            var project = _officeUnitOfWork.ProjectRepository.GetById(id);
            _officeUnitOfWork.ProjectRepository.Remove(project);
            _officeUnitOfWork.Save();
        }

        public void EditProject(Project Project)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetAllProjects(int companyId)
        {
            return _officeUnitOfWork.ProjectRepository.GetAllProjects(companyId);
        }

        public Project GetProject(int id)
        {
            return _officeUnitOfWork.ProjectRepository.GetProjectByIncludingChild(id);
        }

        public Project GetProjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects(int companyId,int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _officeUnitOfWork.ProjectRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText) && x.CompanyId == companyId,
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
