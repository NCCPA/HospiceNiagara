using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class Setting
    {
        public Setting()
        {
           
        }

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the title blank.")]
        [StringLength(100, ErrorMessage = "The Name cannot be more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(200, ErrorMessage = "The Description cannot be more than 200 characters long.")]
        public string Description { get; set; }

        [Display(Name = "DefaultValue")]
        [StringLength(200, ErrorMessage = "The DefaultValue cannot be more than 200 characters long.")]
        public string DefaultValue { get; set; }

        [Display(Name = "CurrentValue")]
        [StringLength(200, ErrorMessage = "The DefaultValue cannot be more than 200 characters long.")]
        public string CurrentValue { get; set; }
    }
}