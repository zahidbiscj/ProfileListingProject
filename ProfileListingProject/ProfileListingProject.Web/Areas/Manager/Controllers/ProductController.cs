﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Web.Areas.Manager.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            return View();
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
            return View(model);
        }
    }
}