using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class BALJobModel
    {


        int _jobId;
        public int JobId
        {
            get { return _jobId; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Job id cannot be null");
                }
                else
                {
                    _jobId = value;
                }
            }

        }

        int _employeeId;
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Employee id cannot be null");
                }
                else
                {
                    _employeeId = value;
                }
            }

        }

        public string CompanyName { get; set; }

        public string JobProfile { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public DateTime JobPostedDate { get; set; }
    }
}
