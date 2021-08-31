using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Login
{
    public class BALEmployerLogin
    {
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
    }
}
