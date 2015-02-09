using HospiceNiagara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class HomeController : Controller
    {
        //Return Home Page
        public ActionResult Index()
        {
            return View();
        }    
    }
}