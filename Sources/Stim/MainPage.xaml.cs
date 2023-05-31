namespace Stim;
using Model;
using StimPersistance;
using StimStub;
using Microsoft.Maui.Storage;
using MailKit.Search;
using System.Linq;

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

    private void SearchBar_GameChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        string GameText = Game.Text;
        string Tag1Text = Tag1.Text;
        string Tag2Text = Tag2.Text;
        ((App)App.Current).Manager.ResearchedGame.Clear();
        var filteredGames = ((App)App.Current).Manager.GameList;
        if (Game != null)
        {
            filteredGames = ((App)App.Current).Manager.GameList
            .Where(game => game.Name.IndexOf(GameText, StringComparison.OrdinalIgnoreCase) >= 0
            &&
            game.Tags.Any(tag => tag.IndexOf(Tag1Text, StringComparison.OrdinalIgnoreCase) >= 0)
            &&
            game.Tags.Any(tag => tag.IndexOf(Tag2Text, StringComparison.OrdinalIgnoreCase) >= 0)
            );
        }
        if (filteredGames ==null)
        {
            filteredGames = ((App)App.Current).Manager.GameList;
        }

        foreach (var game in filteredGames)
        {
            ((App)App.Current).Manager.ResearchedGame.Add(game);
        }
    }
}
