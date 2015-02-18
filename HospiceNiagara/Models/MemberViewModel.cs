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

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "Ex")]
        public string PhoneExt { get; set; }
        public bool IsActive { get; set; }
        public bool IsContact { get; set; }
        public bool CanCreateMeeting { get; set; }
        public string Position { get; set; }
        public string PositionDescription { get; set; }
        public string Bio { get; set; }
    }
}