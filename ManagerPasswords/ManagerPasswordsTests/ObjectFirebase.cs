using firebaseApplication.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerPasswordsTests
{
    public class ObjectFirebase
    {
        Passwords valueSave;
        string key;

        public ObjectFirebase(string key, Passwords valueSave)
        {
            this.key = key;
            this.valueSave = valueSave;
        }


        public string Key
        {
            get
            {
                return key;
            }
        }


        public Passwords Object
        {
            get
            {
                return valueSave;
            }
        }



    }
}
