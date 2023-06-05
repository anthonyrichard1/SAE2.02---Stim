using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class Manager
    {
        private IPersistance Mgrpersistance { get; set; }
        public ObservableCollection<Game> GameList { get; set; }
        public ObservableCollection<Game> ResearchedGame { get; set; }
        public Game? SelectedGame { get; set; }
        public User? CurrentUser { get; set; }
        public HashSet<User> Users { get; set; }

        public Manager(IPersistance persistance)
        {
            Mgrpersistance = persistance;
            GameList = persistance.LoadGame();
            ResearchedGame = persistance.LoadGame();
            Users = persistance.LoadUser();
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            Mgrpersistance.SaveGame(GameList);
        }
        public void AddUsertoUserList(User user)
        {
            Users.Add(user);
            Mgrpersistance.SaveUser(Users);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
            Mgrpersistance.SaveGame(GameList);
        }

        public void SaveGames()
        {
            Mgrpersistance.SaveGame(GameList);
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
            Mgrpersistance.SaveUser(Users);
        }
    }
}
