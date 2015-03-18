using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HospiceNiagara.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        //Properties of a ApplicationUser - User
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Phone Extension")]
        public string PhoneExt { get; set; }

        [Display(Name = "Active Member")]
        public bool IsActive { get; set; }

        [Display(Name = "View in Contacts")]
        public bool IsContact { get; set; }

        public bool CanCreateMeeting { get; set; }

        [Display(Name = "Position Title")]
        public string Position { get; set; }

        [Display(Name = "Position Description")]
        public string PositionDescription { get; set; }

        [Display(Name = "Bio")]
        [StringLength(250, ErrorMessage = "Bio Cannot be More than 250 Charactes")]
        public string Bio { get; set; }


        //Fields for Profile Picture
        public byte[] ProfilePicture { get; set; }
        public string MimeType { get; set; }


      //  public virtual ICollection<SubRole> SubRole { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Files> Files { get; set; }

        public DbSet<SubRole> SubRoles { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<FolderPrivacy> FolderPrivacy { get; set; }
        public DbSet<FolderGroup> FolderGroups { get; set; }
        public DbSet<FolderGroupPrivacy> FolderGroupPrivacy { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingPrivacy> MeetingPrivacy { get; set; }
        public DbSet<MeetingResource> MeetingResources { get; set; }

        //announcements
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncePrivacy> AnnouncePrivacy { get; set; }
        public DbSet<AnnounceFile> AnnounceFiles { get; set; }

        //events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventPrivacy> EventPrivacys { get; set; }
        public DbSet<EventResource> EventResources { get; set; }

        public DbSet<RSVP> RSVPs { get; set; }
        // public DbSet<Schedule> Shedules { get; set; }
        //  public DbSet<SchedulePrivacy> SchedulePrivacys { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Link> Links { get; set; }


        public DbSet<Death> Deaths { get; set; }
        public DbSet<DeathPrivacy> DeathPrivacy { get; set; }

    }
}