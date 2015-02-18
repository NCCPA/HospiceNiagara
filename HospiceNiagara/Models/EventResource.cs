using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class EventResource
    {
        public EventResource()
        {
      //      this.File = new HashSet<File>();
            this.Event = new HashSet<Event>();
        }

        public int ID { get; set; }

        [Display(Name = "Event")]
        [Required(ErrorMessage = "You cannot leave the MeetingID blank.")]
        [Range(1, 9999, ErrorMessage = "The number is not valid.")]
        public int EventID { get; set; }

        [Display(Name = "FileID")]
        [Required(ErrorMessage = "You cannot leave the FileID blank.")]
        [Range(1, 9999, ErrorMessage = "The number is not valid.")]
        public int FileID { get; set; }

      //  public virtual ICollection<File> File { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}