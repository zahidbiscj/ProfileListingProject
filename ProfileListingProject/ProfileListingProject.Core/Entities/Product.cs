using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IList<ProductCategory> Categories { get; set; }
        public IList<ProductFeature> ProductFeatures { get; set; }
        public IList<PricingModel> PricingModels { get; set; }

    }
}
