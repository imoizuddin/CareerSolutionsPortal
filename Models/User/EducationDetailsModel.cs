using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models.User
{
    public class EducationDetailsModel
    {
       
        public int UserId { get; set; }

        [Display(Name = "Qualification")]
        [Required]
        public string Qualification { get; set; }

        [Display(Name = "Specialization")]
        [Required]
        public string Specialization { get; set; }

        [Display(Name = "University")]
        [Required]
        public string University { get; set; }

        [Display(Name = "Course Type")]
        [Required]
        public string CourseType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Year of Completion")]
        [Required]
        public DateTime PassingYear { get; set; }
    }
}