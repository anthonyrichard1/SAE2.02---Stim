namespace Stim;
using Model;
using StimPersistance;
using StimStub;
using Microsoft.Maui.Storage;

public partial class MainPage : ContentPage
{

    public IPersistance persistance = new Persistance(FileSystem.Current.AppDataDirectory);
    public Manager Manager { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Manager = new(persistance);
        BindingContext = Manager;
    }

    private async void OnClickGameList(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new DetailledPage((sender as CollectionView).SelectedItem as Game));
    }

    private async void GoToAddGamePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddGamePage(Manager));
    }
}
