using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class CategoryUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICategoryService _categoryService;

        public CategoryUpdateModel()
        {
            _categoryService = Startup.AutoFacContainer.Resolve<ICategoryService>();
        }

        public CategoryUpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void AddNewCategory()
        {
            try
            {
                _categoryService.AddNewCategory(new Category
                {
                    Name = this.Name
                });

                Notification = new NotificationModel("Success!", "Category successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }

        public void EditCategory()
        {
            try
            {
                _categoryService.EditCategory(new Category
                {
                    Id = this.Id,
                    Name = this.Name
                });

                Notification = new NotificationModel("Success!", "Category successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }
    }
}
