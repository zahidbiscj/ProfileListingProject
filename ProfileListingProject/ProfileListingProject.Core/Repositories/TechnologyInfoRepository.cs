using ProfileListingProject.Core.Contexts;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Repositories.Interface;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfileListingProject.Core.Repositories
{
    public class TechnologyInfoRepository : Repository<TechnologyInfo>, ITechnologyInfoRepository
    {
        private StoreContext _context;
        public TechnologyInfoRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }
        public IList<TechnologyInfo> GetAllTechnologyInfo()
        {
            return _context.TechnologyInfos.ToList();
        }

    }
}
