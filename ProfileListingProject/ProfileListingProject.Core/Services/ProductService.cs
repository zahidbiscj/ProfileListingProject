using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services
{
    public class ProductService : IProductService
    {
        private IStoreUnitOfWork _storeUnitOfWork;
        public ProductService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }
        public void AddNewProduct(Product product)
        {
            _storeUnitOfWork.ProductRepository.Add(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Categories = product.Categories,
                ImageUrl = product.ImageUrl,
                ProductFeatures = product.ProductFeatures,
                CompanyId = product.CompanyId
            });
            _storeUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _storeUnitOfWork.ProductRepository.GetProductByIdWithChild(id);
            foreach (var productFeature in product.ProductFeatures)
            {
                _storeUnitOfWork.ProductFeatureRepository.Remove(productFeature);
            }
            _storeUnitOfWork.ProductRepository.Remove(id);

            _storeUnitOfWork.Save();
        }

        public void EditProduct(Product product)
        {
            var oldProduct = _storeUnitOfWork.ProductRepository.GetById(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.ImageUrl = product.ImageUrl;
            _storeUnitOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            return _storeUnitOfWork.ProductRepository.GetById(id);
        }

        public Product GetProductByName(string name)
        {
            return _storeUnitOfWork.ProductRepository.GetProductByName(name);
        }

        public ProductCategory GetProductCategory(int productId)
        {
            return _storeUnitOfWork.ProductCategoryRepository.GetProductCategoryByProductId(productId);
        }

        public IEnumerable<Product> GetProducts(int companyId,
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.ProductRepository.Get(
               out total,
               out totalFiltered,
               x => x.Name.Contains(searchText) && x.CompanyId == companyId,
               null,
               "",
               pageIndex,
               pageSize,
               true);
        }
    }
}
