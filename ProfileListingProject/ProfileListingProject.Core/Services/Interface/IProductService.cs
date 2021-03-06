﻿using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Services.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(
            int companyId,
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewProduct(Product product);
        Product GetProduct(int id);
        void EditProduct(Product product);
        void DeleteProduct(int id);
        Product GetProductByName(string name);
        ProductCategory GetProductCategory(int productId);
        IList<Product> GetAllProductsOfCompany(int companyId);
    }
}
