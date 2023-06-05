using System.Collections.ObjectModel;

namespace Model
{
    public interface IPersistance
    {
        public void SaveGame(List<Game> games);
        public void SaveUser(HashSet<User> users);
        public List<Game> LoadGame();
        public HashSet<User> LoadUser();

    }
}
