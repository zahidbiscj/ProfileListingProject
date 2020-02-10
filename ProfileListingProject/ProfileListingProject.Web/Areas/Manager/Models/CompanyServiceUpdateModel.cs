using Autofac;
using Microsoft.AspNetCore.Http;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Enums;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class CompanyServiceUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public PricingRate PricingRate { get; set; }
        public int CompanyId { get; set; }

        private IServiceManagement _companyServiceManagement;

        public CompanyServiceUpdateModel()
        {
            _companyServiceManagement = Startup.AutoFacContainer.Resolve<IServiceManagement>();
        }

        public CompanyServiceUpdateModel(IServiceManagement serviceManagement)
        {
            _companyServiceManagement = serviceManagement;
        }
        public void AddNewService(string uniqueFileName)
        {
            try
            {
                _companyServiceManagement.AddNewCompanyService(new CompanyService
                {
                    Name = this.Name,
                    Description = this.Description,
                    PricingRate = this.PricingRate,
                    ImageUrl = uniqueFileName,
                    CompanyId = 2
                });
                Notification = new NotificationModel("Success", "Company Service Added Successfully", NotificationType.Success);
            }
            catch (Exception e)
            {
                Notification = new NotificationModel("Failed", "Failed to Add Company Service", NotificationType.Fail);
                throw e;
            }
        }

        public void EditCompanyService()
        {
            _companyServiceManagement.EditCompanyService(new CompanyService
            {
                Name = this.Name,
                PricingRate = this.PricingRate,
                Description = this.Description,
                CompanyId = this.CompanyId
            });
        }

        public void Delete(int id)
        {
            _companyServiceManagement.DeleteCompanyService(id);
        }

        public string GetUploadedImage(string imageFileName)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFileName);
            var newpath = $"{ randomName }{ Path.GetExtension(imageFileName).ToLower()}";

            var path = $"wwwroot/images/{randomName}{Path.GetExtension(imageFileName)}";

            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = Image.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }
            return newpath;
        }

        public void Load(int id)
        {
            var companyService = _companyServiceManagement.GetCompanyService(id);
            if(companyService != null)
            {
                Id = companyService.Id;
                Name = companyService.Name;
                Description = companyService.Description;
                PricingRate = companyService.PricingRate;
                ImageUrl = companyService.ImageUrl;
            }
        }
    }
}
