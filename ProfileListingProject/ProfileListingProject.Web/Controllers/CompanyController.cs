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
        public IServiceManagement _serviceManagement;
        private IProductService _productService;
        public CompanyController(IOfficeManagementService officeManagementService,IServiceManagement serviceManagement,IProductService productService)
        {
            _officeManagementService = officeManagementService;
            _serviceManagement = serviceManagement;
            _productService = productService;
        }
        public IActionResult Index(int id)
        {
            var company = _officeManagementService.GetCompany(id);
            return View(company);
        }
        [HttpGet("/Company/{companyId}/Services")]
        public IActionResult Services(int companyId)
        {
            var company = _officeManagementService.GetCompany(companyId);
            var services = _serviceManagement.GetAllServicesOfCompany(company.Id);
            ViewBag.Services = services;
            return View(services);
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