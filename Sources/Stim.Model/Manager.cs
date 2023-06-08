using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Model
{
    public class Manager
    {
        public readonly IPersistance mgrpersistance;
        public ReadOnlyCollection<Game> GameList { get; private set; }
        private readonly List<Game> gameList;
        public Game? SelectedGame { get; set; }
        public User? CurrentUser { get; set; }
        public HashSet<User> Users { get; private set; }

        public Manager(IPersistance persistance)
        {
            mgrpersistance = persistance;
            gameList = persistance.LoadGame();
            GameList = new ReadOnlyCollection<Game>(gameList);
            Users = persistance.LoadUser();
        }

        public IEnumerable<Game> FilterGames(string? filterName, string? filterTag1, string? filterTag2)
        {
            IEnumerable<Game> retList;
            retList = gameList;
            if (filterName != null) retList = retList
                .Where(game => game.Name.Contains(filterName, StringComparison.OrdinalIgnoreCase)
                );
            if (filterTag1 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.Contains(filterTag1, StringComparison.OrdinalIgnoreCase))
                );
            if (filterTag2 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.Contains(filterTag2, StringComparison.OrdinalIgnoreCase))
                );
            return retList;
        }

        public void AddGametoGamesList(Game game)
        {
            if (!gameList.Contains(game)) gameList.Add(game);
            mgrpersistance.SaveGame(gameList);
        }
        public void AddUsertoUserList(User user)
        {
            if (!Users.Contains(user)) Users.Add(user);
            mgrpersistance.SaveUser(Users);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            SelectedGame = null;
            gameList.Remove(game);
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
    }
}
