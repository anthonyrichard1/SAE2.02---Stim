using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim
{
    internal class User
    {
        static int nbUser=0;
        public int Id { get; }
        public string Username { get; set; }
        public string Biographie { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Game> Games { get; set; }

        public User(string username, string biographie, string email, string password)
        {
            nbUser++;
            Id = nbUser;

            Username = username;
            Biographie = biographie;
            Email = email;
            Password = password;
            Games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
        }
    }
}
