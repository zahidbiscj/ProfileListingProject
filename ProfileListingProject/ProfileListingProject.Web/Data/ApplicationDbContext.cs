using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfileListingProject.Core.Entities;

namespace ProfileListingProject.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ExtendedIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
