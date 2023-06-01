using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public IPersistance Mgrpersistance;
        public ObservableCollection<Game> GameList { get;}
        public ObservableCollection<Game> ResearchedGame { get; set; }
        public User CurrentUser { get; set; }
        public List<User> Users { get; set; }

        public Manager(IPersistance persistance)
        {
            Mgrpersistance = persistance;
            CurrentUser = new User(null,"username", "je suis née .... maintenat je fini à 19h30 à cause de l'IHM. GHGHTFCDXEFTGHYJKIJHNGFVCREDTGHNJIKJUHNYGVTFCREDZTGYHUNJIKJUHNYTGVFCREDRTYHUJIOUJNHYGVFRCCFTGYHUJIUJNHYTGBVCFDRRTGYHUI", "email@email.com", "password88");
            GameList = persistance.LoadGame();
            ResearchedGame = persistance.LoadGame();
            Users = persistance.LoadUser();
            if (GameList == null) { GameList = new ObservableCollection<Game>();}
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
