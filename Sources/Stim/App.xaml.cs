using Model;
using StimPersistance;
using StimStub;
using System.Diagnostics;

namespace Stim;

public partial class App : Application
{
    public Manager Manager { get; set; }

    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage());
        Manager = new(new Persistance(FileSystem.Current.AppDataDirectory));
        if (!File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "games.xml"))) FirstStart();
    }

    private void FirstStart()
    {
        Manager mgrtmp = new(new Stub());
        foreach (var game in mgrtmp.GameList) Manager.AddGametoGamesList(game);
    }
}
