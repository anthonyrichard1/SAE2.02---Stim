using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public interface Persistable
    {
        public void Load()
        {
            Console.WriteLine("Todo");
            //To do
        }
        public void Save(List<Game> gamesList) 
        {
            Console.WriteLine("Todo");
            //To do
        }
    }
}
