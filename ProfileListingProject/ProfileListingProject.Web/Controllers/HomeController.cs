using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private IOfficeManagementService _officeManagementService;
        public HomeController(IOfficeManagementService officeManagementService)
        {
            _officeManagementService = officeManagementService;
        }
        public IActionResult Index()
        {
            var companies = _officeManagementService.GetAllCompanies();
            //var a = companies.Reverse();
            ViewBag.Companies = companies;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
