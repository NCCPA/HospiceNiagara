using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class Death
    {

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must supply a name.")]
        [StringLength(100, ErrorMessage = "The name can be no more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You cannot leave the date blank.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "The location can be more no more than 100 characters long.")]
        public string Location { get; set; }

        [Display(Name = "Note")]
        [StringLength(200, ErrorMessage = "The note can be no more than 200 characters long.")]
        public string Note { get; set; }

        [Display(Name = "Visible")]
        [Range(0, 2, ErrorMessage = "The visable value is not valid.")]
        public int Visible { get; set; }

        //id of person
       // [Required(ErrorMessage = "You must select a User.")]
        public int CreatedByID { get; set; }

    }

    public class DeathViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must supply a name.")]
        [StringLength(100, ErrorMessage = "The name can be no more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "The location can be no more than 100 characters long.")]
        public string Location { get; set; }

        [Display(Name = "Note")]
        [StringLength(250, ErrorMessage = "The note can be no more than 250 characters long.")]
        public string Note { get; set; }

        [Display(Name = "Visible")]
        [Required]
        [Range(0, 2, ErrorMessage = "The visible range is invalid.")]
        public int Visible { get; set; }

        //id of person
        // [Required(ErrorMessage = "You must select a User.")]
        [Range(1, 9999, ErrorMessage = "The user range is invalid.")]
        public int CreatedByID { get; set; }
    }
}