using HospiceNiagara.Models;
using HospiceNiagara.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HospiceNiagara.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*  todo 2/23:
         *  use green for headers
            blue for buttons
            change nav-bar to dark button blue
            change nav-bar active color to blue hover button color
            add padding-right: 5px; to + in buttons
            auto expand folders when searching
         *  -jord
         * 
         */



        // GET: Admin
        public ActionResult Index()
        {
            //Initialize store and manager
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            //Get Current Id and Display it to the User
            var currentUserId = User.Identity.GetUserId();
            var Users = manager.Users;

            var viewModel = (from u in db.Users
                             select new MemberViewModel
                             {
                                 ID = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 DOB = u.DOB,
                                 PhoneNumber = u.PhoneNumber,
                                 PhoneExt = u.PhoneExt
                             });       
            
            return View(viewModel.ToList());
        }


        public ActionResult _File()
        {
            var fileList = from f in db.Files
                           select new FileViewModel
                           {
                               ID = f.ID,
                               FileName = f.FileName,
                               MimeType = f.MimeType,
                               FileDescription = f.FileDescription,
                               FolderID = f.FolderID
                           };
            return PartialView(fileList.ToList());
        }

        [HttpGet, ActionName("_File")]
        public ActionResult _File(string searchString)
        {
            var fileList = from f in db.Files
                           select new FileViewModel
                           {
                               ID = f.ID,
                               FileName = f.FileName,
                               MimeType = f.MimeType,
                               FileDescription = f.FileDescription,
                               FolderID = f.FolderID
                           };
            if (!String.IsNullOrEmpty(searchString))
            {
                fileList = fileList.Where(s => s.FileName.Contains(searchString)
                                       || s.FileDescription.Contains(searchString));
            }
            return PartialView(fileList.ToList());
        }

        public ActionResult _Death()
        {
            var deathList = from f in db.Deaths
                           select new DeathViewModel
                           {
                               ID = f.ID,
                               Name = f.Name,
                               Date = f.Date,
                               Location = f.Location,
                               Note = f.Note,
                               Visible = f.Visible,
                               CreatedByID = f.CreatedByID
                           };
            return PartialView(deathList.ToList());
        }
         
        //POST: ADD Death
        [HttpPost] 
        public ActionResult AddDeath(string name, DateTime date, string location, string note)
        {
           HospiceNiagara.Models.Death deathObj = new HospiceNiagara.Models.Death
           {
               Name = name,
               Date = date,
               Location = location,
               Note = note
           };

            db.Deaths.Add(deathObj);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 

        /*public ActionResult EditDeath(int id, string name, DateTime date, string location, string note, bool visible)
        {
         * something like this
         * var existingDeath = DB.Deaths.Where(x => x.ID == id);
            HospiceNiagara.Models.Death deathObj = new HospiceNiagara.Models.Death
            {
                ID = id,
                Name = name,
                Date = date,
                Location = location,
                Note = note,
                isVisible = visible
            };

            //db.Deaths.Add(deathObj);
            db.SaveChanges();
        } */


        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileViewModel filetoDelete = (from f in db.Files
                                          where f.ID == id
                                          select new FileViewModel
                                          {
                                              ID = f.ID,
                                              FileName = f.FileName,
                                              MimeType = f.MimeType,
                                              FileDescription = f.FileDescription
                                          }).SingleOrDefault();
            if (filetoDelete == null)
            {
                return HttpNotFound();
            }
            return View(filetoDelete);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospiceNiagara.Models.Files fileStore = db.Files.Find(id);
            db.Files.Remove(fileStore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //
        //Announcement Section

        //GET AnnouncementList
        [HttpGet]
        public ActionResult _Announcement()
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

        //End Announcement Section
        //

        //
        //Meeting Section
        [HttpGet]
        public ActionResult _MeetingsList()
        {

            var viewModel = from m in db.Meetings
                            select new MeetingsViewModel
                            {
                                ID = m.ID, //req
                                Type = m.Type, //req
                                Name = m.Name,
                                Date = m.Date,
                                Length = m.Length,//req
                                Location = m.Location,//req
                                Requirements = m.Requirements,//req
                                isVisible = m.isVisible,
                                StaffLeadID = m.StaffLeadID,
                                CreatedByID = m.CreatedByID

                            };

            return PartialView(viewModel.ToList());
        }

        //End of Meeting Section
        //


    }   
}
