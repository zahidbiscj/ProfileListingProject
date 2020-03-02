using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        IList<Project> GetAllProjects(int companyId);
        Project GetProjectByIncludingChild(int id);
    }
}
