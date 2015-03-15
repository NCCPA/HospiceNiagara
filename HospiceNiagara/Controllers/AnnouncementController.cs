using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            return View();
        }

        //Get Partial View Announcement
        public ActionResult _announcement()
        {
            return PartialView();
        }

    }
}