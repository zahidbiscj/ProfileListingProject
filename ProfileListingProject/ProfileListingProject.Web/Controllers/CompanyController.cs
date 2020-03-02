using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Controllers
{
    public class CompanyController : Controller
    {
        public IOfficeManagementService _officeManagementService;
        public IServiceManagement _serviceManagement;
        private IProductService _productService;
        private IProjectManagementService _projectManagementService;
        public CompanyController(IOfficeManagementService officeManagementService,IServiceManagement serviceManagement,IProductService productService,IProjectManagementService projectManagementService)
        {
            _officeManagementService = officeManagementService;
            _serviceManagement = serviceManagement;
            _productService = productService;
            _projectManagementService = projectManagementService;
        }
        
        public async Task<IActionResult> Index(int id)
        {
            var company = _officeManagementService.GetCompany(id);
            var model = new CompanyIndexViewModel();
            // if Image Not Found in the local directory then download from S3 Bucket
            if (model.CheckAvailabilityFile(company.LogoImageUrl) == false)
            {
                await new CompanyIndexViewModel().DownloadCompanyProfileImageAsync(company.LogoImageUrl);
            }
            if(model.CheckAvailabilityFile(company.OfficePhotoUrl) == false)
            {
                await new CompanyIndexViewModel().DownloadCompanyOfficePhotoAsync(company.OfficePhotoUrl);
            }
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

        [HttpGet("/Company/{companyId}/Projects")]
        public IActionResult Projects(int companyId)
        {
            var company = _officeManagementService.GetCompany(companyId);
            ViewBag.Projects = company.Projects;
            return View(company.Projects);
        }


        [HttpGet("/Company/ProjectView/{id}")]
        public IActionResult ProjectView(int id)
        {
            var project = _projectManagementService.GetProject(id);
            ViewBag.Project = project;
            return View(project);
        }

        [HttpGet("/Company/{companyId}/Products")]
        public IActionResult Products(int companyId)
        {
            var company = _officeManagementService.GetCompany(companyId);
            ViewBag.Products = company.Products;
            return View(company.Products);
        }


        [HttpGet("/Company/ProductView/{id}")]
        public IActionResult ProductView(int id)
        {
            var product = _productService.GetProduct(id);
            ViewBag.Products = product;
            return View(product);
        }
    }
}