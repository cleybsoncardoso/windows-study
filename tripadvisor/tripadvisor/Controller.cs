using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tripadvisor.exception;
using tripadvisor.model;

namespace tripadvisor.controller
{
    public class Controller
    {
        private List<User> users;
        private User userLogged;
        private List<Attraction> attractions;

        public Controller()
        {
            this.users = new List<User>();
            this.attractions = new List<Attraction>();
            this.userLogged = null;
        }

        public bool addUser(User newUser)
        {
            int countUserEquals = (from user in this.users where user.Login == newUser.Login select user).Count();
            //check if exist user with the same login
            if (countUserEquals == 0)
            {
                this.users.Add(newUser);
                return true;
            }
            return false;
        }

        public bool singin(string login, string password)
        {
            foreach (User userCurrent in this.users)
            {
                if (userCurrent.Login.Equals(login))
                {
                    if (userCurrent.Password.Equals(password))
                    {
                        this.userLogged = userCurrent;
                        return true;
                    }
                    else
                    {
                        throw new UserPasswordException();
                    }
                }
            }
            throw new UserNotExistException();
        }

        public List<User> Users { get => users; }
        public List<Attraction> Attractions { get => attractions; }



    }
}
