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
        }

        [Fact]
        public void Name()
        {

            Game game = new("", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Null(game.Name);

            Game game2 = new(null, "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Null(game2.Name);

            Game game3 = new("good", "description", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Equal("good", game3.Name);
        }

        [Fact]
        public void Description()
        {

            Game game = new("name", "", 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Null(game.Description);

            Game game2 = new("name", null, 2012, new List<String> {"1","2","3"}, "cover");
            Assert.Null(game2.Description);

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
            Assert.Empty(game3.Tags);
        }
        
        [Fact]
        public void AddReview()
        {
            Review r1 = new(2.5f, "cool"), r2 = new(4, "tres cool"), r3 = new(1, "pas cool");

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            game.AddReview(r1);
            game.AddReview(r2);
            game.AddReview(r3);

            Assert.NotEmpty(game.Reviews);
        }

        [Fact]
        public void RemoveReview()
        {
            Review r1 = new(2.5f, "cool"), r2 = new(4, "tres cool"), r3 = new(1, "pas cool");

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            game.AddReview(r1);
            game.AddReview(r2);
            game.AddReview(r3);
            game.RemoveReview(r2);

            Assert.DoesNotContain(r2, game.Reviews);
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
            Assert.Empty(game.Tags);
        }

        [Fact]
        public void Average()
        {
            Review r1 = new(2.5f, "cool"), r2 = new(4, "tres cool"), r3 = new(1, "pas cool");

            Game game = new("name", "description", 2012, new List<String> {"1","2","3"}, "cover");

            game.AddReview(r1);
            game.AddReview(r2);
            game.AddReview(r3);

            Assert.Equal(2.5f, game.GetAvgRate());
        }
    }
}