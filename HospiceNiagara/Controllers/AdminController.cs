﻿using HospiceNiagara.Models;
using HospiceNiagara.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
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
            return View();
        }

        //*******************************************************************
        //File Section


        //*******************************************************************
        //Start Member Section
        
        //Show MemberList
        public ActionResult _Memberlist(string memberStringSearch)
        {
            var viewModel = from v in db.Users
                            select new MemberViewModel
                            {
                                ID = v.Id,
                                FirstName = v.FirstName,
                                LastName = v.LastName,
                                Bio = v.Bio,
                                Email = v.Email,
                                PhoneNumber = v.PhoneNumber,
                                PhoneExt = v.PhoneExt,
                                IsContact = v.IsContact,
                                Position = v.Position,
                                PositionDescription = v.PositionDescription,
                                IsActive = v.IsActive                                
                            };

            if (!String.IsNullOrEmpty(memberStringSearch))
            {
                viewModel = viewModel.Where(s => s.FirstName.Contains(memberStringSearch));
            }

            return PartialView(viewModel.ToList());
        }

        //Member Search
        [HttpGet]
        public void MemberFilter(string memberStringSearch)
        {
            Response.Redirect("~/Admin/Index?memberStringSearch=" + memberStringSearch + "#usersTab#Top#Top");
        }


        //Add Member
        public void _AddMember(ApplicationUser model, string firstName, string lastName, string bio, string email, string phoneNumber, string phoneExt, string isContact, string position, string positionDesc, string isActive)
        {
               ApplicationUser user = new ApplicationUser();

                //Set all Fields needed
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Bio = bio;
                user.Email = email;
                user.UserName = email;
                user.PhoneNumber = phoneNumber;
                user.PhoneExt = phoneExt;
                user.PositionDescription = positionDesc;
                user.Position = position;

                //Drop Down List for active or inactive member
                if (isActive == "1")
                {
                    user.IsActive = true;
                }
                else
                {
                    user.IsActive = false;
                }

                //Drop Down List to view member in Contact List or Not
                if (isContact == "1")
                {
                    user.IsContact = true;
                }
                else
                {
                    user.IsContact = false;
                }


                //Add user Object to Users.db
                db.Users.Add(user);

                //save context
                SaveChanges(db);

                //Redirect correctly
                Response.Redirect("~/Admin/Index#usersTab#Top");
            
        }


        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        //Edit Member
        public void _EditMember(string id, string firstName, string lastName, string bio, string email, string phoneNumber, string phoneExt, string isContact, string position, string positionDesc, string isActive)
        {          
                ApplicationUser user = db.Users.Find(id);
                //Set all Fields needed
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Bio = bio;
                user.Email = email;
                user.UserName = email;
                user.PhoneNumber = phoneNumber;
                user.PhoneExt = phoneExt;
                user.PositionDescription = positionDesc;
                user.Position = position;

                //Drop Down List for active or inactive member
                if (isActive == "1")
                {
                    user.IsActive = true;
                }
                else
                {
                    user.IsActive = false;
                }

                //Drop Down List to view member in Contact List or Not
                if (isContact == "1")
                {
                    user.IsContact = true;
                }
                else
                {
                    user.IsContact = false;
                }

                //save context
                SaveChanges(db);
                //Redirect correctly
                Response.Redirect("~/Admin/Index#usersTab#Top");
           
        }

        //Delete Member
        public void _MemberDelete(string id)
        {
            //Get User and remove from db
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            Response.Redirect("~/Admin/Index#usersTab#Top");
        }


        //End Member Section
        //*******************************************************************


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


        public FileContentResult FileDownload(int id)
        {
            var theFile = db.Files.Where(f => f.ID == id).SingleOrDefault();
            return File(theFile.FileContent, theFile.MimeType, theFile.FileName);
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

        //Edit Files
        public void _FileEdit(int id, string fileName, string fileDesc)
        {
            //Find File in database
            Files files = db.Files.Find(id);

            //add new fields
            files.FileName = fileName;
            files.FileDescription = fileDesc;

            //Save changes
            db.SaveChanges();

            //Respond redirect correctly tab
            Response.Redirect("~/Admin/Index#filesTab#Top");
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospiceNiagara.Models.Files fileStore = db.Files.Find(id);
            db.Files.Remove(fileStore);
            db.SaveChanges();
            return Redirect("~/Admin/Index#filesTab#Top");
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
        public void _AnnouncementEdit(string announceTitle, DateTime announceDate, string announceDesc, int id)
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

        //FilterDeath
        [HttpGet]
        public void DeathFilter(string deathSearchString)
        {
            Response.Redirect("~/Admin/Index?deathSearchString=" + deathSearchString + "#deathsTab#Top");
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
        public void _EditDeath(int id, string name, DateTime date, string location, string note, string visible, string CreatedByID)
        {
            //Find Death Obj
            Death death = db.Deaths.Find(id);

            //Change all properties to new
            death.Name = name;
            death.Date = date;
            death.Location = location;
            death.Note = note;
            death.CreatedByID = CreatedByID;

            if (visible == "1")
            {
                death.Visible = true;
            }
            else
            {
                death.Visible = false;
            }

            //Save all Changes
            db.SaveChanges();

            //Redirect to proper Tab
            Response.Redirect("~/Admin/Index#deathsTab#Top");
        }


        //Delete Death
        public void _DeleteDeath(int id)
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


        //**************************************************************************
        //Begin Contact Section

        public ActionResult _ContactsList(string contactSearchString)
        {

            //Search through all users and look for isContact to be true
            var viewModel = from m in db.Users
                            select new ContactViewModel
                            {
                                ID = m.Id,
                                FirstName = m.FirstName,
                                LastName = m.LastName,
                                PhoneNumber = m.PhoneNumber,
                                PhoneExt = m.PhoneExt,
                                IsActive = m.IsActive,
                                IsContact = m.IsContact,
                                Position = m.Position,
                                PositionDescription = m.PositionDescription,
                                Email = m.Email
                            };

            //Sort by isContact for contact Page
            viewModel = viewModel.Where(c => c.IsContact == true);


            if (!String.IsNullOrEmpty(contactSearchString))
            {
                viewModel = viewModel.Where(s => s.FirstName.Contains(contactSearchString));
            }

            return PartialView(viewModel.ToList());
        }

        //Filter Relocation Contact
        //Member Search
        [HttpGet]
        public void ContactFilter(string contactSearchString)
        {
            Response.Redirect("~/Admin/Index?contactSearchString=" + contactSearchString + "#contactsTab#Top");
        }

        //Edit Contact
        public void _EditContact(string firstname, string isContact, string lastname, string phoneNumber, string position, string positionDesc, string email, string id)
        {
            //Find Member
            ApplicationUser user = db.Users.Find(id); 

            //Set all Fields
            user.FirstName = firstname;
            user.LastName = lastname;
            user.PhoneNumber = phoneNumber;
            user.Position = position;
            user.PositionDescription = positionDesc;
            user.Email = email;

            //set Contact visible option
            if (isContact == "1")
            {
                user.IsContact = true;
            }
            else
            {
                user.IsContact = false;
            }

            //Save all Changes
            db.SaveChanges();

            //Redirect to proper Tab
            Response.Redirect("~/Admin/Index#contactsTab#Top");
        }
       
        //End Contact Section
        //**************************************************************************


        //**************************************************************************
        //Begin Schedule Section

        //**************************************************************************
        //End Schedule Section



    }
}
