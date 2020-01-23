using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        public IActionResult GetCategories()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CategoryViewModel();
            var data = model.GetCategories(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new CategoryUpdateModel();
            return View(model);
        }
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewCategory();
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new CategoryUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditCategory();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CategoryViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}