using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager,Admin")]
    public class DashboardController : Controller
    {
        private IOfficeManagementService _officeManagementService;
        public DashboardController(IOfficeManagementService officeManagementService)
        {
            _officeManagementService = officeManagementService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var company = _officeManagementService.GetCompanyByUserId(userId);
            var companyWithChildTable = _officeManagementService.GetCompany(company.Id);
            ViewBag.ServicesCount = companyWithChildTable.Services.Count();
            ViewBag.ProductsCount = companyWithChildTable.Products.Count();
            ViewBag.ProjectsCount = companyWithChildTable.Projects.Count();
            return View();
        }
    }
}