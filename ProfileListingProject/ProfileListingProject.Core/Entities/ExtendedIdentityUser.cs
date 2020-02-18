using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileListingProject.Core.Entities
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public Company Company { get; set; }
    }
}
