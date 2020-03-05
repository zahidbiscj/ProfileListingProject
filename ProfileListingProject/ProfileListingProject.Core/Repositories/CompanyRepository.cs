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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private StoreContext _context;
        public CompanyRepository(StoreContext context)
            :base(context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            
            return _context.Companies.ToList();
        }

        public Company GetCompaniesIncludingChild(int id)
        {
            return _context.Companies.Where(x => x.Id == id)
                .Include(nameof(Company.AreaOfOperations))
                .Include(nameof(Company.TechnologyInfos))
                .Include(nameof(Company.Services))
                .Include(nameof(Company.Teams))
                .Include(nameof(Company.Projects))
                .Include(nameof(Company.Products)).FirstOrDefault();
        }

        public Company GetCompanyByUserId(string userId)
        {
            return _context.Companies.Where(x => x.UserId == userId).FirstOrDefault();
        }
    }
}
