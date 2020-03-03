using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class CompanyUpdateModel : BaseModel
    {
        private const string bucketName = "aspnetpractice";
        private const string queueUrl = "https://sqs.us-east-1.amazonaws.com/441185707589/imageupload";

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public string OfficePhotoUrl { get; set; }
        public IFormFile ProfileImage { get; set; }
        public IFormFile OfficePhoto { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IList<AreaOfOperation> AreaOfOperations { get; set; }
        public IList<TechnologyInfo> TechnologyInfos { get; set; }
        public string[] TechnologyList { get; set; }
        public string[] AreaOfOperationsList { get; set; }
        public IList<Team> Teams { get; set; }
        private Company company;

        private IOfficeManagementService _officeService;
        public CompanyUpdateModel(IOfficeManagementService officeManagementService) 
        {
            _officeService = officeManagementService;
        }

        public CompanyUpdateModel()
        {
            _officeService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }

        public void GetDropDownList(string userId)
        {
            this.AreaOfOperations = _officeService.GetAllAreaOfOperations()
                .GroupBy(x => new {x.Name})
                .Select(x => x.First())
                .ToList();
            this.TechnologyInfos = _officeService.GetAllTechnologyInfos()
                .GroupBy(x => new { x.Name })
                .Select(x => x.First())
                .ToList();
            this.TechnologyInfos = this.TechnologyInfos.Select(x => new TechnologyInfo { Name = x.Name, Id = x.Id }).ToList();
            this.AreaOfOperations = this.AreaOfOperations.Select(x => new AreaOfOperation { Name = x.Name, Id = x.Id }).ToList();

        }

        public void AddTechnologyAreaOfOperation(string userId)
        {
            try
            {
                this.company = _officeService.GetCompanyByUserId(userId);
                this.TechnologyInfos = new List<TechnologyInfo>();
                this.AreaOfOperations = new List<AreaOfOperation>();

                if (TechnologyList != null)
                {
                    foreach (var item in TechnologyList)
                    {
                        TechnologyInfo technologyInfo = new TechnologyInfo()
                        {
                            Name = item,
                            CompanyId = this.company.Id
                        };
                        this.TechnologyInfos.Add(technologyInfo);
                    }
                    _officeService.AddTechnologyInfos(this.TechnologyInfos);

                }
                if (AreaOfOperationsList != null)
                {
                    foreach (var item in AreaOfOperationsList)
                    {
                        AreaOfOperation areaOfOperation = new AreaOfOperation()
                        {
                            Name = item,
                            CompanyId = this.company.Id
                        };
                        this.AreaOfOperations.Add(areaOfOperation);
                    }
                    _officeService.AddAreaOfOperations(this.AreaOfOperations);
                }
            }
            catch (Exception)
            {
                Notification = new NotificationModel("Failed !!", "Error in Area Of Operation or Technology Info", NotificationType.Fail);
                throw;
            }
        }

        
        public void EditCompany(string profileNewFileName, string officeNewFileName)
        {
            try
            {
                _officeService.EditCompany(new Company()
                {
                    Id = this.company.Id,
                    Name = this.Name,
                    Address = this.Address,
                    LogoImageUrl = profileNewFileName,
                    ShortDescription = this.ShortDescription,
                    Phone = this.Phone,
                    OfficePhotoUrl = officeNewFileName
                });
                Notification = new NotificationModel("Success", "Company Updated Successfully", NotificationType.Success);
            }
            catch (Exception e)
            {
                Notification = new NotificationModel("Failed !!", "Failed to Update Company Profile", NotificationType.Fail);
                throw e;
            }
        }
        public string GetRandomizedNewFileName(IFormFile imageFile)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFile.Name);
            var newFileName = $"{ randomName }{ Path.GetExtension(imageFile.FileName).ToLower()}";
            return newFileName;
        }

        public void Load(string userId)
        {
            this.company = _officeService.GetCompanyByUserId(userId);

            if (this.company != null)
            {
                Id = this.company.Id;
                Name = this.company.Name;
                Address = this.company.Address;
                ShortDescription = this.company.ShortDescription;
                Phone = this.company.Phone;
                LogoImageUrl = this.company.LogoImageUrl;
                OfficePhotoUrl = this.company.OfficePhotoUrl;
            }
        }

        public async Task<string> InsertImageToS3BucketAsync(IFormFile imageFile)
        {
            if (imageFile == null) { return null; }
            var newFileName = GetRandomizedNewFileName(imageFile);
            var path = $"wwwroot/download/{newFileName}";
            WriteFileInSystemDrive(path,imageFile);

            var client = new AmazonS3Client();
            var file = new FileInfo(path);
            await InsertImageToS3BucketAsync(file, newFileName, client);
            return newFileName;
        }

        public void WriteFileInSystemDrive(string path, IFormFile imageFile)
        {
            if (!System.IO.File.Exists(path))
            {
                using (var imageOpenWrite = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = imageFile.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageOpenWrite);
                    }
                }
            }
        }


        public async Task InsertImageToS3BucketAsync(FileInfo file, string newFileName, AmazonS3Client client)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                FilePath = file.FullName,
                Key = newFileName
            };
            var response = await client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                file.Delete();
            }
        }
    }
}
