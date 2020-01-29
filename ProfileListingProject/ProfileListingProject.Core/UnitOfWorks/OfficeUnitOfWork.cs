﻿using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.UnitOfWorks
{
    public class OfficeUnitOfWork : UnitOfWork<OfficeContext>, IOfficeUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public OfficeUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CompanyRepository = new CompanyRepository(_dbContext);
        }
    }
}
