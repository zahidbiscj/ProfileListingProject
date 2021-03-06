﻿using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompaniesIncludingChild(int id);
        Company GetCompanyByUserId(string userId);
    }
}
