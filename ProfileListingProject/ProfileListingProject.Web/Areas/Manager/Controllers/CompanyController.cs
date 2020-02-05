﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            //var companies = _officeManagementService.GetAllCompanies();
            //ViewBag.Companies = companies;

            var sqsClient = new AmazonSQSClient();
            var sqsResponse = await sqsClient.ReceiveMessageAsync("https://sqs.us-east-1.amazonaws.com/847888492411/codesubmission");
            if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                foreach (var message in sqsResponse.Messages)
                {
                    var fileName = message.Body.Replace("name: ", "").Trim('\'');
                    var s3Client = new AmazonS3Client();

                    var s3Request = new GetObjectRequest
                    {
                        BucketName = "aspnetclassimage",
                        Key = fileName
                    };

                    var response = await s3Client.GetObjectAsync(s3Request);

                    var deleteQueueItemRequest = new DeleteMessageRequest("https://sqs.us-east-1.amazonaws.com/847888492411/codesubmission", message.ReceiptHandle);
                    await sqsClient.DeleteMessageAsync(deleteQueueItemRequest);
                }
            }
            return View();

        }

        public IActionResult Add()
        {
            var model = new CompanyUpdateModel();
            return View(model);
        }

        //Add Image to S3 Bucket 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CompanyUpdateModel model)
        {
            try
            {
                await model.InsertImageToS3BucketAsync();
                if (ModelState.IsValid)
                {
                    model.AddNewCompany();
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