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
            : base((StoreContext)storeContext)
        {
            _storeContext = storeContext;
        }

        public Product GetProductByName(string name)
        {
            return _storeContext.Products.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
