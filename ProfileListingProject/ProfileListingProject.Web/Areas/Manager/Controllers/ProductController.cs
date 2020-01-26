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
            if(ModelState.IsValid)
            {
                model.AddNewProduct();
            }
            return View(model);
        }
    }
}