using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Contexts
{
    public class StoreContext : DbContext,IStoreContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public StoreContext(string connectionString,string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, m =>
                                m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {        
            builder.Entity<Product>()
                .HasMany(x => x.PricingModels);
            builder.Entity<Product>()
                .HasMany(x => x.ProductFeatures);
            builder.Entity<Company>()
                .HasMany(x => x.AreaOfOperations);
            builder.Entity<Company>()
                .HasMany(x => x.TechnologyInfos);
            builder.Entity<Company>()
                .HasMany(x => x.Teams);
            builder.Entity<Company>()
                .HasMany(x => x.Products);
            builder.Entity<Company>()
                .HasMany(x => x.Projects);
            builder.Entity<Company>()
                .HasMany(x => x.Services);

            builder.Entity<Project>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CompanyId);

            builder.Entity<CompanyService>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.CompanyId);

            builder.Entity<Project>()
                .HasMany(x => x.DemoAccount)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            ///Electronics -> Mobile -> samsung -> samsung galaxy 
            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(pc => pc.CategoryId);

            base.OnModelCreating(builder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AreaOfOperation> AreaOfOperations { get; set; }
        public DbSet<TechnologyInfo> TechnologyInfos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PricingRate> PricingRates { get; set; }

    }
}
