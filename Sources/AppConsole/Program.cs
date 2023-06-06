using Model;
using StimStub;
using System.Diagnostics.CodeAnalysis;

namespace AppConsole
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        private static Manager Manager { get; set; } = new(new Stub());

        public static void Main(string[] args)
        {
            Game game = new("Jeu sans nom", "C'est un jeu", 1980, new List<string> { "aventure", "multijoueur", "combat" }, "no_cover.png", "boutiqueEnLigne.fr");
            User user = new("moi.png", "Moi", "Il s'agit de moi-même car je suis cette personne", "moi.moi@moi.com", "123456abcdef**");
            Console.WriteLine("-----TEST FONCTIONNELS-----");
            Console.WriteLine("-----AJOUTER UN JEU-----");
            Console.WriteLine("nom = Jeu Sans Nom, description = C'est un jeu, année = 1980, tags = aventure-combat-multijoueur, lien = boutiqueEnLigne.fr");
            Manager.AddGametoGamesList(game);
            Console.WriteLine("résultat : ");
            AfficherJeux();

            Console.WriteLine("-----SUPPRIMER UN JEU-----");
            Console.WriteLine("nom = Jeu Sans Nom, description = C'est un jeu, année = 1980, tags = aventure-combat-multijoueur, lien = boutiqueEnLigne.fr");
            Manager.RemoveGameFromGamesList(game);
            Console.WriteLine("Résultat : ");
            AfficherJeux();

            Console.WriteLine("-----AJOUTER UN UTILISATEUR-----");
            Console.WriteLine("nom d'utilisateur = Moi, biographie = Il s'agit de moi-même car je suis cette personne, photo = moi.png, email = moi.moi@moi.com, mot de passe = 123456abcdef**");
            Manager.AddUsertoUserList(user);
            AfficherUsers();

            Console.WriteLine("-----AJOUTER UN COMMENTAIRE SUR UN JEU-----");
            Console.WriteLine("jeu = GTA V, auteur = Moi, message = Ce jeu est vraiment très bien !, note = 1.3");
            Manager.GameList[3].AddReview(new("Moi", 1.3f, "Ce jeu est vraiment très bien !"));
            Console.WriteLine(Manager.GameList[3]);

            Console.WriteLine("-----SUPPRIMER UN COMMENTAIRE SUR UN JEU-----");
            Console.WriteLine("jeu = GTA V, auteur = Moi, message = Ce jeu est vraiment très bien !, note = 1.3");
            user.RemoveSelfReview(Manager.GameList[3], 1.3f, "Ce jeu est vraiment très bien !");
            Console.WriteLine(Manager.GameList[3]);

            Console.WriteLine("-----AJOUTER UN JEU AUX SUIVIS-----");
            Console.WriteLine("jeux = Elden ring");
            user.FollowAGame(Manager.GameList[0]);
            Console.WriteLine(user);

            Console.WriteLine("-----SUPPRIMER UN JEU DES SUIVIS-----");
            Console.WriteLine("jeux = Elden ring");
            user.RemoveAGame(Manager.GameList[0]);
            Console.WriteLine(user);

        }

        private static void AfficherJeux()
        {
            foreach (Game game in Manager.GameList) Console.WriteLine(game);
        }

        private static void AfficherUsers()
        {
            foreach (User user in Manager.Users) Console.WriteLine(user);
        }
    }
}