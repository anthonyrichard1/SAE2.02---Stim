using Model;

namespace Test
{
    public class TestGame
    {
        public static IEnumerable<object[]> GameData
            => new List<object[]>
            {
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game(null, "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("game", "", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("game", null, 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("game", "description", 1111, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("game", "description", 9999, new List<String> { "1", "2", "3" }, "cover", "www.link.com") },
                new object[] {new Game("game", "description", 9999, null, "cover", "www.link.com") },
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2" }, "cover", "www.link.com") },
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2", "3" }, "", "www.link.com") },
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2", "3" }, null, "www.link.com") },
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "") },
                new object[] {new Game("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", null) }
            };
        public static IEnumerable<object[]> GameDataUser =>
           new List<object[]>
           {
                new object[]{GameData.ToList()[0], }
           };

        [Theory]
        [MemberData(nameof(GameData))]
        public void Constructor(Game game)
        {
            Assert.NotNull(game);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Name(Game game)
        {
            Assert.NotNull(game.Name);
            Assert.NotEqual("", game.Name);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Cover(Game game)
        {
            Assert.NotNull(game.Cover);
            Assert.NotEqual("", game.Cover);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Description(Game game)
        {
            Assert.NotNull(game.Description);
            Assert.NotEqual("", game.Description);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Year(Game game)
        {
            Assert.True(game.Year >= 1970);
            Assert.True(game.Year <= 2023);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Tags(Game game)
        {
            Assert.NotNull(game.Tags);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Lien(Game game)
        {
            Assert.NotNull(game.Lien);
            Assert.NotEqual("", game.Lien);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void AddReview(Game game)
        {
            var user = new User(null, "username", "biographie", "email@email.com", "Azerty123*");
            user.AddReview(game, 2.5f, "bof");
            Assert.NotEmpty(game.Reviews);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void RemoveReview(Game game)
        {
            var user = new User(null, "username", "biographie", "email@email.com", "Azerty123*");
            user.AddReview(game, 2.5f, "bof");
            user.RemoveSelfReview(game, 2.5f, "bof");
            Assert.Empty(game.Reviews);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void ChangeName(Game game)
        {
            game.NameChange("newName");
            Assert.Equal("newName", game.Name);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void ChangeDescription(Game game)
        {
            game.DescChange("newDesc");
            Assert.Equal("newDesc", game.Description);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void ChangeYear(Game game)
        {
            game.YearChange(2020);
            Assert.Equal(2020, game.Year);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void ChangeTags(Game game)
        {
            game.TagChange(new List<String> { "1", "2" });
            Assert.Equal(2, game.Tags.Count);
            game.TagChange(null);
            Assert.Equal(2, game.Tags.Count);
            game.TagChange(new List<String> { "1", "2", "3", "4" });
            Assert.Equal(2, game.Tags.Count);
        }

        [Theory]
        [MemberData(nameof(GameData))]
        public void Hash(Game game)
        {
            Assert.Equal(game.Name.GetHashCode(), game.GetHashCode());
        }

        [Fact]
        public void Equal()
        {
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            Game game2 = new("name2", "description", 2020, new List<String> { "1" }, "cover2", "www.link.com");
            Game? game3 = null;
            string game4 = "";
            Game game5 = new("name", "description2", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");

            Assert.False(game.Equals(game2 as Game));
            Assert.False(game.Equals(game3 as object));
            Assert.True(game.Equals(game as object));
            Assert.False(game.Equals(game4 as object));
            Assert.False(game.Equals(game2 as object));
            Assert.True(game.Equals(game5 as Game));
        }

        [Fact]
        public void Str()
        {
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            Review rev = new("User 1", 3, "rev");
            Review rev2 = new("User 2", 4, "rev2");
            game.AddReview(rev);
            game.AddReview(rev2);
            Assert.Equal("name : description : 2012 : cover : www.link.com\nUser 1 : 3 : rev\nUser 2 : 4 : rev2\n", game.ToString());
        }
    }
}