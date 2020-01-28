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
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private StoreContext _context;
        public ProductCategoryRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
        public ProductCategory GetProductCategoryByProductId(int productId)
        {
            return _context.ProductCategories.Where(x => x.ProductId == productId).FirstOrDefault();
        }
    }
}
