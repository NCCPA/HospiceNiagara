using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class DeathPrivacy
    {
        public DeathPrivacy()
        {
            this.Role = new HashSet<Role>();
            this.ApplicationUser = new HashSet<ApplicationUser>();
            this.SubRole = new HashSet<SubRole>();
            this.Death = new HashSet<Death>();
        }

        public int ID { get; set; }

        // [Required(ErrorMessage = "You must select a Sub Role.")]
        [Display(Name = "RoleID")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int RoleID { get; set; }

        // [Required(ErrorMessage = "You must select a User.")]
        [Display(Name = "UserID")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int UserID { get; set; }

        // [Required(ErrorMessage = "You must select a Sub Role.")]
        [Display(Name = "SubRoleID")]
        [Range(1, 99999, ErrorMessage = "The number is not valid.")]
        public int SubRoleID { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public virtual ICollection<SubRole> SubRole { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<Death> Death { get; set; }
    }
}