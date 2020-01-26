using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork<StoreContext>, IStoreUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductFeatureRepository ProductFeatureRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public StoreUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductFeatureRepository = new ProductFeatureRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
        }
    }
}
