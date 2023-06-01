using System.Collections.ObjectModel;

namespace Model
{
    public interface IPersistance
    {
        public void SaveGame(ObservableCollection<Game> games);
        public void SaveUser(HashSet<User> users);
        public ObservableCollection<Game> LoadGame();
        public HashSet<User> LoadUser();

    }
}
