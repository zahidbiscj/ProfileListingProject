using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Web.Areas.Admin.Models;

namespace ProfileListingProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public UserManager<IdentityUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public IEmailSender _emailSender;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public void GetUsers()
        {
            //return Json();
        }

        public IActionResult Add(string returnUrl = null)
        {
            var model = new UserUpdateModel();
            ViewBag.RoleList = (from r in _roleManager.Roles
                           select new SelectListItem
                           {
                               Text = r.Id,
                               Value = r.Name
                           }).ToList();
            model.ReturnUrl = returnUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserUpdateModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await model.AddNewUser(user);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        new NotificationModel("Failed !!", "Failed to Add User", NotificationType.Fail);
                    }
                }
            }
            ViewBag.RoleList = (from r in _roleManager.Roles
                                select new SelectListItem
                                {
                                    Text = r.Id,
                                    Value = r.Name
                                }).ToList();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }
    }
}