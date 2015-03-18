using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospiceNiagara.Models
{
    public class MemberViewModel
    {
        //Add Children ViewModels
        public List<FileViewModel> FileViewModel { get; set; }
        public List<Death> Death { get; set; }
        

        public string ID { get; set; }

        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

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
        [StringLength(250,ErrorMessage="Bio Cannot be More than 250 Charactes")]
        public string Bio { get; set; }
    }
}