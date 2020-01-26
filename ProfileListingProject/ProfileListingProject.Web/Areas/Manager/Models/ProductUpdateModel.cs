using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class ProductUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IList<ProductFeature> ProductFeatures { get; set; }

        private IProductService _productService;
        public ProductUpdateModel()
        {
            _productService = Startup.AutoFacContainer.Resolve<IProductService>();
        }
        public ProductUpdateModel(IProductService productService)
        {
            _productService = productService;
        }
        
        public void AddNewProduct()
        {
            try
            {
                _productService.AddNewProduct(new Product
                {
                    Name = this.Name,
                    Description = this.Description,
                    ProductFeatures = this.ProductFeatures
                });
                Notification = new NotificationModel("Success!", "Product Successfully Created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }
    }
}
