using Autofac;
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
    }
}
