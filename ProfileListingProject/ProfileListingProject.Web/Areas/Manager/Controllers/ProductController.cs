using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductViewModel();
            var data = model.GetProducts(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new ProductUpdateModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                string path = null;
                if (model.Image != null)
                {
                    model.GetUploadedImage(model.Image.FileName);
                    
                }
                model.AddNewProduct(path);
            }

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
            return View(model);
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