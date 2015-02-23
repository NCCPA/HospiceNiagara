﻿using HospiceNiagara.Models;
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
                               isVisible = f.isVisible,
                               CreatedByID = f.CreatedByID
                           };
            return PartialView(deathList.ToList());
        }

       public ActionResult AddDeath(int id, string name, DateTime date, string location, string note, bool visible)
       {
           HospiceNiagara.Models.Death deathObj = new HospiceNiagara.Models.Death
           {
               ID = id,
               Name = name,
               Date = date,
               Location = location,
               Note = note,
               isVisible = visible
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
    }   
}
