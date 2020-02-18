using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Entities;
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
        public IActionResult Result()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var company = new Company() { UserId = userId, Address = "sa", LogoImageUrl = "sa", Name = "assa", Phone = "21312" };
            //_officeManagementService.AddNewCompany(company);
            return View();
        }
        public IActionResult Index()
        {
            var companies = _officeManagementService.GetAllCompanies();
            ViewBag.NewMembers = companies.Reverse();
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
