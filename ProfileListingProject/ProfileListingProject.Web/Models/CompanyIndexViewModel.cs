using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Models
{
    public class CompanyIndexViewModel
    {
        private const string bucketName = "aspnetpractice";
        public async Task DownloadCompanyProfileImageAsync(string logoImageUrl)
        {
            var s3Client = new AmazonS3Client();

            var s3Request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = logoImageUrl
            };
            var fullPath = new FileInfo(logoImageUrl).FullName;

            var response = await s3Client.GetObjectAsync(s3Request);
            var token = new CancellationToken();
            await response.WriteResponseStreamToFileAsync("wwwroot/download/"+logoImageUrl, false, token);
        }

        public async Task DownloadCompanyOfficePhotoAsync(string officePhotoUrl)
        {
            var s3Client = new AmazonS3Client();

            var s3Request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = officePhotoUrl
            };
            var fullPath = new FileInfo(officePhotoUrl).FullName;

            var response = await s3Client.GetObjectAsync(s3Request);
            var token = new CancellationToken();
            await response.WriteResponseStreamToFileAsync("wwwroot/download/"+officePhotoUrl, false, token);
        }

        public bool CheckAvailabilityFile(string logoImageUrl)
        {
            if (File.Exists("wwwroot/download/" + logoImageUrl))
            {
                return true;
            }
            else { return false; }
        }
    }
}
