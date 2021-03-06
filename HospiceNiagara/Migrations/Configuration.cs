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
            AutomaticMigrationsEnabled = true;
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



            // Test Method for User
            /*
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "admin@outlook.com", Email = "admin@outlook.com", FirstName = "Amanda", LastName = "cage", PhoneNumber = "905-642-2322"}
            };
            users.ForEach(d => context.Users.AddOrUpdate(x => x.Email, d));
            SaveChanges(context);
            */
            
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
                FirstName = "Board",
                LastName = "Meele",
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
            

            //Add Announcement
            var announcement = new List<Announcement>
            {
                new Announcement {Title = "Movie Night and Raffle Draw!", Description="Random Movie Choosen from a hat of everyone's choice", isVisible=true, Date = DateTime.Now},
                new Announcement {Title = "Swing Hard to Live Strong Golf Tournament", Description="Swing Hard to Live Strong Golf Tournament", isVisible=true, Date = DateTime.Now},
                new Announcement {Title = "Niagara's February e-newsletter Available", Description="Niagara's February e-newsletter Available", isVisible=true, Date = DateTime.Now},
                new Announcement {Title = "Smile Cookie Campaign", Description="Smile Cookie Campaign", isVisible=true, Date = DateTime.Now},
                new Announcement {Title = "TV Night and Paint Contest!", Description="TV Night and Paint Contest!", isVisible=true, Date = DateTime.Now}
            };
            announcement.ForEach(a => context.Announcements.AddOrUpdate(x => x.ID, a));
            context.SaveChanges();


            //Add Meetings
            var meetings = new List<Meeting>
            {
                new Meeting { Date = DateTime.Today, Name = "Heart Day", Description = "Doctors and spiritual leaders meeting"},
                new Meeting { Date = DateTime.Today, Name = "Board Meeting", Description = "Directors Meeting"},
                new Meeting { Date = DateTime.Today, Name = "Staff Apprication Day", Description = "A day about our staff"},
                new Meeting { Date = DateTime.Today, Name = "Event Planning 2015", Description = "Lets meet to plan our our year."},
                new Meeting { Date = DateTime.Today, Name = "Staff Meeting", Description = "Staff Meeting"},
                new Meeting { Date = DateTime.Today, Name = "Board Meeting", Description = "Directors Meeting"}
            };
            meetings.ForEach(a => context.Meetings.AddOrUpdate(x => x.ID, a));
            context.SaveChanges();

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

            
            //Links

            
            var Link = new List<Link> 
            { 
               new Link { Name="Hospice Niagara Website", URL = "www.hospiceniagara.ca", Visible=1, Group=0},
               new Link { Name="Hospice Niagara Newsletter", URL = "http://www.hospiceniagara.ca/resources/default/index/", Visible=1, Group=0},
               new Link { Name="HPC Education Website", URL = "www.hpceducation.ca", Visible=1, Group=0},
               new Link { Name="Hospice Niagara Online Donation website", URL = "https://www.hospiceniagara.ca/donations/donate.php", Visible=1, Group=0},
               new Link { Name="Facebook Account", URL = "https://www.facebook.com/pages/Hospice-Niagara/157424072710?ref=ts", Visible=1, Group=0},
               new Link { Name="Twitter Account", URL = "https://twitter.com/HospiceNiagara", Visible=1, Group=0},
               new Link { Name="5 Car Draw Website", URL = "www.hospiceniagara.ca", Visible=0, Group=0},
               new Link { Name="HN Hike for Hospice Website", URL = "http://www.hikeforhospiceniagara.ca", Visible=1, Group=0},


               new Link { Name="Hospice Palliative Care Ontario", URL = "www.hpco.ca", Visible=1, Group=1},
               new Link { Name="HNHB LHIN", URL = "http://www.hnhblhin.on.ca/home.aspx", Visible=1, Group=1},
               new Link { Name="MOHLTC", URL = "http://www.health.gov.on.ca/en/", Visible=1, Group=1},
               new Link { Name="HNHB CCAC", URL = "http://healthcareathome.ca/hnhb/en", Visible=1, Group=1},

                new Link { Name="LogVolunteerTime.com", URL = "www.logvolunteertime.com", Visible=1, Group=2},

                 new Link { Name="InfoAnywhere", URL = "www.infoanywhere.com", Visible=1, Group=3},
                 new Link { Name="QHR Net", URL = "https://css.hr.ccim.on.ca/HospiceNiagara", Visible=1, Group=3},
                 new Link { Name="Office 365 Web Login", URL = "https://portal.microsoftonline.com", Visible=1, Group=3},
                 new Link { Name="Green Shield (Group Plan Benefits)", URL = "www.greenshield.ca", Visible=1, Group=3},
                 new Link { Name="Sumac Training", URL = "http://sumac.com/training/", Visible=1, Group=3}
            };

            Link.ForEach(d => context.Links.AddOrUpdate(x => x.Name, d));
            context.SaveChanges();

            //Deaths

            var Death = new List<Death> 
            { 
               new Death { Name="Joe Smith", Date = Convert.ToDateTime("2014-12-16"), Location = "Community Client", Note = "Volunteer: Ted Tennant", Visible= true},
               new Death { Name="Rachel Jones", Date = Convert.ToDateTime("2015-12-14"), Location = "The Stabler Centre", Note = "Room 4", Visible=true},
               new Death { Name="Mary Brown", Date = Convert.ToDateTime("2015-12-08"), Location = "NN Outreach Team", Note = "", Visible=true},
               new Death { Name="Sally Williams", Date = Convert.ToDateTime("2015-11-30"), Location = "NS Outreach Team", Note = "", Visible=true}
            };
            //comment

            Death.ForEach(d => context.Deaths.AddOrUpdate(x => x.Name, d));
            SaveChanges(context);
            
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
