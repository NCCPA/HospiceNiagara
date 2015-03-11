using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class AnnouncePrivacy
    {
        public AnnouncePrivacy()
        {
            this.Role = new HashSet<Role>();
            this.ApplicationUser = new HashSet<ApplicationUser>();
            this.SubRole = new HashSet<SubRole>();
            this.Announcement = new HashSet<Announcement>();
        }

        public int ID { get; set; }

        [Display(Name = "AnnounceID")]
        [Required(ErrorMessage = "You cannot leave the Announcement blank.")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int AnnounceID { get; set; }

        // [Required(ErrorMessage = "You must select a Sub Role.")]
        [Display(Name = "RoleID")]
        [Required(ErrorMessage = "You cannot leave the RoleID blank.")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int RoleID { get; set; }

        // [Required(ErrorMessage = "You must select a User.")]
        [Display(Name = "UserID")]
        [Required(ErrorMessage = "You cannot leave the UserID blank.")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int UserID { get; set; }

        // [Required(ErrorMessage = "You must select a Sub Role.")]
        [Display(Name = "SubRoleID")]
        [Required(ErrorMessage = "You cannot leave the SubRoleID blank.")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int SubRoleID { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public virtual ICollection<SubRole> SubRole { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }
    }
}