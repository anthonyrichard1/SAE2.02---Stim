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
            Assert.Null(user.Username);
        }
        [Fact]
        public void AddingAndAddingGameToFollowed()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
            Assert.Empty(user.Followed_Games);

            Game game = new("name", "description", 2012, new string[] { "1", "2", "3" });
            Assert.NotNull(game);
            user.FollowAGame(game);
            Assert.Single(user.Followed_Games);
            user.RemoveAGame(game);
            Assert.Empty(user.Followed_Games);
        }
        /*
        [Fact]
        public void ReviewAddingAndRemovingFromAGameViaUser()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Game game = new("name", "description", 2012, new string[] { "1", "2", "3" });
            Assert.NotNull(user);
            Assert.NotNull(game);


            user.AddReview(game, 2.5f,"UwU");
            Assert.Single(game.Reviews);

            user.RemoveSelfReview(game, 2.5f, "UwU");
            Assert.Empty(game.Reviews);
        }
        */
    }
}
