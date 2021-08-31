using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Register
{
    public class BALUserRegister
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
        public string FullName { get; set; }

        string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Email cannot be null");
                }
                else
                {
                    _email = value;
                }
            }

        }
        public string Password { get; set; }
        public int Phone { get; set; }
    }
}
