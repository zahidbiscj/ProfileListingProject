using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;

namespace ProfileListingProject.Web.Controllers
{
    public class CompanyController : Controller
    {
        public IOfficeManagementService _officeManagementService;
        public CompanyController(IOfficeManagementService officeManagementService)
        {
            _officeManagementService = officeManagementService;
        }
        public IActionResult Index(int id)
        {
            var company = _officeManagementService.GetCompany(id);
            return View(company);
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }
    }
}