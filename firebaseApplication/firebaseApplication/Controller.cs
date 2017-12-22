using FirebaseApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication.controller
{
    public class Controller
    {
        FirebaseDatabase fbData;
        FirebaseAutentication fba;
        List<Passwords> passwords;

        public Controller()
        {
            this.fbData = new FirebaseDatabase();
            this.fba = new FirebaseAutentication();
        }

        public bool login(string login, string password)
        {
            try
            {
                this.fba.SingIn(login, password);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addPassword(string uid, List<Passwords> passwords)
        {
            this.fbData.addPassword(uid, passwords);
        }

        public List<Passwords> getListPasswords(string uid)
        {
            try
            {
                return this.fbData.getPasswords(uid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
