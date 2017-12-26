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
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
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
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        public void addPassword(Passwords passwords)
        {
            this.fbData.addPassword(this.key, passwords);
        }

        public void updatePassword(string keyPassword, Passwords passwords)
        {
            try
            {
                this.fbData.updatePassword(this.key, keyPassword, passwords);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        public void deletePassword(string keyPassword)
        {
            try
            {
                this.fbData.deletePassword(this.key, keyPassword);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        public Firebase.Database.Query.ChildQuery getListPasswords()
        {
            try
            {
                return this.fbData.getPasswords(this.key);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Index is out of range", ex);
                throw argEx;
            }
        }

        public Firebase.Database.Query.ChildQuery getListPasswords(String keyPassword)
        {
            try
            {
                return this.fbData.getPasswords(this.key + "/" + keyPassword);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Index is out of range", ex);
                throw argEx;
            }
        }
    }
}
