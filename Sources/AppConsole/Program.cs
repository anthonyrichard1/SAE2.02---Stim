using Model;
using StimPersistance;
using StimStub;
using System.Collections.ObjectModel;

Console.WriteLine("Faut une ligne pour build");
Manager Mgr = new Manager(new Stub());
Mgr._persistance = new Persistance();
Mgr.SaveGames();