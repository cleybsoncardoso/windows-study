using Firebase.Auth;
using firebaseApplication.email;
using firebaseApplication.password;
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
        String key = "Y2xleUBnbWFpbC5jb20=";
        FirebaseAuthProvider ap = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDYoS-EC1BDb1Wlig9wbl_0R-y2mU-0cq8"));
 
        public Controller()
        {
            this.fbData = new FirebaseDatabase();
        }


        public async void login(string login, string password)
        {
            if (login.Equals(""))
            {
                throw new ExceptionEmail();
            }
            else if (password.Length < 6)
            {
                throw new ExceptionPasswordLength();
            }
            try
            {
                var auth = await this.ap.SignInWithEmailAndPasswordAsync(login, password);
                Console.WriteLine(!auth.FirebaseToken.Equals(""));
                if (!auth.FirebaseToken.Equals(""))
                {
                    this.key = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(auth.User.Email));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.TargetSite);
                throw new Exception();
            }
        }

        public bool createUser(string login, string password)
        {
            if (login.Equals(""))
            {
                throw new ExceptionEmail();
            }
            else if (password.Length < 6)
            {
                throw new ExceptionPasswordLength();
            }
            try
            {
                this.ap.CreateUserWithEmailAndPasswordAsync(login, password);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addPassword(Passwords passwords)
        {
            this.fbData.addPassword(this.key, passwords);
        }

        public Firebase.Database.Query.ChildQuery getListPasswords()
        {
            try
            {
                return this.fbData.getPasswords(this.key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
