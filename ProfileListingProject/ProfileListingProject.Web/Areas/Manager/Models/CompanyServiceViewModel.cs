using Autofac;
using ProfileListingProject.Core.Services.Interface;
using ProfileListingProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Areas.Manager.Models
{
    public class CompanyServiceViewModel
    {
        private IServiceManagement _serviceManagement;
        public CompanyServiceViewModel()
        {
            _serviceManagement = Startup.AutoFacContainer.Resolve<IServiceManagement>();
        }
        public CompanyServiceViewModel(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }
        public object GetCompanyServices(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _serviceManagement.GetCompanyServices(
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
