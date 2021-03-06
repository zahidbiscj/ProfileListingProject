﻿using ProfileListingProject.Core.Entities;
using ProfileListingProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Repositories.Interface
{
    public interface IAreaOfOperationsRepository : IRepository<AreaOfOperation>
    {
        IList<AreaOfOperation> GetAllAreaOfOperations();
    }
}
