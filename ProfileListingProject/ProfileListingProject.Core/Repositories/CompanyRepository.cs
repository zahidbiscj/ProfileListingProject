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
        private OfficeContext _context;
        public CompanyRepository(OfficeContext context)
            :base(context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }
    }
}
