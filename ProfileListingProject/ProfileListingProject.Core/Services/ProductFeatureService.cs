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

        public void DeleteProductFeature(int id)
        {
            _storeUnitOfWork.ProductFeatureRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditProductFeature(ProductFeature productFeature)
        {
            var oldProductFeature = _storeUnitOfWork.ProductFeatureRepository.GetById(productFeature.Id);
            oldProductFeature.Name = productFeature.Name;
            oldProductFeature.Description = productFeature.Description;
            _storeUnitOfWork.Save();
        }

        public IEnumerable<ProductFeature> GetFeatures(
            int productId,
            int pageIndex,
            int pageSize,
            string searchText,
            out int total, 
            out int totalFiltered)
        {
            return _storeUnitOfWork.ProductFeatureRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText) && x.ProductId == productId,
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public ProductFeature GetProductFeature(int id)
        {
            return _storeUnitOfWork.ProductFeatureRepository.GetById(id);
        }

        public ProductFeature GetProductFeatureByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
