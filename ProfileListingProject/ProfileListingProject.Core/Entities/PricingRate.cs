using ProfileListingProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class PricingRate
    {
        public int Id { get; set; }
        public RateType RateType { get; set; }
        public decimal Amount { get; set; }
        public CompanyService CompanyService { get; set; }
    }
}
