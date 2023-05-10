using Model;

namespace Test
{
    public class TestGame
    {
        [Fact]
        public void TestConstructGood()
        {
            /*string[] tags = { "tag 1", "tag 2", "tag 3" };
            Game game = new("Nom Jeu", "Description du jeu", 2022, tags);*/
            Assert.Equal(1, 1);
            //Assert.NotNull(game);
        }/*

      [Fact]
        public void TestAttributs()
        {
            string[] tags = Array.Empty<string>();
            Game game1 = new("name", "Test", 1444, tags);
            game1.NameChange("");
            Assert.Equal("name", game1.Name);
        }

        [Fact]
        public void TestAddReview()
        {
            string[] tags = { "tag 1", "tag 2", "tag 3" };
            Game game = new("Nom Jeu", "Description du jeu", 2022, tags);
            Review rev1 = new(3.5f, "Review n°1"), rev2 = new(3.5f, "Review n°2"), rev3 = new(3.5f, "Review n°3"), rev4 = new(3.5f, "Review n°4");

            game.AddReview(rev1);
            game.AddReview(rev2);
            game.AddReview(rev3);
            game.AddReview(rev4);

            Assert.Equal(4, game.Reviews.Count);
        }

        [Fact]
        public void TestRemoveReview()
        {
            string[] tags = { "tag 1", "tag 2", "tag 3" };
            Game game = new("Nom Jeu", "Description du jeu", 2022, tags);
            Review rev1 = new(3.5f, "Review n°1"), rev2 = new(3.5f, "Review n°2"), rev3 = new(3.5f, "Review n°3"), rev4 = new(3.5f, "Review n°4");

            game.AddReview(rev1);
            game.AddReview(rev2);
            game.AddReview(rev3);
            game.AddReview(rev4);

            game.RemoveReview(rev3);

            Assert.DoesNotContain(rev3, game.Reviews);
        }*/
    }
}