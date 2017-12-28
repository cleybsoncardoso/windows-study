using Firebase.Auth;
using firebaseApplication.autentication;
using firebaseApplication.email;
using firebaseApplication.model;
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
        FirebaseDatabase firebaseDatabase;
        FirebaseAutentication firebaseAutentication;
        String key = ""; //key to access password list of user logger
        FirebaseAuthLink userLogged;

        public Controller()
        {
            this.firebaseDatabase = new FirebaseDatabase();
            this.firebaseAutentication = new FirebaseAutentication();
        }

        //method for make login of user
        public async Task<FirebaseAuthLink> login(string login, string password)
        {
            try
            {

                this.userLogged = await this.firebaseAutentication.login(login, password);
                this.key = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(this.userLogged.User.Email));
                return this.userLogged;
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        //method for create user
        public async Task<FirebaseAuthLink> createUser(string login, string password)
        {
            try
            {
                //create user
                return await this.firebaseAutentication.createUser(login, password);
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

        public void addPassword(Passwords passwords)
        {
            this.firebaseDatabase.addPassword(this.key, passwords);
        }

        public void updatePassword(string keyPassword, Passwords passwords)
        {
            try
            {
                this.firebaseDatabase.updatePassword(this.key, keyPassword, passwords);
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
                this.firebaseDatabase.deletePassword(this.key, keyPassword);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        /*
         * Get list passwords
         * 
         */
        public async Task<IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>>> getListPasswords()
        {
            try
            {
                return await this.firebaseDatabase.getPasswords(this.key);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }
    }
}
