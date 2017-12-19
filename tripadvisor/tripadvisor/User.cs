using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor.model
{
    public class User
    {
        string login;
        string password;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string Login { get => login; }
        public string Password { get => password; }

        public override bool Equals(object obj)
        {
            User user = obj as User;
            return user != null && this.login == user.Login && this.password == user.Password;
        }
    }
}
