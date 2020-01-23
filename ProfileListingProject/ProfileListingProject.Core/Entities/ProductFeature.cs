﻿namespace ProfileListingProject.Core.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}