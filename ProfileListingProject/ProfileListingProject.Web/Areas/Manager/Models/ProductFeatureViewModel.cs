using Autofac;
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

        public ProductFeatureViewModel()
        {
            _productFeatureService = Startup.AutoFacContainer.Resolve<IProductFeatureService>();
        }
        public ProductFeatureViewModel(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }

        public object GetProductFeature(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _productFeatureService.GetFeatures(
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

    }
}
