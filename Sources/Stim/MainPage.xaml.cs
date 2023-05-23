namespace Stim;
using Model;
using StimPersistance;
using StimStub;

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
}
