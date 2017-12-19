using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor.exception
{
    class UserPasswordException : Exception
    {
        public UserPasswordException() : base("Password incorrect")
        {
        }
    }
}
