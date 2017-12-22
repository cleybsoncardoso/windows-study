using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication.password
{
    public class ExceptionPasswordLength: Exception
    {
        public ExceptionPasswordLength(): base("Password is not valid")
        {

        }

    }
}
