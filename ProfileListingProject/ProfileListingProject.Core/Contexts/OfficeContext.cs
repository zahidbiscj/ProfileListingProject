using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Contexts
{
    public class OfficeContext : DbContext, IOfficeContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public OfficeContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, m =>
                                m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
        
        public DbSet<Company> Companies { get; set; }

    }
}
