using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public IPersistance persistance;
        public ObservableCollection<Game> GameList { get;}

        public Manager(IPersistance persistance)
        {
            persistance = persistance;
            GameList = persistance.LoadGame();
            if (GameList == null) { GameList = new ObservableCollection<Game>();}
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            persistance.SaveGame(GameList);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
            persistance.SaveGame(GameList);
        }

        /*public void LoadGames()
        {
            _persistance.LoadGame();
        }*/
        public void SaveGames()
        {
            persistance.SaveGame(GameList);
        }
    }
}
