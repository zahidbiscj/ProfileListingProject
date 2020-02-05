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
        private const string bucketName = "zahidaspnetclassimage";
        private const string queueUrl = "https://sqs.us-east-1.amazonaws.com/441185707589/codesubmission";
        private string newFileName;

        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ProfileImage { get; set; }//LogoImageUrl
        //public string OfficePhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IList<AreaOfOperation> AreaOfOperations { get; set; }
        public IList<TechnologyInfo> TechnologyInfos { get; set; }
        public IList<Team> Teams { get; set; }

        private IOfficeManagementService _officeService;
        public CompanyUpdateModel(IOfficeManagementService officeManagementService) 
        {
            _officeService = officeManagementService;
        }

        public CompanyUpdateModel()
        {
            _officeService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }

        public void AddNewCompany()
        {
            try
            {
                _officeService.AddNewCompany(new Company()
                {
                    Name = this.Name,
                    Address = this.Address,
                    LogoImageUrl = newFileName,
                    ShortDescription = this.ShortDescription,
                    Phone = this.Phone,
                    //OfficePhotoUrl = this.OfficePhotoUrl
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetRandomizedNewFileName(IFormFile imageFile)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFile.Name);
            newFileName = $"{ randomName }{ Path.GetExtension(imageFile.FileName).ToLower()}";
            return newFileName;
        }

        public async Task InsertImageToS3BucketAsync()
        {
            var newFileName = GetRandomizedNewFileName(this.ProfileImage);
            var path = $"wwwroot/images/{newFileName}";
            WriteFileInSystemDrive(path);

            var client = new AmazonS3Client();
            var file = new FileInfo(path);
            await InsertImageToS3BucketAsync(file, newFileName, client);
        }

        public void WriteFileInSystemDrive(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = this.ProfileImage.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);
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
                var sqsClient = new AmazonSQSClient();
                var sqsRequest = new SendMessageRequest
                {
                    QueueUrl = queueUrl,
                    MessageBody = $"name: '{newFileName}'"
                };

                var sqsResponse = await sqsClient.SendMessageAsync(sqsRequest);
                if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    file.Delete();
                }
            }
        }
    }
}
