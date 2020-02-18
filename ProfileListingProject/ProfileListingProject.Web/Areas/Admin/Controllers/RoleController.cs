using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Web.Areas.Admin.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<ExtendedIdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var model = new RoleViewModel();
            return View(model);
        }

        public IActionResult GetRoles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new RoleViewModel();
            var data = model.GetRoles(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new RoleUpdateModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleUpdateModel model)
        {
            if(ModelState.IsValid)
            {
                await model.AddNewRole();
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var model = new RoleViewModel();
            await model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}