using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public ObservableCollection<Game> GameList { get;}
        private readonly IPersistance _persistance;

        public Manager(IPersistance persistance)
        { 
            _persistance = persistance;
            GameList = _persistance.LoadGame();
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
        }

        //J'ai commenté parce que je crois que la fonction est useless

        //public void DelCom(Game game, Review review, int role)
        //{
        //    if (role >= 1) game.RemoveReview(review);
        //}
    }
}
