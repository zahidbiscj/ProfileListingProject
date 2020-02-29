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
        private IOfficeManagementService _officeManagementService;
        public ProductUpdateModel()
        {
            _productService = Startup.AutoFacContainer.Resolve<IProductService>();
            _categoryService = Startup.AutoFacContainer.Resolve<ICategoryService>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }
        public ProductUpdateModel(IProductService productService, ICategoryService categoryService,IOfficeManagementService officeManagementService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _officeManagementService = officeManagementService;
        }

        public IEnumerable<Category> GetAllCategoryList()
        {
            return _categoryService.GetAllCategories();
        }

        public string GetUploadedImage(string imageFileName)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(imageFileName);
            var newpath = $"{ randomName }{ Path.GetExtension(imageFileName)}";

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

        public void AddNewProduct(string uniqueFilePath, string userId)
        {
            try
            {
                var company = _officeManagementService.GetCompanyByUserId(userId);
                var category = _categoryService.GetCategoryByName(this.Category.Name);
                _productService.AddNewProduct(new Product
                {
                    Name = this.Name,
                    Description = this.Description,
                    ProductFeatures = this.ProductFeatures,
                    ImageUrl = uniqueFilePath,
                    CompanyId = company.Id,
                    Categories = new List<ProductCategory>() {
                            new ProductCategory{
                                CategoryId = category.Id
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

            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Description = product.Description;
                Category = new Category { Id = category.Id, Name = category.Name };
            }
        }

    }
}
