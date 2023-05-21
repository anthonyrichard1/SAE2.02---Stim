using Model;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;

namespace StimStub
{
    public class Stub : IPersistance
    {
        public Stub()
        {
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "..//..//..//..//XML//"));
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

        }

        public ObservableCollection<Game> LoadGame()
        {
            DataContractSerializer serializer = new(typeof(ObservableCollection<Game>));
            using (Stream stream = File.OpenRead("games.xml")) return serializer.ReadObject(stream) as ObservableCollection<Game>;
        }

        public List<User> LoadUser()
        {
            return null;
        }
    }
}