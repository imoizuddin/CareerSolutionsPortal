using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models.RegisterModels
{
    public class UserRegisterModel
    {
        public int UserId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }



    }
}