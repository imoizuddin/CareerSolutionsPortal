using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models
{
    public class JobModel
    {
        
        public int JobId { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }

        [Display(Name = "Job Profile")]
        [Required]
        public string JobProfile { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        [Required]
        public int Salary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required]
        public DateTime JobPostedDate { get; set; }
    }
}