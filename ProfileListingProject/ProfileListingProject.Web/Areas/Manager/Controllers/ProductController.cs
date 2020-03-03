using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager,Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductViewModel();
            var company = model.GetCompany(userId);
            var data = model.GetProducts(tableModel);
            return Json(data);
        }

        public IActionResult ProductIdPass(int id)
        {
            return RedirectToAction("Index", "ProductFeature", new { area = "Manager", id = id });
        }

        public IActionResult Add()
       {
            var model = new ProductUpdateModel();
            var categories = model.GetAllCategoryList();
            ViewBag.CategoryList = categories;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                string path = null;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (model.Image != null)
                {
                    path = model.GetUploadedImage(model.Image.FileName);
                }
                model.AddNewProduct(path,userId);
            }
            var categories = model.GetAllCategoryList();
            ViewBag.CategoryList = categories;
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new ProductUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditProduct();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ProductViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}