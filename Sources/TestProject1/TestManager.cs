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
        [Fact]
        public void GetSetCurrentUser()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            manager.CurrentUser = new("", "username", "", "gmail@gmail.com", "Azerty123*");
            Assert.Equal(new("", "username", "", "gmail@gmail.com", "Azerty123*"), manager.CurrentUser);
            User user = manager.CurrentUser;
            Assert.Equal(manager.CurrentUser, user);
        }
        [Fact]
        public void GetSetSelectedGame()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            manager.SelectedGame = new("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com");
            Assert.Equal(new("game", "description", 2012, new List<String> { "1", "2", "3" }, "cover", "www.link.com"), manager.SelectedGame);
            Game game = manager.SelectedGame;
            Assert.Equal(manager.SelectedGame, game);
        }
        [Fact]
        public void FilterGames()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);

            var compList = manager.FilterGames(null, null, null);
            var list = manager.FilterGames(null,null,null);
            Assert.Equal(list,manager.GameList);

            List<Game> compListAsList = compList.ToList();
            compListAsList.Clear();
            compList = compListAsList;
            list = manager.FilterGames("Elden Ring",null, null);
            foreach (var game in manager.GameList)
            {
                if (game.Name=="Elden Ring")
                {
                    compListAsList = compList.ToList();
                    compListAsList.Add(game);
                    compList = compListAsList;
                    break;
                }
            }
            Assert.Equal(compList, list);

            compListAsList = compList.ToList();
            compListAsList.Clear();
            compList = compListAsList;
            list = manager.FilterGames(null, "Action", null);
            foreach (var game in manager.GameList)
            {
                if (game.Tags.Any(tag=>tag == "Action"))
                {
                    compListAsList = compList.ToList();
                    compListAsList.Add(game);
                    compList = compListAsList;
                    break;
                }
            }
            Assert.Equal(compList, list);

            list = manager.FilterGames(null,null, "Action");
            Assert.Equal(compList, list);

            compListAsList = compList.ToList();
            compListAsList.Clear();
            compList = compListAsList; list = manager.FilterGames("Elden Ring", "Action", null);
            foreach (var game in manager.GameList)
            {
                if (game.Name=="Elden Ring" && game.Tags.Any(tag => tag == "Action"))
                {
                    compListAsList = compList.ToList();
                    compListAsList.Add(game);
                    compList = compListAsList;
                    break;
                }
            }
            Assert.Equal(compList, list);

            list = manager.FilterGames("Elden Ring", null, "Action");
            Assert.Equal(compList, list);

            compListAsList = compList.ToList();
            compListAsList.Clear();
            compList = compListAsList;
            list = manager.FilterGames("Elden Ring", "Action", "Solo");
            foreach (var game in manager.GameList)
            {
                if (game.Name=="Elden Ring" && game.Tags.Any(tag => tag == "Action" && game.Tags.Any(tag => tag == "Solo")))
                {
                    compListAsList = compList.ToList();
                    compListAsList.Add(game);
                    compList = compListAsList;
                    break;
                }
            }
            Assert.Equal(compList, list);
            list = manager.FilterGames(null, "Action", "Solo");
            compListAsList = compList.ToList();
            compListAsList.Clear();
            compList = compListAsList;
            compList = compListAsList; list = manager.FilterGames("Elden Ring", "Action", null);
            foreach (var game in manager.GameList)
            {
                if (game.Name == "Elden Ring" && game.Tags.Any(tag => tag == "Action"))
                {
                    compListAsList = compList.ToList();
                    compListAsList.Add(game);
                    compList = compListAsList;
                    break;
                }
            }
            Assert.Equal(compList, list);
        }
        [Fact]
        public void Search()
        {
            IPersistance persistance = new Stub();
            Manager manager = new(persistance);
            User user = new(null, "username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            manager.AddUsertoUserList(user);
            Assert.Equal(user, manager.SearchUser("username"));
        }
    }
}
