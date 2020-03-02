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
    public class TeamUpdateModel : BaseModel
    {
        private IOfficeManagementService _officeManagementService;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Company Company { get; set; }
        public TeamUpdateModel(IOfficeManagementService officeManagementService)
        {
            _officeManagementService = officeManagementService;
        }
        public TeamUpdateModel()
        {
            _officeManagementService = Startup.AutoFacContainer.Resolve<IOfficeManagementService>();
        }

        public void AddNewTeam(string userId)
        {
            try
            {
                var company = _officeManagementService.GetCompanyByUserId(userId);
                _officeManagementService.AddNewTeam(new Team
                {
                    Name = this.Name,
                    Count = this.Count,
                    Company = company
                });
                Notification = new NotificationModel("Success !!", "Teams Added Successfully", NotificationType.Success);

            }
            catch (Exception)
            {
                Notification = new NotificationModel("Failed !!", "Failed to Add Team", NotificationType.Fail);
                throw;
            }
        }

        public void Delete(int id)
        {
            _officeManagementService.DeleteTeam(id);
        }

        public object GetTeams(DataTablesAjaxRequestModel tableModel, string userId)
        {
            this.Company = _officeManagementService.GetCompanyByUserId(userId);
            int total = 0;
            int totalFiltered = 0;
            var records = _officeManagementService.GetTeams(
                Company.Id,
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
                                record.Count.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
    }
}
