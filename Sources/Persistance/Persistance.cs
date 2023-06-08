using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Model;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace StimPersistance
{
    [ExcludeFromCodeCoverage]
    public class Persistance : IPersistance
    {
        private const string gameFileName = "games.xml";
        private const string userFileName = "users.xml";
        private readonly string fullGamePath;
        private readonly string fullUserPath;

        public Persistance(string path)
        {
            fullGamePath = Path.Combine(path, gameFileName);
            fullUserPath = Path.Combine(path, userFileName);
        }

        public void SaveGame(List<Game> games)
        {
            XmlWriterSettings settings = new() { Indent = true };
            DataContractSerializer serializer = new(typeof(List<Game>));

            using (TextWriter tw = File.CreateText(fullGamePath))
            using (XmlWriter writer = XmlWriter.Create(tw, settings)) serializer.WriteObject(writer, games);
        }

        public void SaveUser(HashSet<User> users)
        {
            XmlWriterSettings settings = new() { Indent = true };
            DataContractSerializer serializer = new(typeof(HashSet<User>));

            using (TextWriter tw = File.CreateText(fullUserPath))
            using (XmlWriter writer = XmlWriter.Create(tw, settings)) serializer.WriteObject(writer, users);
        }

        public List<Game> LoadGame()
        {
            if (File.Exists(fullGamePath))
            {
                DataContractSerializer serializer = new(typeof(List<Game>));
                using (Stream stream = File.OpenRead(fullGamePath)) return serializer.ReadObject(stream) as List<Game> ?? new();
            }
            return new();
        }

        public HashSet<User> LoadUser()
        {
            if (File.Exists(fullUserPath))
            {
                DataContractSerializer serializer = new(typeof(HashSet<User>));
                using (Stream stream = File.OpenRead(fullUserPath)) return serializer.ReadObject(stream) as HashSet<User> ?? new();
            }
            return new();
        }        
    }
}