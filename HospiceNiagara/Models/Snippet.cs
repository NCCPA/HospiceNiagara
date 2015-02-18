using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class Snippet
    {
        public Snippet()
        {
           
        }

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the title blank.")]
        [StringLength(50, ErrorMessage = "The name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "The description cannot be more than 1000 characters long.")]
        public string Description { get; set; }


        [Display(Name = "BaseCode")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(5000, ErrorMessage = "The type cannot be more than 5000 characters long.")]
        public string BaseCode { get; set; }

        [Display(Name = "CustomCode")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(5000, ErrorMessage = "The type cannot be more than 5000 characters long.")]
        public string CustomCode { get; set; }

        [Display(Name = "isVisible")]
        public bool isVisible { get; set; } 
    }
}