using Firebase.Database;
using firebaseApplication.controller;
using FirebaseApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebaseApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new SignIn());
        }
    }
}
