﻿using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface ICompanyServiceRepository : IRepository<CompanyService>
    {
        CompanyService GetServiceWithPricingRate(int id);
        IList<CompanyService> GetAllServicesOfCompany(int companyId);
    }
}
