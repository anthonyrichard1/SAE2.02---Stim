using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistance
    {
        public List<Game> LoadGame();
        public List<User> LoadUser();
        public void SaveUser(List<User> users);
        public void SaveGame(List<Game> games);
    }
}
