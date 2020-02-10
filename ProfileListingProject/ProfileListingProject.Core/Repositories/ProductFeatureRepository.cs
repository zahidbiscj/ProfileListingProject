using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories
{
    public class ProductFeatureRepository : Repository<ProductFeature>,IProductFeatureRepository
    {
        public ProductFeatureRepository(IStoreContext storeContext)
            :base((StoreContext)storeContext)
        {

        }
    }
}
