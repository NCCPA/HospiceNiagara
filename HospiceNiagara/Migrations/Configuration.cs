namespace HospiceNiagara.Migrations
{
    using HospiceNiagara.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<HospiceNiagara.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HospiceNiagara.Models.ApplicationDbContext";
        }

        protected override void Seed(HospiceNiagara.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //create Role admin if it does not exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Admin"));
            }

            //create role Board
            if (!context.Roles.Any(r => r.Name == "Board"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Board"));
            }

            //create role Staff
            if (!context.Roles.Any(r => r.Name == "Staff"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Staff"));
            }

            //create role volunteer
            if (!context.Roles.Any(r => r.Name == "Volunteer"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Volunteer"));
            }


            //Create a generic user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Create admin user
            var adminUser = new ApplicationUser
            {
                
                UserName = "admin@outlook.com",
                Email = "admin@outlook.com",
                FirstName = "Amanda",
                LastName = "Cage",
                PhoneNumber = "905-341-3222",
                DOB = new DateTime(1989, 04, 22)
            };


            //Create Staff
            var staffUser = new ApplicationUser
            {
                UserName = "staff@outlook.com",
                Email = "staff@outlook.com",
                FirstName = "Jay",
                LastName = "Swanson",
                PhoneNumber = "905-341-3222",
                DOB = new DateTime(1990, 05, 23)
            };

            //Create board user
            var boardUser = new ApplicationUser
            {
                UserName = "board@outlook.com",
                Email = "board@outlook.com",
                FirstName = "Jack",
                LastName = "Sparrow",
                PhoneNumber = "905-341-3222",
                DOB = DateTime.Today
            };

            //Create Volunteer
            var volunteerUser = new ApplicationUser
            {
                UserName = "volunteer@outlook.com",
                Email = "volunteer@outlook.com",
                FirstName = "Erika",
                LastName = "Meele",
                PhoneNumber = "905-341-3222",
                DOB = DateTime.Today
            };


            //Create admin account account and add to admin role
            if (!context.Users.Any(u => u.Email == adminUser.UserName))
            {
                manager.Create(adminUser, "Pass!23");
                manager.AddToRole(adminUser.Id, "Admin");
            }

            //Create Staff account and add to staff role
            if (!context.Users.Any(u => u.Email == staffUser.UserName))
            {
                manager.Create(staffUser, "Pass!23");
                manager.AddToRole(staffUser.Id, "Staff");
            }

            //create board user and add to board role
            if (!context.Users.Any(u => u.Email == boardUser.UserName))
            {
                manager.Create(boardUser, "Pass!23");
                manager.AddToRole(boardUser.Id, "Board");
            }

            //create volunteer user and add to Vounteer role
            if (!context.Users.Any(u => u.Email == volunteerUser.UserName))
            {
                manager.Create(volunteerUser, "Pass!23");
                manager.AddToRole(volunteerUser.Id, "Volunteer");
            }

            //var roles = new List<Role> 
            //{ 
            //    new Role { roleName = "Volunteer"}, 
            //    new Role { roleName = "Board"}, 
            //    new Role { roleName = "Staff"}, 
            //    new Role { roleName = "Admin"}
            //};

            //roles.ForEach(d => context.Roles.AddOrUpdate(x => x.roleName, d));
            //context.SaveChanges();

            var subroles = new List<SubRole> 
            { 
                new SubRole { roleName = "Bereavement", RoleID = 0},
                new SubRole { roleName = "Community", RoleID = 0},
                new SubRole { roleName = "Day Hospice", RoleID = 0},
                new SubRole { roleName = "Residential", RoleID = 0},
                new SubRole { roleName = "Welcome Desk", RoleID = 0},
                new SubRole { roleName = "Event (non client)", RoleID = 0},
                new SubRole { roleName = "Admin (non client)", RoleID = 0},
                new SubRole { roleName = "New Volunteers", RoleID = 0},
                new SubRole { roleName = "Audit & Finance Committee", RoleID = 1},
                new SubRole { roleName = "Community Relations Committee", RoleID = 1},
                new SubRole { roleName = "Governance Committee", RoleID = 1},
                new SubRole { roleName = "Operations and Quality Improvement Committee", RoleID = 1},
                new SubRole { roleName = "New Board Members", RoleID = 1},
                new SubRole { roleName = "Leadership", RoleID = 2},
                new SubRole { roleName = "Admin", RoleID = 2},
                new SubRole { roleName = "Community", RoleID = 2},
                new SubRole { roleName = "Outreach", RoleID = 2},
                new SubRole { roleName = "Residential", RoleID = 2},
                new  SubRole { roleName = "New Staff", RoleID = 2}
              //  new Hospice.Models.SubRole { roleName = "New Staff", RoleID = 2}
            };

            subroles.ForEach(d => context.SubRoles.AddOrUpdate(x => x.ID, d));
            SaveChanges(context);

            //General Links

            var LinkHome = new List<LinkHome> 
            { 
               new LinkHome { Name="dample", Link = "Volunteer", Visible=1}
            };

            LinkHome.ForEach(d => context.LinkHomes.AddOrUpdate(x => x.Link, d));
            context.SaveChanges();

            //Staff Links

            var LinkStaff = new List<LinkStaff> 
            { 
               new LinkStaff { Name="dample", Link = "Volunteer", Visible=1}
            };

            LinkStaff.ForEach(d => context.LinkStaffs .AddOrUpdate(x => x.Link, d));
            context.SaveChanges();

            //Deaths

            var Death = new List<Death> 
            { 
               new Death { Name="dample", Date = Convert.ToDateTime("2015-01-01"), Location = "", Note = "", Visible=1, CreatedByID = 0}
            };

            Death.ForEach(d => context.Deaths.AddOrUpdate(x => x.Name, d));
            context.SaveChanges();



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
    }
}
