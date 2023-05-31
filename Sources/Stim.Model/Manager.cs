using System.Collections.ObjectModel;

namespace Model
{
    public class Manager
    {
        public IPersistance Mgrpersistance;
        public ObservableCollection<Game> GameList { get;}
        public ObservableCollection<Game> ResearchedGame { get; set; }
        public User CurrentUser { get; set; }

        public Manager(IPersistance persistance)
        {
            Mgrpersistance = persistance;
            CurrentUser = new User(null,"username", "je suis née .... maintenat je fini à 19h30 à cause de l'IHM. GHGHTFCDXEFTGHYJKIJHNGFVCREDTGHNJIKJUHNYGVTFCREDZTGYHUNJIKJUHNYTGVFCREDRTYHUJIOUJNHYGVFRCCFTGYHUJIUJNHYTGBVCFDRRTGYHUI", "email@email.com", "password88");
            GameList = persistance.LoadGame();
            ResearchedGame = persistance.LoadGame();
            if (GameList == null) { GameList = new ObservableCollection<Game>();}
        }

        public void AddGametoGamesList(Game game)
        {
            GameList.Add(game);
            Mgrpersistance.SaveGame(GameList);
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
    }
}
