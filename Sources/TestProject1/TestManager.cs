using Model;
using StimPersistance;
using StimStub;

namespace Test
{
    public class TestManager
    {
        [Fact]
        public void Constructor()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            Assert.NotNull(manager);
        }

        [Fact]
        public void AddAndRemoveGame()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            Game game = new("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            manager.AddGametoGamesList(game);

            Assert.Contains(game, manager.GameList);
            manager.RemoveGameFromGamesList(game);
            Assert.DoesNotContain(game, manager.GameList);
        }
        [Fact]
        public void AddUser()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            User user = new("", "username", "", "gmail@gmail.com", "Azerty123*");
            manager.AddUsertoUserList(user);

            Assert.Contains(user, manager.Users);
        }
    }
}
