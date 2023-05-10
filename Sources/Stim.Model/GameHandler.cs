using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class GameHandler
    {
        public List<Game> gamesList
        {
            get { return gamesList}
        }
        public GameHandler()
        {
            List<Game> gamesList=new List<Game>();
        }
    }
}
