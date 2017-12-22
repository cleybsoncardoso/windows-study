using Firebase.Auth;
using firebaseApplication.email;
using firebaseApplication.password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication
{
    public class FirebaseAutentication
    {
        FirebaseAuthProvider ap;

        public FirebaseAutentication()
        {
            this.ap = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDYoS-EC1BDb1Wlig9wbl_0R-y2mU-0cq8"));
        }

        public bool singUp(string email, string password)
        {
            if (email.Equals(""))
            {
                throw new ExceptionEmail();
            } else if (password.Length < 6){
                throw new ExceptionPasswordLength();
            }
            try
            {
                this.ap.CreateUserWithEmailAndPasswordAsync(email, password);
            } catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool SingIn(string email, string password)
        {

            try
            {
                Console.WriteLine(email +"/"+ password);
                var aux = this.ap.SignInWithEmailAndPasswordAsync(email, password);
                Console.WriteLine(aux.Result.User.Email);
            } catch(Exception ex)
            {
                throw ex;
            }


            return false;
        }
    }
}
