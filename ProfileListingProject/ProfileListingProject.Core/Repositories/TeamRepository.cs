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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private StoreContext _context;
        public TeamRepository(StoreContext dbContext)
            : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Team> GetAllTeamList()
        {
            return _context.Teams.ToList();
        }
    }
}