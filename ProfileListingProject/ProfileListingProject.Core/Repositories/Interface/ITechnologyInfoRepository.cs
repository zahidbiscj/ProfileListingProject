using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface ITechnologyInfoRepository : IRepository<TechnologyInfo>
    {
        IList<TechnologyInfo> GetAllTechnologyInfo();
    }
}
