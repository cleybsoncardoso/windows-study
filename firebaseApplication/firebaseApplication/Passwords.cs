using firebaseApplication.email;
using firebaseApplication.password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication
{
    public class Passwords
    {
        string login;
        string password;

        public Passwords(string login, string password)
        {
            if (login == null || login.Equals(""))
            {
                throw new ExceptionEmail();
            } else if(password == null || password.Length < 4)
            {
                throw new ExceptionPasswordLength();
            }
            this.login = login;
            this.password = password;
        }

        public string[] ToArray()
        {
            return new string[2] { this.login, this.password }; ;
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
