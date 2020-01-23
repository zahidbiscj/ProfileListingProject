using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Contexts
{
    public interface IStoreContext
    {
         DbSet<Category> Categories { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<ProductCategory> ProductCategories { get; set; }
         DbSet<PricingModel> PricingModels { get; set; }
         DbSet<ProductFeature> ProductFeatures { get; set; }
         DbSet<ProductScreenshot> ProductScreenshots { get; set; }
    }
}
