using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manager
    {
        public List<Game> Games = new();
        private IPersistance _persistance;

        public Manager(IPersistance persistance)
        { 
            _persistance = persistance;
            Games = _persistance.LoadGame();
        }
    }
}
