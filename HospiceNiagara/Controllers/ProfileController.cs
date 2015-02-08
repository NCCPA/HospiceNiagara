using HospiceNiagara.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index(string id, ApplicationUser model)
        {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
           

            //If Id is null then not coming from admin page
            if (id == null)
            {
                           
                //Get Current Id and Display it to the User
                var currentUserId = User.Identity.GetUserId();
                var curUser = manager.FindById(currentUserId);
                return View(curUser);
            }
            else //Coming from Admin page therefor get user by the id passed
            {
                //Get Current Id and Display it to the User
                var currentUserId = User.Identity.GetUserId();
                var curUser = manager.FindById(id);

                return View(curUser);
            }  
        }

        //
        //GET: EDIT
        public ActionResult Edit(string id, ApplicationUser model)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));


            //If Id is null then not coming from admin page
            if (id == null)
            {

                //Get Current Id and Display it to the User
                var currentUserId = User.Identity.GetUserId();
                var curUser = manager.FindById(currentUserId);
                return View(curUser);
            }
            else //Coming from Admin page therefor get user by the id passed
            {
                //Get Current Id and Display it to the User
                var currentUserId = User.Identity.GetUserId();
                var curUser = manager.FindById(id);

                return View(curUser);
            }
            
        }
    }
}