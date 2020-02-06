using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.UnitOfWorks
{
    public interface IOfficeUnitOfWork : IUnitOfWork<StoreContext>
    {
        ICompanyRepository CompanyRepository { get; set; }
    }
}
