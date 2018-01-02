using Firebase.Database;
using firebaseApplication;
using firebaseApplication.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseApplication
{
    public class FirebaseDatabase
    {

        FirebaseClient client;

        public FirebaseDatabase(string token)
        {
            this.client = new FirebaseClient("https://application-cshar.firebaseio.com/",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(token)
              });
        }

        /*
         * 
         * Add new password
         * 
         * string key = Base64 email to find user data
         * Passwords passwords = new password for register
         */
        public async void addPassword(string key, Passwords passwords)
        {
            try
            {
                await this.client.Child("password/" + key).PostAsync(JsonConvert.SerializeObject(passwords));

            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        /*
         * Update data of password
         * string key = Base64 email to find user data
         * string keyPassword = password firebase key that will be changed 
         * Passwords passwords = password changed
         */
        public async void updatePassword(string key, string keyPassword, Passwords passwords)
        {
            try
            {
                await this.client.Child("password/" + key + "/" + keyPassword).PutAsync(JsonConvert.SerializeObject(passwords));

            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        /*
         * Delete password
         * 
         * string key = Base64 email to find user data
         * string keyPassword = password firebase key that will be deleted 
         * 
         */
        public async void deletePassword(string key, string keyPassword)
        {
            try
            {
                await this.client.Child("password/" + key + "/" + keyPassword).DeleteAsync();

            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }

        /*
         * Method return all passwords registered
         * 
         * string key = Email in base64
         */
        public async Task<IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>>> getPasswords(string key)
        {
            try
            {
                return await this.client.Child("password/" + key).OnceAsync<Passwords>();
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException(ex.Message, ex);
                throw argEx;
            }
        }
    }
}
