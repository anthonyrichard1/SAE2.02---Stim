using Model;
using StimPersistance;
using StimStub;

namespace Stim;

public partial class App : Application
{
    public Manager Manager { get; set; }
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "games.xml"))) Manager = new Manager(new Persistance(FileSystem.Current.AppDataDirectory));
        else Manager = new(new Stub());
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Stopped += (s, e) =>
        {
            Manager._persistance = new Persistance(FileSystem.Current.AppDataDirectory);
            var test = Manager;
            Manager.SaveGames();
        };

        return window;
    } 
}
