using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerSolutionsPortal.Models
{
    public class JobApplicationModel
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}