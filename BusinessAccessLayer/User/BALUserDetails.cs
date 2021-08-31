using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.User
{
    public class BALUserDetails
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

        public int TotalExperience { get; set; }

        public string Location { get; set; }

        public int NoticePeriod { get; set; }

        public string CurrentCompany { get; set; }

        public string Designation { get; set; }
        public string Skills { get; set; }
    }
}
