using Microsoft.VisualBasic;
using Model;
using StimPersistance;
using StimStub;
using System.Diagnostics.CodeAnalysis;

namespace AppConsole
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main(string[] args)
        {
            Program.Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("-----MENU PRINCIPAL-----\n" +
                "1-Ajouter un jeu\n" +
                "2-Supprimer un jeu\n" +
                "3-Afficher les jeux\n" +
                "4-Ajouter un utilisateur\n" +
                "5-Afficher les utilisateur\n" +
                "6-Afficher les commentaires d'un jeu\n" +
                "7-Ajouter un commentaire\n" +
                "8-Supprimer un commentaire\n" +
                "9-Ajouter jeu suivis\n" +
                "10-Supprimer jeu suivis\n");
        }
    }
}