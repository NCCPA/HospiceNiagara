﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models
{
    public class SubRole
    {

            public int ID { get; set; }

            [Display(Name = "Sub Role Name")]
            [Required(ErrorMessage = "You cannot leave the Sub Role blank.")]
            [StringLength(200, ErrorMessage = "Sub Role cannot be more than 200 characters long.")]
            public string roleName { get; set; }

            [Required(ErrorMessage = "You must select a Role.")]
            public int RoleID { get; set; }
            public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}