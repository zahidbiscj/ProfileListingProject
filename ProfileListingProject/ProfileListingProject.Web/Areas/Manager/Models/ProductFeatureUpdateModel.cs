using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class ProductFeatureUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private IProductFeatureService _productFeatureService;

        public ProductFeatureUpdateModel()
        {
            _productFeatureService = Startup.AutoFacContainer.Resolve<IProductFeatureService>();
        }
        public ProductFeatureUpdateModel(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }

        public void EditProductFeature()
        {
            try
            {
                _productFeatureService.EditProductFeature(new ProductFeature
                {
                    Id = this.Id,
                    Name = this.Name,
                    Description = this.Description
                });
                Notification = new NotificationModel("success", "Product Feature Updated Successfully", NotificationType.Success);
            }

            catch (InvalidOperationException)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update Product, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update Product, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var productFeature = _productFeatureService.GetProductFeature(id);
            if (productFeature != null)
            {
                Id = productFeature.Id;
                Name = productFeature.Name;
                Description = productFeature.Description;
            }
        }
    }
}
