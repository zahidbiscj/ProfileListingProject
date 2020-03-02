using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfileListingProject.Core.Repositories
{
    public class ProjectRepository : Repository<Project> , IProjectRepository
    {
        private StoreContext _context;
        public ProjectRepository(StoreContext storeContext)
            : base(storeContext)
        {
            _context = storeContext;
        }

        public IList<Project> GetAllProjects(int companyId)
        {
            return _context.Projects.Where(x => x.CompanyId == companyId).ToList();
        }

        public Project GetProjectByIncludingChild(int id)
        {
            return _context.Projects.Include(nameof(Project.DemoAccount)).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
