using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProfileListingProject.Web.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
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