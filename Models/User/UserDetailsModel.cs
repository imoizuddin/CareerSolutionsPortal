using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models.User
{
    public class UserDetailsModel
    {
        public int UserId { get; set; }

        [Display(Name = "TotalExperience")]
        [Required]
        public int TotalExperience { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "NoticePeriod")]
        [Required]
        public int NoticePeriod { get; set; }

        [Display(Name = "CurrentCompany")]
        public string CurrentCompany { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }
        public string Skills { get; set; }

        //List<EducationDetailsModel> educations = new List<EducationDetailsModel>();
    }
}