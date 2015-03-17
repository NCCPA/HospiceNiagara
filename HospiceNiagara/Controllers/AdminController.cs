using HospiceNiagara.Models;
using HospiceNiagara.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        //*******************************************************************
        //File Section

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
        //End File Section
        //*************************************************************


        //*************************************************************
        //Announcement Section

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
            Response.Redirect("~/Admin/Index?announcementSearchString=" + announcementSearchString + "#announcementsTab#Top");
        }

        //Add Announcement
        public void _AnnouncementAdd(string announceTitle, DateTime announceDate, string announceDesc)
        {
            if (ModelState.IsValid)
            {
                //Create new Object announcement
                Announcement newAnnounce = new Announcement();

                //Give Properties to the properties from the form
                newAnnounce.Title = announceTitle;
                newAnnounce.Date = announceDate;
                newAnnounce.Description = announceDesc;

                //Save to the database
                db.Announcements.Add(newAnnounce);
                db.SaveChanges();

                //redirect tot Admin Page with AnnouncementsTab Open
                Response.Redirect("~/Admin/Index#announcementsTab#Top");
            }
        }

        //Edit Announcement
        public void _AnnouncementEdit(string announceTitle, DateTime announceDate, string announceDesc,int id)
        {
            //Check to see if Forum Validates
            if (ModelState.IsValid)
            {
                //get selected announcement
                Announcement announcement = db.Announcements.Find(id);

                //Update Fields
                announcement.Title = announceTitle;
                announcement.Date = announceDate;
                announcement.Description = announceDesc;
                
                //Save and Update
                db.SaveChanges();             

                //redirect tot Admin Page with AnnouncementsTab Open
                Response.Redirect("~/Admin/Index#announcementsTab#Top");
            }
        }



        //Delete Announcement
        public void _AnnouncementDelete(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
            db.SaveChanges();
            Response.Redirect("~/Admin/Index#announcementsTab#Top");

        }

        //End Announcement Section
        //******************************************************************

        //*******************************************************************
        //Meeting Section
        [HttpGet]
        public ActionResult _MeetingsList(string meetingsSearchString)
        {

            var viewModel = from m in db.Meetings
                            select new MeetingsViewModel
                            {
                                ID = m.ID, //req
                                Type = m.Type, //req
                                Name = m.Name,
                                Date = m.Date,
                                Description = m.Description,
                                Length = m.Length,//req
                                Location = m.Location,//req
                                Requirements = m.Requirements,//req
                                isVisible = m.isVisible,
                                StaffLeadID = m.StaffLeadID,
                                CreatedByID = m.CreatedByID

                            };

            if (!String.IsNullOrEmpty(meetingsSearchString))
            {
                viewModel = viewModel.Where(s => s.Name.Contains(meetingsSearchString));
            }

            return PartialView(viewModel.ToList());
        }

        //
        //Filter Meeting
        [HttpGet]
        public void meetingFilter(string meetingsSearchString)
        {
            Response.Redirect("~/Admin/Index?meetingsSearchString=" + meetingsSearchString + "#meetingsTab#Top");
        }

        //
        //Add Meeting
        public void _MeetingAdd(DateTime date, string Name, string Description)
        {

            //Create New Meeting
            Meeting meeting = new Meeting();

            //Add Information to meeting obj
            meeting.Name = Name;
            meeting.Date = date;
            meeting.Description = Description;

            //Add obj to Database
            db.Meetings.Add(meeting);

            //Save Changes
            db.SaveChanges();

            //Redirect to proper tab
            Response.Redirect("~/Admin/Index#meetingsTab#Top");
        }

        //
        //Edit Meeting
        public void _MeetingEdit(string name, DateTime date, string description, int id)
        {
            //Find Current meeting
            Meeting meeting = db.Meetings.Find(id);

            //change current fields into newly inputted
            meeting.Name = name;
            meeting.Date = date;
            meeting.Description = description;

            //Save Changes
            db.SaveChanges();

            //redirect tot Admin Page with AnnouncementsTab Open
            Response.Redirect("~/Admin/Index#meetingsTab#Top");
        }


        //
        //Delete Meeting
        public void _MeetingDelete(int id)
        {
            Meeting meeting = db.Meetings.Find(id);
            db.Meetings.Remove(meeting);
            db.SaveChanges();
            Response.Redirect("~/Admin/Index#meetingsTab#Top");
        }

        //End of Meeting Section
        //*************************************************************************



        //**************************************************************************
        //Begin Death Section
        public ActionResult _Death(string deathSearchString)
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

            if (!String.IsNullOrEmpty(deathSearchString))
            {
                deathList = deathList.Where(s => s.Name.Contains(deathSearchString));
            }

            return PartialView(deathList.ToList());
        }
        
        //Add Death
        public void _AddDeath(string name, DateTime date, string location, string note, bool visible, string CreatedByID)
        {
            //Create new Death Obj
            Death death = new Death();

            //Add all properties
            death.Name = name;
            death.Date = date;
            death.Location = location;
            death.Note = note;
            death.CreatedByID = CreatedByID;

            //Add Object to the database
            db.Deaths.Add(death);

            //Save all Changes
            db.SaveChanges();

            //Redirect to proper Tab
            Response.Redirect("~/Admin/Index#deathsTab#Top");
        }


        //Edit Death
        public void _EditDeath(string id, string name, DateTime date, string location, string note, bool visible, string CreatedByID)
        {
            //Find Death Obj
            Death death = db.Deaths.Find(id);

            //Change all properties to new
            death.Name = name;
            death.Date = date;
            death.Location = location;
            death.Note = note;
            death.CreatedByID = CreatedByID;

            //Save all Changes
            db.SaveChanges();

            //Redirect to proper Tab
            Response.Redirect("~/Admin/Index#deathsTab#Top");
        }


        //Delete Death
        public void _MeetingDelete(int id)
        {
            //Find Death Obj
            Death death = db.Deaths.Find(id);

            //Remove from db 
            db.Deaths.Remove(death);

            //Save Changes
            db.SaveChanges();

            //Redirect to proper Tab
            Response.Redirect("~/Admin/Index#deathsTab#Top");            
        }
        //End Death Section
        //**************************************************************************


    }   
}
