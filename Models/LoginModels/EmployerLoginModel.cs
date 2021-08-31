using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models
{
    public class EmployerLoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}