using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor
{
    class UserNotExistException : Exception
    {
        public UserNotExistException() : base("User not exist")
        {
        }
    }
}
