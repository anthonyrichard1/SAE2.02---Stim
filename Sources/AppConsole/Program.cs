using Model;
using StimPersistance;
using StimStub;
using System.Collections.ObjectModel;

Manager stub = new(new Stub());
Manager persistance = new(new Persistance("../../../../"));
persistance._persistance.SaveGame(stub.GameList);