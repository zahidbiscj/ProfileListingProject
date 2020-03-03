using Autofac;
using ProfileListingProject.Core.Entities;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class ProductViewModel : BaseModel
    {
        private IProductService _productService;
        private IOfficeManagementService _officeManagementService;

        public ProductViewModel()
        {
            _productService = Startup.AutoFacContainer.Resolve<IProductService>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }

        public ProductViewModel(IProductService productService,IOfficeManagementService officeManagementService)
        {
            _productService = productService;
            _officeManagementService = officeManagementService;
        }

        public object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _productService.GetProducts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name,
                            record.Description,
                            record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        public Company GetCompany(string userId)
        {
            return _officeManagementService.GetCompanyByUserId(userId);
        }

        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
