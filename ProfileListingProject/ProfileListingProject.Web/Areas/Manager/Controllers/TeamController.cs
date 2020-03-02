using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileListingProject.Web.Areas.Manager.Models;
using ProfileListingProject.Web.Models;

namespace ProfileListingProject.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            var model = new TeamUpdateModel();
            return View(model);
        }

        public IActionResult GetTeams()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new TeamUpdateModel();
            var data = model.GetTeams(tableModel,userId);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new TeamUpdateModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TeamUpdateModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                model.AddNewTeam(userId);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new TeamUpdateModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}