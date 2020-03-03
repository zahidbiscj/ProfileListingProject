using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager,Admin")]
    public class ProductFeatureController : Controller
    {
        private IProductFeatureService _productFeatureService;
        public ProductFeatureController(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }
        public IActionResult Index(int id)
        {
            var model = new ProductFeatureViewModel();
            TempData["productId"] = id;
            return View(model);
        }
        [HttpGet]
        public IActionResult GetProductFeature()
        {
            var productIdString = TempData["productId"].ToString();
            var productId = int.Parse(productIdString);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductFeatureViewModel();
            //var company = model.GetCompany(userId);
            var data = model.GetProductFeature(tableModel,productId);
            return Json(data);
            
        }

        public IActionResult Edit(int id)
        {
            var model = new ProductFeatureUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFeatureUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditProductFeature();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ProductFeatureViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            var model = new ProductFeatureUpdateModel();
            return View();
        }
    }
}