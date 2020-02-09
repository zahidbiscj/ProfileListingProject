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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private IStoreContext _storeContext;
        public ProductRepository(IStoreContext storeContext)
            : base((OfficeContext)storeContext)
        {
            _storeContext = storeContext;
        }

        public Product GetProductByIdWithChild(int id)
        {
            return _storeContext.Products.Where(x => x.Id == id)
                .Include(nameof(Product.Categories))
                .Include(nameof(Product.ProductFeatures))
                .FirstOrDefault();
        }

        public Product GetProductByName(string name)
        {
            return _storeContext.Products.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
