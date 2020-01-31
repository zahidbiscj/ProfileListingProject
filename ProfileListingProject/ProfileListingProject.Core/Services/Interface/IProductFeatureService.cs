using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface IProductFeatureService
    {
        IEnumerable<ProductFeature> GetFeatures(int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);

        ProductFeature GetProductFeature(int id);
        void EditProductFeature(ProductFeature productFeature);
        void DeleteProductFeature(int id);

        ProductFeature GetProductFeatureByName(string name);
    }
}
