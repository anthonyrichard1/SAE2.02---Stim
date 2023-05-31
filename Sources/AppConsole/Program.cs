using Model;
using StimPersistance;
using StimStub;
using System.Diagnostics.CodeAnalysis;

namespace AppConsole
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Manager stub = new(new Stub());
            Manager persistance = new(new Persistance("../../../../"));
            persistance.Mgrpersistance.SaveGame(stub.GameList);
        }
    }
}