using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class Role
    {
           
            public int ID { get; set; }

            [Display(Name = "Type")]
            [Required(ErrorMessage = "You cannot leave the type blank.")]
            [StringLength(50, ErrorMessage = "The type name cannot be more than 50 characters long.")]
            public string Name { get; set; }
    }
}