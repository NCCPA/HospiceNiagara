using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class CJType
    {
               public CJType()
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

        [Display(Name = "Type")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(50, ErrorMessage = "The type cannot be more than 50 characters long.")]
        public string Type { get; set; }

        [Display(Name = "Extension")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(5, ErrorMessage = "The type cannot be more than 5 characters long.")]
        public string Extension { get; set; }

        [Display(Name = "HTMLInclude")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(5000, ErrorMessage = "The text cannot be more than 5000 characters long.")]
        public string HTMLInclude { get; set; }

         [Display(Name = "Code")]
        //[Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(5000, ErrorMessage = "The text cannot be more than 5000 characters long.")]
        public string Code { get; set; }

  
        [Display(Name = "inUse")]
        public bool isVisible { get; set; }
    }
}