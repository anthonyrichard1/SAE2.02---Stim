using Model;
using StimPersistance;

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
        Mgr = new Manager(new Persistance(mainDir));
		MainPage = new AppShell();
	}
}
