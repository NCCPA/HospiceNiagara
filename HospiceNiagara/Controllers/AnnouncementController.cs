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

        //Get Partial View Announcement
        [HttpGet]
        public ActionResult _announcement()
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

            return PartialView(viewModel.ToList());
        }


    }
}