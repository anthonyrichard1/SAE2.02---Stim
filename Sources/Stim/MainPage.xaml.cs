namespace Stim;
using Model;
using StimPersistance;
using StimStub;
using Microsoft.Maui.Storage;
using Windows.System;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = ((App)App.Current).Manager;
    }

    private async void OnClickGameList(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new DetailledPage((sender as CollectionView).SelectedItem as Game));
    }

    private async void GoToAddGamePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddGamePage());
    }
}
