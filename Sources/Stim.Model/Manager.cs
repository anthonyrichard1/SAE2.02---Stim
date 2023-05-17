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
            Games.Add(new("Elden Ring", "description", 2010, new List<string> { "1","2","3"}, "elden_ring.jpg"));
            Games.Add(new("Minecraft", "description", 2010, new List<string> { "1", "2", "3" }, "minecraft.jpeg"));
            Games.Add(new("Celeste", "description", 2010, new List<string> { "1", "2", "3" }, "celeste.png"));
            Games.Add(new("GTA V", "description", 2010, new List<string> { "1", "2", "3" }, "gta_v.png"));
        }
    }
}
