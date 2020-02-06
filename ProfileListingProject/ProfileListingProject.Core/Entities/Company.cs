using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public string OfficePhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IList<AreaOfOperation> AreaOfOperations { get; set; }
        public IList<TechnologyInfo> TechnologyInfos { get; set; }
        public IList<Team> Teams { get; set; }

        public IList<CompanyService> Services { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
