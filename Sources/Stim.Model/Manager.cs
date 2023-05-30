using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public IPersistance Mgrpersistance;
        public ObservableCollection<Game> GameList { get;}
        public User CurrentUser { get; set; }

        public Manager(IPersistance persistance)
        {
            Mgrpersistance = persistance;
            CurrentUser = new User("username", "bio", "email@email.com", "password88");
            GameList = persistance.LoadGame();
            if (GameList == null) { GameList = new ObservableCollection<Game>();}
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            Mgrpersistance.SaveGame(GameList);
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
    }
}
