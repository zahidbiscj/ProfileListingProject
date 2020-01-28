using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public IList<ProductCategory> Categories { get; set; }
        public IList<ProductFeature> ProductFeatures { get; set; }
        public IList<PricingModel> PricingModels { get; set; }

    }
}
