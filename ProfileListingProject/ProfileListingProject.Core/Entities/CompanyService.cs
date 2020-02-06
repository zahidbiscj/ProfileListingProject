using ProfileListingProject.Core.Enums;

namespace ProfileListingProject.Core.Entities
{
    public class CompanyService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public RateType PricingRate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}