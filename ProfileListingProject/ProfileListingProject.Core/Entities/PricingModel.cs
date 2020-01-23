using ProfileListingProject.Core.Enums;
using System.Collections.Generic;

namespace ProfileListingProject.Core.Entities
{
    public class PricingModel
    {
        public int Id { get; set; }
        public PricingType PricingType { get; set; }
        public decimal Amount { get; set; }
        public IList<ProductFeature> ProductFeature { get; set; }
        
    }
}