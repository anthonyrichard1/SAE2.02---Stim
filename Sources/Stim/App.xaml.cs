using Model;
using StimPersistance;
using StimStub;

namespace Stim;

public partial class App : Application
{
	Manager Mgr
	{
		get; set;
	}
	public App()
	{
		InitializeComponent();
        string mainDir = FileSystem.Current.AppDataDirectory;
        if (File.Exists(Path.Combine(mainDir,"games.xml"))) Mgr = new Manager(new Persistance(mainDir));
        else Mgr = new Manager(new Stub());
		MainPage = new AppShell();
	}
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Stopped += (s, e) =>
        {
            Mgr._persistance = new Persistance(FileSystem.Current.AppDataDirectory);
            Mgr.SaveGames();
        };

        return window;
    }
}
