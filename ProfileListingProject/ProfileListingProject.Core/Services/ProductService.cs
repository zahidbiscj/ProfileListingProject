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
                ProductFeatures = product.ProductFeatures

            });
            _storeUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            return _storeUnitOfWork.ProductRepository.GetProductByName(name);
        }

        public IEnumerable<Product> GetProducts(int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.ProductRepository.Get(
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
