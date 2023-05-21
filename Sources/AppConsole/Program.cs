using Model;
using StimPersistance;
using StimStub;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            games.Add(new("Elden Ring", "description", 2010, new List<string> { "1", "2", "3" }, "elden_ring.jpg"));
            games[0].AddReview(new(5, "C'est trop bien"));
            games[0].AddReview(new(3.5f, "C'est bien"));
            games[0].AddReview(new(1.5f, "C'est pas bien"));
            games[0].AddReview(new(4, "C'est trop bien"));
            games[0].AddReview(new(3f, "C'est bien"));
            games[0].AddReview(new(2.5f, "C'est pas bien"));
            games.Add(new("Minecraft", "description", 2010, new List<string> { "1", "2", "3" }, "minecraft.jpeg"));
            games.Add(new("Celeste", "description", 2010, new List<string> { "1", "2" }, "celeste.png"));
            games.Add(new("GTA V", "description", 2010, new List<string> { "1", "2", "3" }, "gta_v.png"));

            IPersistance stub = new Stub();

            stub.SaveGame(games);
        }
    }
}
