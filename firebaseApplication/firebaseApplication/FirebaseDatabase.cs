using Firebase.Database;
using firebaseApplication;
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

        public FirebaseDatabase()
        {
            this.client = new FirebaseClient("https://application-cshar.firebaseio.com/"); ;
        }

        public void addPassword(string uid, Passwords passwords)
        {
            try
            {
                this.client.Child("password/" + uid).PostAsync(JsonConvert.SerializeObject(passwords));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updatePassword(string key, string keyPassword, Passwords passwords)
        {
            try
            {
                this.client.Child("password/" + key + "/" + keyPassword).PutAsync(JsonConvert.SerializeObject(passwords));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deletePassword(string key, string keyPassword)
        {
            try
            {
                this.client.Child("password/" + key + "/" + keyPassword).DeleteAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Firebase.Database.Query.ChildQuery getPasswords(string key)
        {
            try
            {
                //this.client.Child("password/").AsObservable<List<Passwords>>().Subscribe(d => Console.WriteLine(d.Key));
                return this.client.Child("password/" + key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void tete(string key)
        {
            var dinos = await this.client.Child("password/" + key).OnceAsync<Passwords>();
            foreach (var dino in dinos)
            {
                Console.WriteLine($"{dino.Key} is {dino.Object.Login}m high.");
            }
        }
    }
}
