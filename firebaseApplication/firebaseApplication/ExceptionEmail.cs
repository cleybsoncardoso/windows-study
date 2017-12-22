using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication.email
{
    public class ExceptionEmail: Exception
    {
        public ExceptionEmail() : base("Email is not valid")
        {
            
        }
    }
}
