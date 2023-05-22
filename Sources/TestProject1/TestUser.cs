using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestUser
    {
        [Fact]
        public void Constructor()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
        }

        [Fact]
        public void Username()
        {
            User user = new("", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user.Username);

            User user2 = new(null, "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user2.Username);
        }

        [Fact]
        public void Biographie()
        {
            User user = new("username", "", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user.Biographie);

            User user2 = new("username", null, "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user2.Biographie);

            User user3 = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");

            string biographieOfAnUser = user3.Biographie;
            Assert.NotNull(biographieOfAnUser);
        }

        [Fact]
        public void Email()
        {
            User user = new("username", "biographie", "", "Azerty123*");
            Assert.Null(user.Email);

            User user2 = new("username", "biographie", null, "Azerty123*");
            Assert.Null(user2.Email);
        }

        [Fact]
        public void Password()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "");
            Assert.Null(user.Password);

            User user2 = new("username", "biographie", "adresse.mail@gmail.com", null);
            Assert.Null(user2.Password);

            User user3 = new("username", "biographie", "adresse.mail@gmail.com", "54az6e");
            Assert.Null(user3.Password);
        }

        [Fact]
        public void AddingAndAddingGameToFollowed()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
            Assert.Empty(user.Followed_Games);

            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover");
            Assert.NotNull(game);
            user.FollowAGame(game);
            Assert.Single(user.Followed_Games);
            user.RemoveAGame(game);
            Assert.Empty(user.Followed_Games);
        }
        [Fact]
        public void Role()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal(0,user.Role);

            int Perm = user.Role;
            Assert.True(user.Role == Perm);
        }
        
        [Fact]
        public void ReviewAddingAndRemovingFromAGameViaUser()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" },"cover");
            Assert.NotNull(user);
            Assert.NotNull(game);


            user.AddReview(game, 2.5f,"UwU");
            Assert.Single(game.Reviews);

            user.RemoveSelfReview(game, 2.5f, "UwU");
            Assert.Empty(game.Reviews);
        }
        
    }
}
