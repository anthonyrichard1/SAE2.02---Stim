using System.Collections.ObjectModel;

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
