using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ProductFeatureController : Controller
    {
        private IProductFeatureService _productFeatureService;
        public ProductFeatureController(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }
        public IActionResult Index()
        {
            var model = new ProductFeatureViewModel();
            return View(model);
        }
        [HttpGet]
        public IActionResult GetProductFeature()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductFeatureViewModel();
            var data = model.GetProductFeature(tableModel);
            return Json(data);
            
        }

        public IActionResult Add()
        {
            var model = new ProductFeatureUpdateModel();
            return View();
        }
    }
}