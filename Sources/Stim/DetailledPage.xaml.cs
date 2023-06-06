using CommunityToolkit.Maui.Views;
using Model;
using StimPersistance;

namespace Stim;

public partial class DetailledPage : ContentPage
{
    private Game currentGame;

	public DetailledPage()
	{
		InitializeComponent();
        currentGame = (App.Current as App).Manager.SelectedGame;
        BindingContext = currentGame;

        if (currentGame is null) Navigation.PopAsync();
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void AddReview(object sender, EventArgs e)
    {
        //popup add review
    }

    private async void AddFollow(object sender, EventArgs e)
    {
        bool flag = false;
        foreach (Game game in ((App)App.Current).Manager.CurrentUser.Followed_Games)
        {
            if (game == null) throw new Exception();
            else if (currentGame == game) { flag = true; break; }
        }
        if (!flag)
        {
            await this.ShowPopupAsync(new MessagePopup("Jeu ajouté dans les suivis !"));
            ((App)App.Current).Manager.CurrentUser.FollowAGame(currentGame);
        }
        else
        {
            await this.ShowPopupAsync(new MessagePopup("Jeu déjà suivis !"));
        } 
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        Navigation.PopAsync();
        base.OnNavigatedFrom(args);
    }

    protected override void OnDisappearing()
    {
        Navigation.PopAsync();
        base.OnDisappearing();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}