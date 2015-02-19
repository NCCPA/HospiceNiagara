using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class AnnounceFile
    {
        public AnnounceFile()
        {
        //    this.Filez = new HashSet<File>();
            this.Announcement = new HashSet<Announcement>();
        }

        public int ID { get; set; }

        [Display(Name = "AnnounceID")]
        [Required(ErrorMessage = "You cannot leave the AnnounceID blank.")]
        [Range(1, 9999, ErrorMessage = "The number is not valid.")]
        public int AnnounceID { get; set; }

        [Display(Name = "FileID")]
        [Required(ErrorMessage = "You cannot leave the FileID blank.")]
        [Range(1, 9999, ErrorMessage = "The number is not valid.")]
        public int FileID { get; set; }

       // public virtual ICollection<File> Filez { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }
    }
}