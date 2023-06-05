﻿using Model;
using StimStub;
using System.Diagnostics.CodeAnalysis;

namespace AppConsole
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        private static Manager Manager { get; set; } = new(new Stub());        
        private static string? choixstr;
        private static int choixint;

        public static void Main(string[] args)
        {
            while (choixint != 99)
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
                "10-Supprimer jeu suivis\n" +
                "99-Quitter");

                choixstr = Console.ReadLine();
                choixint = 0;

                if (int.TryParse(choixstr, out choixint)) switch (choixint)
                    {
                        case 1:
                            Console.WriteLine("Nom du jeu : ");
                            string? name = Console.ReadLine();
                            Console.WriteLine("Description du jeu : ");
                            string? description = Console.ReadLine();
                            string? year = "";
                            int yearint = 0;

                            while (!int.TryParse(year, out yearint))
                            {
                                Console.WriteLine("Année du jeu : ");
                                year = Console.ReadLine();
                            }

                            Console.WriteLine("Tag 1 du jeu : ");
                            string? tag1 = Console.ReadLine();
                            Console.WriteLine("Tag 2 du jeu : ");
                            string? tag2 = Console.ReadLine();
                            Console.WriteLine("Tag 3 du jeu : ");
                            string? tag3 = Console.ReadLine();
                            Console.WriteLine("Cover du jeu : ");
                            string? cover = Console.ReadLine();
                            Console.WriteLine("Lien boutique du jeu : ");
                            string? lien = Console.ReadLine();
                            Game game = new(name, description, yearint, new List<string> { tag1, tag2, tag3 }, cover, lien);
                            Manager.AddGametoGamesList(game);
                            Console.WriteLine("Jeu suivant ajouté : " + game.Name);
                            break;

                        case 2:
                            Console.WriteLine("Nom du jeu : ");
                            string? name2 = Console.ReadLine();
                            bool find = false;
                            foreach (Game g in Manager.GameList) if (g.Name == name2)
                                {
                                    Manager.RemoveGameFromGamesList(g);
                                    Console.WriteLine("Jeu suivant supprimé : " + g.Name);
                                    find = true;
                                    break;
                                }
                            if (!find) Console.WriteLine("Jeu suivant introuvable : " + name2);
                            break;

                        case 3:
                            AfficherJeux();
                            break;

                        case 4:
                            Console.WriteLine("Nom de l'utilisateur : ");
                            string? username = Console.ReadLine();
                            Console.WriteLine("Image de l'utilisateur : ");
                            string? image = Console.ReadLine();
                            Console.WriteLine("Biographie de l'utilisateur : ");
                            string? biographie = Console.ReadLine();
                            Console.WriteLine("Email de l'utilisateur : ");
                            string? email = Console.ReadLine();
                            Console.WriteLine("Password de l'utilisateur : ");
                            string? password = Console.ReadLine();
                            User user = new(image, username, biographie, email, password);
                            Manager.AddUsertoUserList(user);
                            Console.WriteLine("Utilisateur suivant ajouté : " + user.Username);
                            break;

                        case 5:
                            AfficherUsers();
                            break;

                        case 6:
                            Console.WriteLine("Nom du jeu : ");
                            string? name3 = Console.ReadLine();
                            bool find2 = false;
                            foreach (Game g in Manager.GameList) if (g.Name == name3) foreach (Review rev in g.Reviews)
                                    {
                                        Console.WriteLine(rev);
                                        find2 = true;
                                        break;
                                    }
                            if (!find2) Console.WriteLine("Jeu suivant introuvable : " + name3);     
                            break;

                        case 7:
                            Console.WriteLine("Nom du jeu : ");
                            string? name4 = Console.ReadLine();
                            bool find3 = false;
                            foreach (Game g in Manager.GameList) if (g.Name == name4)
                                    {
                                    Console.WriteLine("Votre nom d'utilisateur : ");
                                    string? username2 = Console.ReadLine();
                                    int rateint;
                                    string? ratestr = "";
                                    while (!int.TryParse(ratestr, out rateint)) ratestr = Console.ReadLine();
                                    Console.WriteLine("Votre commentaire : ");
                                    string? revstr = Console.ReadLine();
                                    Review rev = new(username2, rateint, revstr);
                                    g.AddReview(rev);
                                    Console.WriteLine("Commentaire ajouté !");
                                    find2 = true;
                                    break;
                                    }
                            if (!find3) Console.WriteLine("Jeu suivant introuvable : " + name4);
                            break;

                        case 8:
                            Console.WriteLine("Nom du jeu : ");
                            string? name5 = Console.ReadLine();
                            bool find4 = false;
                            foreach (Game g in Manager.GameList) if (g.Name == name5)
                                {
                                    Console.WriteLine("Votre nom d'utilisateur : ");
                                    string? username2 = Console.ReadLine();
                                    //foreach (Review rev in g.Reviews) if (rev.AuthorName)
                                }
                                break;

                        case 9:
                            break;

                        case 10:
                            break;

                        default:
                            break;

                    }
            }
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