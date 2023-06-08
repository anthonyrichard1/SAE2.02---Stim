using CommunityToolkit.Maui.Views;
using Model;

namespace Stim;

public partial class DetailledPage : ContentPage
{
	public DetailledPage()
	{
		InitializeComponent();
        BindingContext = (App.Current as App).Manager.SelectedGame;
        if ((App.Current as App).Manager.SelectedGame is null) Navigation.RemovePage(this);
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void AddReview(object sender, EventArgs e)
    {
        await this.ShowPopupAsync(new ReviewPopUp((App.Current as App).Manager.SelectedGame));
    }

    private async void AddFollow(object sender, EventArgs e)
    {
        bool flag = false;
        foreach (Game game in ((App)App.Current).Manager.CurrentUser.Followed_Games)
        {
            if (game == null) throw new Exception();
            else if ((App.Current as App).Manager.SelectedGame == game) { flag = true; break; }
        }
        if (!flag)
        {
            await this.ShowPopupAsync(new MessagePopup("Jeu ajout� dans les suivis !"));
            ((App)App.Current).Manager.CurrentUser.FollowAGame((App.Current as App).Manager.SelectedGame);
        }
        else
        {
            await this.ShowPopupAsync(new MessagePopup("Jeu d�j� suivis !"));
        } 
    }

    private async void RemoveGame(object sender, EventArgs e)
    {
        var res = await this.ShowPopupAsync(new ConfirmationPopup("Voulez-vous vraiment supprimer " + (App.Current as App).Manager.SelectedGame.Name + " ?"));
        if (res != null && res is bool && (bool)res)
        {
            (App.Current as App).Manager.RemoveGameFromGamesList((App.Current as App).Manager.SelectedGame);
            await Navigation.PopAsync();
            await this.ShowPopupAsync(new MessagePopup("Jeu supprim� !"));
        }
    }
}