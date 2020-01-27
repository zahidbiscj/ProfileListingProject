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
        public Category Category { get; set; }
        public IList<ProductFeature> ProductFeatures { get; set; }

        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductUpdateModel()
        {
            _productService = Startup.AutoFacContainer.Resolve<IProductService>();
            _categoryService = Startup.AutoFacContainer.Resolve<ICategoryService>();
        }
        public ProductUpdateModel(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        
        public void AddNewProduct()
        {
            try
            {
                var category = _categoryService.GetCategoryByName(this.Category.Name);
                var product = _productService.GetProductByName(this.Name);
                _productService.AddNewProduct(new Product
                {
                    Id = product.Id,
                    Name = this.Name,
                    Description = this.Description,
                    ProductFeatures = this.ProductFeatures,
                    Categories = new List<ProductCategory>() {
                            new ProductCategory{ 
                                CategoryId = category.Id,
                                ProductId = product.Id
                            }
                    }
                    
                });
                Notification = new NotificationModel("Success!", "Product Successfully Created", NotificationType.Success);
            }
            catch (InvalidOperationException)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create Product, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create Product, please try again",
                    NotificationType.Fail);
            }
        }
    }
}
