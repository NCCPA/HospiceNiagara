using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public enum Group
    {
       S,V,C //Staff View Comunity
    }

    public class Link
    {
    
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must supply a name.")]
        [StringLength(100, ErrorMessage = "Name can be no more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Link")]
        [Required(ErrorMessage = "You must supply a link.")]
        [StringLength(250, ErrorMessage = "Link can be no more than 250 characters long.")]
        public string URL { get; set; }

        [Display(Name = "Visible")]
        [Range(1, 10, ErrorMessage = "The visible range is invalid.")]
        public int Visible { get; set; }
        
        [DisplayFormat(NullDisplayText = "Everyone")]
        public Group? Group { get; set; }
    }
}