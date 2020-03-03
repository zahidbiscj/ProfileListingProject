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
    public class ProductFeatureViewModel : BaseModel
    {
        private IProductFeatureService _productFeatureService;
        private IOfficeManagementService _officeManagementService;
        public ProductFeatureViewModel()
        {
            _productFeatureService = Startup.AutoFacContainer.Resolve<IProductFeatureService>();
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }
        public ProductFeatureViewModel(IProductFeatureService productFeatureService,IOfficeManagementService officeManagementService)
        {
            _productFeatureService = productFeatureService;
            _officeManagementService = officeManagementService;
        }

        public object GetProductFeature(DataTablesAjaxRequestModel tableModel, int productId)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _productFeatureService.GetFeatures(
                productId,
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
            _productFeatureService.DeleteProductFeature(id);
        }
    }
}
