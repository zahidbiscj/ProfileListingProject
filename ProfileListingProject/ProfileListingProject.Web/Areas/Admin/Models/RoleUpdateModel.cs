using Autofac;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Admin.Models
{
    public class RoleUpdateModel : BaseModel
    {
        public string RoleName { get; set; }
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleUpdateModel()
        {
            _roleManager = Startup.AutoFacContainer.Resolve<RoleManager<IdentityRole>>();
        }
        public async Task AddNewRole()
        {
            try
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = RoleName });
                Notification = new NotificationModel("Success", "Successfully Added Role", NotificationType.Success);
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
    }
}
