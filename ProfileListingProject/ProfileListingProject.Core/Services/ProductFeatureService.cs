using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services
{
    public class ProductFeatureService : IProductFeatureService
    {
        private IStoreUnitOfWork _storeUnitOfWork;
        public ProductFeatureService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }
        public IEnumerable<ProductFeature> GetFeatures(int pageIndex,
            int pageSize,
            string searchText,
            out int total, 
            out int totalFiltered)
        {
            return _storeUnitOfWork.ProductFeatureRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
