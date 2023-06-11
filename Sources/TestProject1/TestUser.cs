using Model;

namespace Test
{
    public class TestUser
    {
        public static IEnumerable<object[]> UserData
            => new List<object[]>
            {
                new object[] {new User(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "", "biographie", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, null, "biographie", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "username", "", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "username", null, "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*") },
                new object[] {new User(null, "username", "biographie", "", "Azerty123*") },
                new object[] {new User(null, "username", "biographie", null, "Azerty123*") },
                new object[] {new User(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*") }
            };

        [Theory]
        [MemberData(nameof(UserData))]
        public void Constructor(User user)
        {
            Assert.NotNull(user);
        }

        [Theory]
        [MemberData(nameof(UserData))]
        public void Username(User user)
        {
            Assert.NotNull(user.Username);
            Assert.NotEqual("", user.Username);
        }

        [Theory]
        [MemberData(nameof(UserData))]
        public void Biographie(User user)
        {
            Assert.NotNull(user.Biographie);
            Assert.NotEqual("", user.Biographie);
        }

        [Theory]
        [MemberData(nameof(UserData))]
        public void Email(User user)
        {
            Assert.NotNull(user.Email);
            Assert.NotEqual("", user.Email);
        }

        [Fact]
        public void Password()
        {

            Assert.Throws<ArgumentNullException>(() => new User(null, "username", "biographie", "adresse.mail@gmail.com", ""));

            Assert.Throws<ArgumentNullException>(() => new User(null, "username", "biography", "adresse.mail@gmail.com", null));

            Assert.Throws<ArgumentNullException>(() => new User(null, "username", "biographie", "adresse.mail@gmail.com", "54az6e"));

            User user = new(null, "username", "bio", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Equal("Azerty123*", user.Password);
        }

        [Theory]
        [MemberData(nameof(UserData))]
        public void UserImage(User user)
        {
            Assert.NotNull(user.UserImage);
            Assert.NotEqual("", user.UserImage);
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
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            Assert.NotNull(user);
            Assert.NotNull(game);

            user.RemoveSelfReview(game, 2.5f, "UwU");
            Assert.Empty(game.Reviews);
        }

        [Fact]
        public void Eq()
        {
            User user = new("userimage", "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            User user2 = new("userimage", "username2", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            User user3 = new("userimage", "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            User? user4 = null;

            Assert.False(user.Equals(user2 as User));
            Assert.False(user.Equals(user2 as object));
            Assert.True(user.Equals(user3 as object));
            Assert.False(user.Equals(user4 as object));
            Assert.False(user.Equals(user2 as object));
        }

        [Theory]
        [MemberData(nameof(UserData))]
        public void Hashcode(User user)
        {
            Assert.Equal(user.GetHashCode(), user.Username?.GetHashCode());
        }
    }
}
