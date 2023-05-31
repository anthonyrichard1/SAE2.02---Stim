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
        public Persistance(string chemin)
        {
            Directory.SetCurrentDirectory(chemin);
        }

        public void SaveGame(ObservableCollection<Game> games)
        {
            XmlWriterSettings settings = new() { Indent = true };
            DataContractSerializer serializer = new(typeof(ObservableCollection<Game>));

            using (TextWriter tw = File.CreateText("games.xml"))
            using (XmlWriter writer = XmlWriter.Create(tw, settings)) serializer.WriteObject(writer, games);
        }

        public void SaveUser(List<User> users)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Game> LoadGame()
        {
            if (File.Exists("games.xml"))
            {
                DataContractSerializer serializer = new(typeof(ObservableCollection<Game>));
                using (Stream stream = File.OpenRead("games.xml")) return serializer.ReadObject(stream) as ObservableCollection<Game>;
            }
            return new();
        }

        public List<User> LoadUser()
        {
            throw new NotImplementedException();
        }        
    }
}