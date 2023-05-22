using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public ObservableCollection<Game> GameList { get;}

        public Manager(IPersistance persistance)
        { 
            GameList = persistance.LoadGame();
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
        }
    }
}
