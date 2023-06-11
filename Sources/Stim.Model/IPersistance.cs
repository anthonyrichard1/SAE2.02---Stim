namespace Model
{
    /// <summary>
    /// Interface pour la persistance des données.
    /// </summary>
    public interface IPersistance
    {
        /// <summary>
        /// Sauvegarde la liste des jeux.
        /// </summary>
        /// <param name="games">La liste des jeux à sauvegarder.</param>
        public void SaveGame(List<Game> games);

        /// <summary>
        /// Sauvegarde la liste des utilisateurs.
        /// </summary>
        /// <param name="users">La liste des utilisateurs à sauvegarder.</param>
        public void SaveUser(HashSet<User> users);

        /// <summary>
        /// Charge la liste des jeux.
        /// </summary>
        /// <returns>La liste des jeux chargée.</returns>
        public List<Game> LoadGame();

        /// <summary>
        /// Charge la liste des utilisateurs.
        /// </summary>
        /// <returns>La liste des utilisateurs chargée.</returns>
        public HashSet<User> LoadUser();
    }
}