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
        Manager = new(new Stub());
    }
}
