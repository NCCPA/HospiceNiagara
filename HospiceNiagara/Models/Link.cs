using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
  
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
        [Required(ErrorMessage = "You must supply a visability state.")]
        [Range(0, 1, ErrorMessage = "The visible range is invalid.")]
        public int Visible { get; set; }
        
        [Required(ErrorMessage = "You must supply a group.")]
       [Range(0, 3, ErrorMessage = "The group range is invalid.")]
        public int Group { get; set; }
    }
}