using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class GameHandler
    {
        public List<Game> gamesList
        {
            get { return gamesList; }
        }
        public GameHandler()
        {
            List<Game> gamesList = new List<Game>();
        }
        public void AddGametoGamesList(List<Game> gamesList, Game game)
        {
            gamesList.Add(game);
        }
        public void RemoveGameFromGamesList(List<Game> gamesList, Game game)
        {
            gamesList.Remove(game);
        }
        public void DelCom(Game game, Review review, int role)
        {
            if (role >= 1)
            {
                game.RemoveReview(review);
            }
            return;
        }
    }
}
