using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.User
{
    public class BALEducationDetails
    {
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

        public string Qualification { get; set; }

        public string Specialization { get; set; }

        public string University { get; set; }

        public string CourseType { get; set; }

        public DateTime PassingYear { get; set; }
    }
}
