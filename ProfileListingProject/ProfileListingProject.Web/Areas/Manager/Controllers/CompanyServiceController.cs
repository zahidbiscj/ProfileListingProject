﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Enums;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager,Admin")]
    public class CompanyServiceController : Controller
    {
        public IActionResult Index()
        {
            var model = new CompanyServiceViewModel();
            return View(model);
        }

        public IActionResult GetCompanyService()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CompanyServiceViewModel();
            var company = model.GetCompany(userId);
            var data = model.GetCompanyServices(tableModel,company);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new CompanyServiceUpdateModel();
            ViewBag.rateType= Enum.GetNames(typeof(RateType));
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CompanyServiceUpdateModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                var uniqueFileName = model.GetUploadedImage(model.Image.FileName);
                model.AddNewService(uniqueFileName,userId);
            }
            ViewBag.rateType = Enum.GetNames(typeof(RateType));
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new CompanyServiceUpdateModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompanyServiceUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditCompanyService();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CompanyServiceUpdateModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}