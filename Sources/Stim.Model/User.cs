﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stim.Model
{
    internal class User
    {
        static int nbUser = 0;
        private int id;

        public string Username
        {
            get { return username; }
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
                Regex rg_email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (rg_email.IsMatch(email))
                    email = value;
                return;
            }
        }
        private string email;

        public string Password
        {
            get { return password; }
            private set
            {
                Regex rg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,32}$");
                if (!rg.IsMatch(password)) return;
                password = value;
            }
        }
        private string password;
        public List<Game> Followed_Games { get; set; }

        public User(string username, string biographie, string email, string password)
        {
            nbUser++;
            id = nbUser;

            Username = username;
            Biographie = biographie;
            Email = email;
            Password = password;
            Followed_Games = new List<Game>();
        }
    }
}