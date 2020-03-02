using Autofac;
using Microsoft.AspNetCore.Http;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class ProjectUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public IList<DemoAccountUrl> DemoAccount { get; set; }
        public int CompanyId { get; set; }
        private IProjectManagementService _projectManagementService;
        private IOfficeManagementService _officeManagementService;

        public ProjectUpdateModel()
        {
            _projectManagementService = Startup.AutoFacContainer.Resolve<IProjectManagementService>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }

        public ProjectUpdateModel(IProjectManagementService projectManagementService, IOfficeManagementService officeManagementService)
        {
            _projectManagementService = projectManagementService;
            _officeManagementService = officeManagementService;
        }

        public void AddNewProject(string uniqueFileName,string userId)
        {
            try
            {
                var company = _officeManagementService.GetCompanyByUserId(userId);
                _projectManagementService.AddNewProject(new Project
                {
                    Name = this.Name,
                    Description = this.Description,
                    DemoAccount = this.DemoAccount,
                    ImageUrl =  uniqueFileName,
                    CompanyId = company.Id
                });
                Notification = new NotificationModel("success", "Project Added Successfully", NotificationType.Success);
            }
            catch (Exception)
            {
                Notification = new NotificationModel("Failed", "Failed to Project Add", NotificationType.Fail);
            }
        }

        internal void EditProject()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _projectManagementService.DeleteProject(id);
        }

        public void Load(int id)
        {
            //var category = _categoryService.GetCategory(id);
            //if (category != null)
            //{
            //    Id = category.Id;
            //    Name = category.Name;
            //}
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
    }
}
