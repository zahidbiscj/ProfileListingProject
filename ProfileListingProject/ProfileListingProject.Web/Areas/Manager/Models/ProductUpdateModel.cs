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
    public class ProductUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
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

        public string GetUploadedImage(string imageFileName)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(imageFileName)}";

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
            return path;
        }

        public void AddNewProduct(string uniqueFilePath)
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
                    ImageUrl = uniqueFilePath,
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

        public void EditProduct()
        {
            try
            {
                var category = _categoryService.GetCategoryByName(this.Category.Name);
                var product = _productService.GetProduct(this.Id);

                _productService.EditProduct(new Product
                {
                    Id = this.Id,
                    Name = this.Name,
                    Description = this.Description,
                    ImageUrl = product.ImageUrl
                });

                Notification = new NotificationModel("Success!", "Product successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update Product, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update Product, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var product = _productService.GetProduct(id);
            var productCategory = _productService.GetProductCategory(id);
            var category = _categoryService.GetCategory(productCategory.CategoryId);

            if(product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Description = product.Description;
                Category = new Category {
                    Name = category.Name
                };
            }
        }

    }
}
