using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Model
{
    /// <summary>
    /// Classe responsable de la gestion des jeux et des utilisateurs.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Le type de persistance utilisé par le gestionnaire.
        /// </summary>
        public readonly IPersistance mgrpersistance;

        /// <summary>
        /// La liste des jeux disponibles.
        /// </summary>
        public ReadOnlyCollection<Game> GameList => gameList.AsReadOnly();
        private readonly List<Game> gameList;

        /// <summary>
        /// Le jeu sélectionné actuellement.
        /// </summary>
        public Game? SelectedGame { get; set; }

        /// <summary>
        /// L'utilisateur actuellement connecté.
        /// </summary>
        public User? CurrentUser { get; set; }

        /// <summary>
        /// La liste des utilisateurs enregistrés.
        /// </summary>
        public HashSet<User> Users { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Manager"/> avec un objet de persistance spécifié.
        /// </summary>
        /// <param name="persistance">Le type de persistance utilisé pour charger/sauvegarder les jeux et les utilisateurs.</param>
        public Manager(IPersistance persistance)
        {
            mgrpersistance = persistance;
            gameList = persistance.LoadGame();
            Users = persistance.LoadUser();
        }

        /// <summary>
        /// Filtre les jeux en fonction des critères de filtrage donnés.
        /// </summary>
        /// <param name="filterName">Nom du jeu à filtrer.</param>
        /// <param name="filterTag1">Première étiquette à filtrer.</param>
        /// <param name="filterTag2">Deuxième étiquette à filtrer.</param>
        /// <returns>Une liste de jeux filtrée.</returns>
        public IEnumerable<Game> FilterGames(string? filterName, string? filterTag1, string? filterTag2)
        {
            IEnumerable<Game> retList;
            retList = gameList;
            if (filterName != null) retList = retList
                .Where(game => game.Name.Contains(filterName, StringComparison.OrdinalIgnoreCase)
                );
            if (filterTag1 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.Contains(filterTag1, StringComparison.OrdinalIgnoreCase))
                );
            if (filterTag2 != null) retList = retList
                .Where(game => game.Tags != null && game.Tags.Any(tag => tag != null && tag.Contains(filterTag2, StringComparison.OrdinalIgnoreCase))
                );
            return retList;
        }

        /// <summary>
        /// Ajoute un jeu à la liste des jeux.
        /// </summary>
        /// <param name="game">Le jeu à ajouter.</param>
        public void AddGametoGamesList(Game game)
        {
            if (!gameList.Contains(game)) gameList.Add(game);
            mgrpersistance.SaveGame(gameList);
        }

        /// <summary>
        /// Ajoute un utilisateur à la liste des utilisateurs.
        /// </summary>
        /// <param name="user">L'utilisateur à ajouter.</param>
        public void AddUsertoUserList(User user)
        {
            if (!Users.Contains(user)) Users.Add(user);
            mgrpersistance.SaveUser(Users);
        }

        /// <summary>
        /// Supprime un jeu de la liste des jeux.
        /// </summary>
        /// <param name="game">Le jeu à supprimer.</param>
        public void RemoveGameFromGamesList(Game game)
        {
            SelectedGame = null;
            gameList.Remove(game);
            mgrpersistance.SaveGame(gameList);
        }

        /// <summary>
        /// Sauvegarde les jeux.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void SaveGames()
        {
            mgrpersistance.SaveGame(gameList);
        }

        /// <summary>
        /// Recherche un utilisateur par son nom d'utilisateur.
        /// </summary>
        /// <param name="username">Le nom d'utilisateur à rechercher.</param>
        /// <returns>L'utilisateur correspondant, ou null s'il n'est pas trouvé.</returns>
        public User? SearchUser(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username) return user;
            }
            return null;
        }

        /// <summary>
        /// Sauvegarde les utilisateurs.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void SaveUser()
        {
            mgrpersistance.SaveUser(Users);
        }

        /// <summary>
        /// Met à jour les références des jeux suivis par l'utilisateur actuel.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void UpdateReferences()
        {
            if (CurrentUser != null && CurrentUser.Followed_Games.Count != 0)
            {
                foreach (var game in CurrentUser.Followed_Games.ToList())
                {
                    CurrentUser.RemoveAGame(game);
                    if (GameList.Contains(game)) CurrentUser.FollowAGame(gameList.Where(g => g.Name == game.Name).First());
                }
            }
            SaveUser();
        }
    }
}
