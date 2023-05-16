using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manager
    {
        public ObservableCollection<Game> Games { get; set; } = new();
        private IPersistance _persistance;

        public Manager(IPersistance persistance)
        { 
            _persistance = persistance;
            Games.Add(new("test", "description", 2010, new string[3] { "1", "2", "3" }));
            Games.Add(new("test2", "description", 2010, new string[3] { "1", "2", "3" }));
            Games.Add(new("test2", "description", 2010, new string[3] { "1", "2", "3" }));
        }
    }
}
