﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager,Admin")]
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProjectViewModel();
            return View(model);
        }

        public IActionResult GetProjects()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProjectViewModel();
            var company = model.GetCompany(userId);
            var data = model.GetProjects(tableModel,company.Id);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new ProjectUpdateModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProjectUpdateModel model)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var path = model.GetUploadedImage(model.Image.FileName);
                model.AddNewProject(path,userId);
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new ProjectUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjectUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                //model.EditProject();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ProjectUpdateModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}