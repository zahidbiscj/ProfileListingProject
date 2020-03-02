using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Repositories;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.UnitOfWorks
{
    public class OfficeUnitOfWork : UnitOfWork<StoreContext>, IOfficeUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public ICompanyServiceRepository CompanyServiceRepository { get; set; }
        public ITeamRepository TeamRepository { get; set; }
        public ITechnologyInfoRepository TechnologyInfoRepository { get; set; }
        public IAreaOfOperationsRepository AreaOfOperationsRepository { get; set; }

        public OfficeUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CompanyRepository = new CompanyRepository(_dbContext);
            ProjectRepository = new ProjectRepository(_dbContext);
            CompanyServiceRepository = new CompanyServiceRepository(_dbContext);
            TeamRepository = new TeamRepository(_dbContext);
            TechnologyInfoRepository = new TechnologyInfoRepository(_dbContext);
            AreaOfOperationsRepository = new AreaOfOperationsRepository(_dbContext);
        }
    }
}
