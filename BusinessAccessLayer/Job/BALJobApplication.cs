using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Job
{
    public class BALJobApplication
    {

        int _applicationId;
        public int ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("ApplicationId cannot be null");
                }
                else
                {
                    _applicationId = value;
                }
            }

        }
        int _jobId;
        public int JobId
        {
            get { return _jobId; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("JobId cannot be null");
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
                    throw new ArgumentNullException("EmployeeId cannot be null");
                }
                else
                {
                    _employeeId = value;
                }
            }

        }
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("UserId cannot be null");
                }
                else
                {
                    _userId = value;
                }
            }

        }
        public DateTime AppliedDate { get; set; }
    }
}
