﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        static int nbUser = 0;
        private int id;

        public string Username
        {
            get { return username; }
            private set
            {
                if (value == null || value == "") return;
                username = value;
            }
        }
        private string username;

        public string Biographie 
        {
            get { return biographie;} 
            private set
            {
                if (value == null || value == "") return;
                biographie = value;
            }
        }
        private string? biographie;

        public string Email
        {
            get { return email; }
            private set
            {
                Regex rg_email = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (value != null && rg_email.IsMatch(value))
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
                if (value==null || !rg.IsMatch(value)) return;
                password = value;
            }
        }
        private string password;

        public int Role { get; }
        private int role;
        public List<Game> Followed_Games 
        {
            get;
            private init;
        }

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
        public void AddReview(Game game, float rate, string text)
        {
            game.AddReview(new Review(/*username,*/ rate, text));
        }
        public void RemoveSelfReview(Game game, float rate, string text)
        {
            foreach (Review review in game.Reviews)
            {
                if (review.Rate == rate && review.Text == text && review.AuthorName == username) game.RemoveReview(review);
            }
        }
        public void FollowAGame(Game game)
        {
            if (Followed_Games.Contains(game)) return;
            Followed_Games.Add(game);
        }
        public void RemoveAGame(Game game)
        {
            if (!Followed_Games.Contains(game)) return;
            Followed_Games.Remove(game);
        }
    }
}
