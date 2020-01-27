using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfileListingProject.Core.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private StoreContext _context;
        public CategoryRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
