using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class Manager
    {
        public IPersistance Mgrpersistance
        { 
            get { return mgrpersistance; }
            set { mgrpersistance = value; }
        }
        private IPersistance mgrpersistance;
        public ObservableCollection<Game> GameList { get; set; }

        // dégage ça
        // fait une méthode qui te renvoie une liste filtrer avec les params (genre ton nom :D)
        // Quand t'ajoute peut être que dasn un certains monde
        // il y aura pas le pb car c'est le retour d'une collection Obs
        // donc potentiellement si les astres sont alignés ça devrait la mettre à jour
        public ObservableCollection<Game> ResearchedGame { get; set; }
        public Game? SelectedGame { get; set; }
        public User? CurrentUser { get; set; }
        public HashSet<User> Users { get; set; }

        public Manager(IPersistance persistance)
        {
            Mgrpersistance = persistance;
            GameList = persistance.LoadGame();
            ResearchedGame = persistance.LoadGame();
            Users = persistance.LoadUser();
        }

        public IEnumerable<Game> FilterGames(string? filterName, string? filterTag1, string? filterTag2)
        {
            IEnumerable<Game> retList;
            retList = GameList;
            if (filterName != null) retList = retList
                .Where(game => game.Name.IndexOf(filterName, StringComparison.OrdinalIgnoreCase) >= 0
                );
            if (filterTag1 != null) retList = retList
                .Where(game => game.Tags.Any(tag => tag.IndexOf(filterTag1, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            if (filterTag2 != null) retList = retList
                .Where(game => game.Tags.Any(tag => tag.IndexOf(filterTag2, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            return retList;
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            Mgrpersistance.SaveGame(GameList);
        }
        public void AddUsertoUserList(User user)
        {
            Users.Add(user);
            Mgrpersistance.SaveUser(Users);
        }

        public void RemoveGameFromGamesList(Game game)
        {
            GameList.Remove(game);
            Mgrpersistance.SaveGame(GameList);
        }

        public void SaveGames()
        {
            Mgrpersistance.SaveGame(GameList);
        }
        public User? SearchUser(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username) return user;
            }
            return null;
        }
        public void SaveUser()
        {
            Mgrpersistance.SaveUser(Users);
        }
    }
}
