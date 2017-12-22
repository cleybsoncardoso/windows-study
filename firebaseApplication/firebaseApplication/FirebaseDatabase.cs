using firebaseApplication;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://application-cshar.firebaseio.com/"
        };
        FirebaseClient client;

        public FirebaseDatabase()
        {
           this.client = new FirebaseClient(config);
        }

        public async void addPassword(string uid, List<Passwords> passwords)
        {
            try
            {
                var response = this.client.SetAsync("password/"+uid, passwords);
                Console.WriteLine("_______");
                Console.WriteLine(response.Result);

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Passwords> getPasswords(string uid)
        {
            try
            {
                var response = this.client.GetAsync("password/" + uid);
                return response.Result.ResultAs<List<Passwords>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
