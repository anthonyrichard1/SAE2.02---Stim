using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public IPersistance _persistance;
        public ObservableCollection<Game> GameList { get;}

        public Manager(IPersistance persistance)
        {
            _persistance = persistance;
            GameList = persistance.LoadGame();
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            _persistance.SaveGame(GameList);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
            _persistance.SaveGame(GameList);
        }

        /*public void LoadGames()
        {
            _persistance.LoadGame();
        }*/
        public void SaveGames()
        {
            _persistance.SaveGame(GameList);
        }
    }
}
