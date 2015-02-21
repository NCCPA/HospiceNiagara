using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class Death
    {
         public Death()
        {
           
        }

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the title blank.")]
        [StringLength(100, ErrorMessage = "The Name cannot be more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "The Location cannot be more than 100 characters long.")]
        public string Location { get; set; }

        [Display(Name = "Note")]
        [StringLength(100, ErrorMessage = "The Location cannot be more than 100 characters long.")]
        public string Note { get; set; }

        [Display(Name = "isVisible")]
        public bool isVisible { get; set; }

        //id of person
       // [Required(ErrorMessage = "You must select a User.")]
        public int CreatedByID { get; set; }

    }
}