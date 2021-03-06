﻿using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string name);
        Product GetProductByIdWithChild(int id);
        IList<Product> GetAllProductsOfCompany(int companyId);
    }
}
