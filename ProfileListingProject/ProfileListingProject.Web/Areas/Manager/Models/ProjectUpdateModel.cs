using Autofac;
using Microsoft.AspNetCore.Http;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public ProjectUpdateModel()
        {
            _projectManagementService = Startup.AutoFacContainer.Resolve<IProjectManagementService>();
        }

        public ProjectUpdateModel(IProjectManagementService projectManagementService)
        {
            _projectManagementService = projectManagementService;
        }

        public void AddNewProject(string uniqueFileName)
        {
            try
            {
                _projectManagementService.AddNewProject(new Project
                {
                    Name = this.Name,
                    Description = this.Description,
                    DemoAccount = this.DemoAccount,
                    ImageUrl =  uniqueFileName
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

        internal void Delete(int id)
        {
            throw new NotImplementedException();
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
