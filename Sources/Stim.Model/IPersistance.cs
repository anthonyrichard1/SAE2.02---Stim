using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistance
    {
        public void SaveGame(ObservableCollection<Game> games);
        public void SaveUser(List<User> users);
        public ObservableCollection<Game> LoadGame();
        public List<User> LoadUser();
    }
}
