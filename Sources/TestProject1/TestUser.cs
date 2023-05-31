using Model;

namespace Test
{
    public class TestUser
    {
        [Fact]
        public void Constructor()
        {
            User user = new(null,"username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
        }

        [Fact]
        public void Username()
        {
            User user = new(null, "", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Default", user.Username);

            User user2 = new(null, null, "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Default",user2.Username);
        }

        [Fact]
        public void Biographie()
        {
            User user = new(null, "username", "", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Default", user.Biographie);

            User user2 = new(null, "username", null, "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Default", user2.Biographie);

            User user3 = new(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");

            string biographieOfAnUser = user3.Biographie;
            Assert.Equal("biographie", biographieOfAnUser);
        }

        [Fact]
        public void Email()
        {
            User user = new(null, "username", "biographie", "", "Azerty123*");
            Assert.Equal("Default", user.Email);

            User user2 = new(null, "username", "biographie", null, "Azerty123*");
            Assert.Equal("Default", user2.Email);
        }

        [Fact]
        public void Password()
        {

            Assert.Throws<ArgumentNullException>(() => new User (null, "username", "biographie", "adresse.mail@gmail.com", ""));

            Assert.Throws<ArgumentNullException>(() => new User(null, "username", "biography", "adresse.mail@gmail.com", null));

            Assert.Throws<ArgumentNullException>(() => new User (null, "username", "biographie", "adresse.mail@gmail.com", "54az6e"));

            User user = new(null, "username", "bio", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Azerty123*", user.Password);
        }

        [Fact]
        public void AddingAndAddingGameToFollowed()
        {
            User user = new(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
            Assert.Empty(user.Followed_Games);

            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            Assert.NotNull(game);
            user.FollowAGame(game);
            Assert.Single(user.Followed_Games);
            user.RemoveAGame(game);
            Assert.Empty(user.Followed_Games);
        }

        [Fact]
        public void ReviewAddingAndRemovingFromAGameViaUser()
        {
            User user = new(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" },"cover", "www.link.com");
            Assert.NotNull(user);
            Assert.NotNull(game);


        //    user.AddReview(game, 2.5f,"UwU");
        //    Assert.Single(game.Reviews);

            user.RemoveSelfReview(game, 2.5f, "UwU");
            Assert.Empty(game.Reviews);
        }
        
    }
}
