using HospiceNiagara.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

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
        //POST: Picture Upload
        [HttpPost]
        public ActionResult Index(string id)
        {
            string mimeType = Request.Files[0].ContentType;
            string fileName = Path.GetFileName(Request.Files[0].FileName);
            int fileLength = Request.Files[0].ContentLength;
            if (!(fileName == "" || fileLength == 0))//Looks like we have a file!!!
            {
                Stream fileStream = Request.Files[0].InputStream;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);
               
                //Get Current User Depending on Profile Location - Admin or Owner
                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(store);

                //If Id is null then not coming from admin page
                if (id == null)
                {

                    //Get Current Id and Display it to the User
                    var currentUserId = User.Identity.GetUserId();
                    var curUser = manager.FindById(currentUserId);

                    //Add File To user
                    curUser.ProfilePicture = fileData;
                    curUser.MimeType = mimeType;

                    //Update User and Save the current Changes
                    manager.UpdateAsync(curUser);
                    store.Context.SaveChanges();

                    return View(curUser);
                }
                else //Coming from Admin page therefor get user by the id passed
                {
                    //Get Current Id and Display it to the User
                    var curUser = manager.FindById(id);

                    //Add File To user
                    curUser.ProfilePicture = fileData;
                    curUser.MimeType = mimeType;
                    
                    //Update User and Save the current Changes
                    manager.Update(curUser);
                    store.Context.SaveChanges();

                    return View(curUser);
                }  


            }
            return RedirectToAction("Index");
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
                var curUser = manager.FindById(id);

                return View(curUser);
            }
        }


        //Show Profile Picture
        public void Show(string id)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));


            //If Id is null then not coming from admin page
            if (id == null)
            {
                //Get Current Id and Grab Profile Picture
                var currentUserId = User.Identity.GetUserId();
                var curUser = manager.FindById(currentUserId);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = curUser.MimeType;
                Response.BinaryWrite(curUser.ProfilePicture);
                Response.End();
               
            }
            else //Coming from Admin page therefor get user by the id passed
            {
                //Get Current Id and Display it to the User
                var curUser = manager.FindById(id);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = curUser.MimeType;
                Response.BinaryWrite(curUser.ProfilePicture);
                Response.End();
            }
        }


        //
        // GET: Notice
        public ActionResult Notice()
        {
            return View();
        }

    }
}