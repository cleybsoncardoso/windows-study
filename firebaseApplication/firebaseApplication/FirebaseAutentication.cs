using Firebase.Auth;
using firebaseApplication.email;
using firebaseApplication.password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication.autentication
{
    /*
     * Class for create and login of users
     * 
     */
    class FirebaseAutentication
    {
        FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDYoS-EC1BDb1Wlig9wbl_0R-y2mU-0cq8"));


        //method for make login of user
        public async Task<FirebaseAuthLink> login(string login, string password)
        {

            //if login is empty throw exception
            if (login.Equals(""))
            {
                throw new ExceptionEmail();
            }//if password is empty throw exception
            else if (password.Length < 6)
            {
                throw new ExceptionPasswordLength();
            }
            try
            {
                return await this.firebaseAuthProvider.SignInWithEmailAndPasswordAsync(login, password);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                //if the erro is password invalid, modify message of erro
                if (ex.Message.Contains("INVALID_PASSWORD"))
                {
                    argEx = new System.ArgumentException("Password wrong", ex);
                }//if the erro is of email not exist, modify message of erro
                else if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    argEx = new System.ArgumentException("Email not is registered", ex);
                }
                throw argEx;
            }
        }

        //method for create user
        public async Task<FirebaseAuthLink> createUser(string login, string password)
        {
            //if login is empty throw exception
            if (login.Equals(""))
            {
                throw new ExceptionEmail();
            }//if password is empty throw exception
            else if (password.Length < 6)
            {
                throw new ExceptionPasswordLength();
            }
            try
            {
                //create user
                return await this.firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(login, password);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                //if the erro is Email existing, modify message of erro
                if (ex.Message.Contains("EmailExist"))
                {
                    argEx = new System.ArgumentException("Email already registered", ex);
                }
                throw argEx;
            }
        }
    }
}
