using System.Collections.Generic;

namespace ProfileListingProject.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IList<DemoAccountUrl> DemoAccount { get; set; }//For client , admin , manager demo account
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}