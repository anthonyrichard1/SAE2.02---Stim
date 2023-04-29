using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Stim
{
    internal class User
    {
        static int nbUser=0;
        private int id;

        public string Username
        {
            get { return Username; }
            private set
            {
                username = value;
            }
        }
        private string username;

        public string Biographie { get; set; }

        public string Email
        {
            get { return email; }
            private set
            {
                //check email
                email = value;
            }
        }
        private string email;

        public string Password
        {
            get { return  password; }
            private set
            {
                Regex rg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                if (!rg.IsMatch(password)) return;
                password = value;
            }
        }
        private string password;
        public List<Game> Games { get; set; }

        public User(string username, string biographie, string email, string password)
        {
            nbUser++;
            id = nbUser;

            Username = username;
            Biographie = biographie;
            Email = email;
            Password = password;
            Games = new List<Game>();
        }
    }
}
