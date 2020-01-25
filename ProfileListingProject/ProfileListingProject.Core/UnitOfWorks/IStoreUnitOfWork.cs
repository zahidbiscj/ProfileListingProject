using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork<StoreContext>
    {
        ICategoryRepository CategoryRepository { get; set; }
        IProductFeatureRepository ProductFeatureRepository { get; set; }
    }
}
