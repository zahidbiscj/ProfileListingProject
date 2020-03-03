using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Admin.Models
{
    public class CompanyUpdateModel : BaseModel
    {
		public string Email { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; } // Company Name
		public string Role { get; set; }
		public List<SelectListItem> Roles { get; set; }

		private IOfficeManagementService _officeManagementService;
		private readonly UserManager<ExtendedIdentityUser> _userManager;

		private readonly RoleManager<IdentityRole> _roleManager;
		public CompanyUpdateModel(IOfficeManagementService officeManagementService, UserManager<ExtendedIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_officeManagementService = officeManagementService;
		}

		public CompanyUpdateModel()
		{
			_officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
			_userManager = Startup.AutoFacContainer.Resolve<UserManager<ExtendedIdentityUser>>();
			_roleManager = Startup.AutoFacContainer.Resolve<RoleManager<IdentityRole>>();
		}

		public List<SelectListItem> GetAllRoles()
		{
			var roles = (from r in _roleManager.Roles
			 select new SelectListItem
			 {
				 Value = r.Id,
				 Text = r.Name
			 }).ToList();
			return roles;
		}

        public async Task AddNewCompany()
        {
			try
			{
				var user = await _userManager.FindByEmailAsync(this.Email);
				_officeManagementService.AddNewCompany(new Company
				{
					Name = this.Name,
					UserId = user.Id
				});
				var role = await _roleManager.FindByIdAsync(this.Role);
				var roleResult = await _userManager.AddToRoleAsync(user, role.Name);

				Notification = new NotificationModel("Success !!", "Company Added Successfully", NotificationType.Success);
			}
			catch (Exception e)
			{
				Notification = new NotificationModel("Failed", "Failed to Add Company", NotificationType.Fail);
				throw e;
			}
        }

		public async Task UserAssignToRoles()
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(this.Email);
				var role = await _roleManager.FindByIdAsync(this.Role);
				var roleResult = await _userManager.AddToRoleAsync(user, role.Name);

				Notification = new NotificationModel("Success !!", "User Assigned to Role Successfully", NotificationType.Success);
			}
			catch (Exception e)
			{
				Notification = new NotificationModel("Failed", "Failed to Assign User Role", NotificationType.Fail);
				throw e;
			}
		}

	}
}
