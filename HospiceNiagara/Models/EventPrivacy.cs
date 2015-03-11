using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class EventPrivacy
    {
        public EventPrivacy()
            {
                this.Role = new HashSet<Role>();
                this.ApplicationUser = new HashSet<ApplicationUser>();
                this.SubRole = new HashSet<SubRole>();
                this.Event = new HashSet<Event>();
            }
          public int ID { get; set; }


          [Display(Name = "MeetingID")]
          [Required(ErrorMessage = "You cannot leave the Meeting blank.")]
          [Range(1, 99999, ErrorMessage = "The number is not valid.")]
          public int MeetingID { get; set; }

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
          public virtual ICollection<Event> Event { get; set; }
    }
}