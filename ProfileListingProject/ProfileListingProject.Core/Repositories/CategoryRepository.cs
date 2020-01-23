using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
