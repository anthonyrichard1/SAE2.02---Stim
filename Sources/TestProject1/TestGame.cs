using Model;

namespace Test
{
    public class TestGame
    {
        [Fact]
        public void Constructeur()
        {

            Game game = new("game", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.NotNull(game);
            Game game2 = new();
            Assert.NotNull(game2);
        }

        [Fact]
        public void Name()
        {

            Game game = new("", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.True(game.Name == "");

            Game game2 = new(null, "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.True(game2.Name == "Default");

            Game game3 = new("good", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Equal("good", game3.Name);
        }
        [Fact]
        public void Cover()
        {
            Game game = new("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover");
            string coverofgame= game.Cover;
            Assert.True(coverofgame == game.Cover);
        }
        [Fact]
        public void Description()
        {

            Game game = new("name", "", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.True(game.Description == "");

            Game game2 = new("name", null, 2012, new List<String> {"1","2","3"}, "cover");
            Assert.True(game2.Description=="Default");

            Game game3 = new("name", "good", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Equal("good", game3.Description);
        }
        
        [Fact]
        public void Year()
        {

            Game game = new("name", "description", 1111, new List<String> {"1","2","3"}, "cover");
            Assert.Equal(0, game.Year);

            Game game2 = new("name", "description", 9999, new List<String> {"1","2","3"}, "cover");
            Assert.Equal(0, game2.Year);

            Game game3 = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Equal(2012, game3.Year);
        }

        [Fact]
        public void Tags()
        {
            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.NotNull(game.Tags);

            Game game2 = new("name", "description", 2012, null, "cover");
            Assert.NotNull(game2.Tags);
            Assert.Empty(game2.Tags);

            Game game3 = new("name", "description", 2012, new List<String> {"1","2"}, "cover");
            Assert.NotNull(game3.Tags);
            Assert.Equal(2,game3.Tags.Count);
        }
        
        [Fact]
        public void AddReview()
        {
            User user = new("username", "biographie", "email@email.com", "password");

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            user.AddReview(game, 2.5f, "bof");
            user.AddReview(game, 4f, "bof++");
            user.AddReview(game, 3f, "bof+");

            Assert.NotEmpty(game.Reviews);
        }

        [Fact]
        public void RemoveReview()
        {
            User user = new("username", "biographie", "email@email.com", "password");
            User user2 = new("username2", "biographie", "email2@email.com", "password");
            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            user.AddReview(game, 2.5f, "bof");
            user.AddReview(game, 4f, "bof++");
            user.AddReview(game, 3f, "bof+");
            user2.RemoveSelfReview(game, 2.5f, "bof");
            Assert.Equal(3, game.Reviews.Count);
            user.RemoveSelfReview(game, 2.5f, "bof");
            Assert.Equal(2, game.Reviews.Count);
        }

        [Fact]
        public void ChangeName()
        {

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");
            game.NameChange("newName");

            Assert.Equal("newName", game.Name);
        }

        [Fact]
        public void ChangeDescription()
        {

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");
            game.DescChange("newDesc");

            Assert.Equal("newDesc", game.Description);
        }

        [Fact]
        public void ChangeYear()
        {

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");
            game.YearChange(2020);

            Assert.Equal(2020, game.Year);
        }

        [Fact]
        public void ChangeTags()
        {
            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover");
            game.NameChange("newName");
            game.TagChange(new List<String> { "1", "2" });
            Assert.Equal(2, game.Tags.Count);
            game.TagChange(null);
            Assert.Equal(2, game.Tags.Count);
            game.TagChange(new List<String> { "1", "2","3","4" });
            Assert.Equal(2, game.Tags.Count);
        }

        [Fact]
        public void Average()
        {
            User user = new("username", "biographie", "email@email.com", "password");

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            user.AddReview(game, 2.5f, "bof");
            user.AddReview(game, 0f, "bof--");
            user.AddReview(game, 5f, "bof++");

            Assert.Equal(2.5f, game.GetAvgRate());
        }

        [Fact]
        public void toString()
        {
            User user = new("username", "biographie", "email@email.com", "password");

            Game game = new("name", "description", 2012, new List<String> { "1", "2", "3" }, "cover");

            user.AddReview(game, 2.5f, "bof");
            user.AddReview(game, 0f, "bof--");
            user.AddReview(game, 5f, "bof++");

            Assert.Equal("bof\nbof--\nbof++",user.ToString());
        }
    }
}