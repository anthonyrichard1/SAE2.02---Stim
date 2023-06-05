using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class Manager
    {
        private readonly IPersistance mgrpersistance;
        public IReadOnlyList<Game> GameList => gameList.AsReadOnly();
        private List<Game> gameList;
        public Game? SelectedGame { get; set; }
        public User? CurrentUser { get; set; }
        public HashSet<User> Users { get; private set; }

        public Manager(IPersistance persistance)
        {
            mgrpersistance = persistance;
            gameList = persistance.LoadGame();
            Users = persistance.LoadUser();
        }

        public IEnumerable<Game> FilterGames(string? filterName, string? filterTag1, string? filterTag2)
        {
            IEnumerable<Game> retList;
            retList = GameList;
            if (filterName != null) retList = retList
                .Where(game => game.Name.IndexOf(filterName, StringComparison.OrdinalIgnoreCase) >= 0
                );
            if (filterTag1 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.IndexOf(filterTag1, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            if (filterTag2 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.IndexOf(filterTag2, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            return retList;
        }

        public void AddGametoGamesList(Game game)
        {
            gameList.Add(game);
            mgrpersistance.SaveGame(gameList);
        }
        public void AddUsertoUserList(User user)
        {
            Users.Add(user);
            mgrpersistance.SaveUser(Users);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            gameList.Remove(game);
            mgrpersistance.SaveGame(gameList);
        }

        public void SaveGames()
        {
            mgrpersistance.SaveGame(gameList);
        }
        public User? SearchUser(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username) return user;
            }
            return null;
        }
        public void SaveUser()
        {
            mgrpersistance.SaveUser(Users);
        }
    }
}
