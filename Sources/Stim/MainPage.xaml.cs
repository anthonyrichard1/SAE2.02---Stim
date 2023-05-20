namespace Stim;
using Model;
using StimPersistance;

public partial class MainPage : ContentPage
{
    public IPersistance persistance = new Persistance();
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

    private async void goToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
