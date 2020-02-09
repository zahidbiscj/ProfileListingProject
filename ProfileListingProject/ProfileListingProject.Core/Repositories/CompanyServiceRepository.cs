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
    public class CompanyServiceRepository : Repository<CompanyService>, ICompanyServiceRepository
    {
        private OfficeContext _context;
        public CompanyServiceRepository(OfficeContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public CompanyService GetServiceWithPricingRate(int id)
        {
            return _context.CompanyServices.Where(x => x.Id == id)
                .Include(nameof(CompanyService.PricingRate)).FirstOrDefault();
        }
    }
}
