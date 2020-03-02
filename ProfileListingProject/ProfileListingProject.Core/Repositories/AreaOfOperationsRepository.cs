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
    public class AreaOfOperationsRepository : Repository<AreaOfOperation>, IAreaOfOperationsRepository
    {
        private StoreContext _context;
        public AreaOfOperationsRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public IList<AreaOfOperation> GetAllAreaOfOperations()
        {
            return _context.AreaOfOperations.ToList();
        }
    }
}
