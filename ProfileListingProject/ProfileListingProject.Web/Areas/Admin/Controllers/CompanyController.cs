using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Web.Areas.Admin.Models;

namespace ProfileListingProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult Add()
        {
            var model = new CompanyUpdateModel();
            model.Roles = model.GetAllRoles();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CompanyUpdateModel model)
        {
            if(ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    await model.UserAssignToRoles();
                }
                else
                {
                    await model.AddNewCompany();
                }
            }
            model.Roles = model.GetAllRoles();
            return View(model);
        }
    }
}