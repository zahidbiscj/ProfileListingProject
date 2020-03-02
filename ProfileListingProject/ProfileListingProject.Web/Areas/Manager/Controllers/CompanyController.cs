using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Areas.Manager.Models;

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
        

        public IActionResult Update()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new CompanyUpdateModel();
            model.GetDropDownList(userId);
            model.Load(userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CompanyUpdateModel model)
        {
            try
            {
                string profileNewFileName, officeNewFileName;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                 profileNewFileName = await model.InsertImageToS3BucketAsync(model.ProfileImage);
                 officeNewFileName =  await model.InsertImageToS3BucketAsync(model.OfficePhoto);

                if (ModelState.IsValid)
                {
                    model.AddTechnologyAreaOfOperation(userId);
                    model.EditCompany(profileNewFileName,officeNewFileName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(model);
        }
    }
}