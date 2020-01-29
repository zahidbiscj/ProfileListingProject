using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Contexts
{
    public interface IOfficeContext
    {
         DbSet<Company> Companies { get; set; }
    }
}
