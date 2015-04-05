using HospiceNiagara.Models;
using HospiceNiagara.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Announcement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Announcement(string announcementSearchString)
        {
            var viewModel = from v in db.Announcements
                            select new AnnouncementViewModel
                            {
                                ID = v.ID,
                                Title = v.Title,
                                Description = v.Description,
                                isVisible = v.isVisible,
                                CreatedByID = v.CreatedByID,
                                Date = v.Date
                            };

            if (!String.IsNullOrEmpty(announcementSearchString))
            {
                viewModel = viewModel.Where(s => s.Title.Contains(announcementSearchString));
            }

            return PartialView(viewModel.ToList());
        }

        [HttpGet]
        public void AnnouncementFilter(string announcementSearchString)
        {
            Response.Redirect("~/Announcement/Index?announcementSearchString=" + announcementSearchString + "#announcementsTab#Top");
        }
    }
}