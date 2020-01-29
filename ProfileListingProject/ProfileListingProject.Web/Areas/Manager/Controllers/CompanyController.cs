using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class CompanyController : Controller
    {
        private IOfficeManagementService _officeManagementService;
        public CompanyController(IOfficeManagementService officeManagementService)
        {
            _officeManagementService = officeManagementService;
        }
        public IActionResult Index()
        {
            var companies = _officeManagementService.GetAllCompanies();
            ViewBag.Companies = companies;
            return View();
        }
    }
}