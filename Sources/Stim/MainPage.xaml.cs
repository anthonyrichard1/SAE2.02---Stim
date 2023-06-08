namespace Stim;
using Model;
using StimPersistance;
using StimStub;
using Microsoft.Maui.Storage;
using MailKit.Search;
using System.Linq;
using System.Collections.Generic;

public partial class MainPage : ContentPage
{
    public IEnumerable<Game> filterdGame { get;  private set; }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = ((App)App.Current).Manager.FilterGames(null,null,null);
    }

    private async void OnClickGameList(object sender, EventArgs e)
    {
       (App.Current as App).Manager.SelectedGame = (sender as CollectionView).SelectedItem as Game;
       await Navigation.PushAsync(new DetailledPage());
    }

    private async void Addgame(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddGamePage());
    }

    private void SearchBar_GameChanged(object sender, TextChangedEventArgs e)
    {
        string GameText = Game.Text;
        string Tag1Text = Tag1.Text;
        string Tag2Text = Tag2.Text;

        BindingContext=((App)App.Current).Manager.FilterGames(GameText, Tag1Text, Tag2Text);
    }
    protected override void OnAppearing()
    {
        SearchBar_GameChanged(null,null);
        base.OnAppearing();
    }
}
