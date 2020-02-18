using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Admin.Models
{
    public class UserUpdateModel : BaseModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string ReturnUrl { get; set; }

        public UserManager<ExtendedIdentityUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public UserUpdateModel()
        {
            _userManager = Startup.AutoFacContainer.Resolve<UserManager<ExtendedIdentityUser>>();
            _roleManager = Startup.AutoFacContainer.Resolve<RoleManager<IdentityRole>>();
        }
        public UserUpdateModel(UserManager<ExtendedIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddNewUser(ExtendedIdentityUser user)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, this.Password);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(this.Role);
                    var roleResult = await _userManager.AddToRoleAsync(user, role.Name);

                    if (roleResult.Succeeded)
                    {
                        Notification = new NotificationModel("Success !!", "Successfully Added User", NotificationType.Success);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                Notification = new NotificationModel("Failed !!", "Failed to Add User", NotificationType.Fail);
                throw e;
            }
            return null;
        }
    }
}
