using CommunityToolkit.Maui.Views;
using Model;

namespace Stim;

public partial class DetailledPage : ContentPage
{
	public DetailledPage()
	{
		InitializeComponent();
        if ((App.Current as App).Manager.SelectedGame is null) Navigation.RemovePage(this);
        BindingContext = (App.Current as App).Manager.SelectedGame;        
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void AddReview(object sender, EventArgs e)
    {
        var res = await this.ShowPopupAsync(new ReviewPopUp());
        if (res != null && res is int i && i == 1) await this.ShowPopupAsync(new MessagePopup("Commentaire ajouté !"));
    }

    private async void EditReview(object sender, EventArgs e)
    {
        var res = await this.ShowPopupAsync(new ReviewPopUp((sender as ImageButton).BindingContext as Review));
        if (res != null && res is int i && i == 2) await this.ShowPopupAsync(new MessagePopup("Commentaire modifié !"));
    }
        

    private async void RemoveReview(object sender, EventArgs e)
    {
        if (((sender as ImageButton).BindingContext as Review).AuthorName == ((App)App.Current).Manager.CurrentUser.Username)
        {
            var res = await this.ShowPopupAsync(new ConfirmationPopup("Voulez-vous vraiment supprimer votre commentaire ?"));
            if (res != null && res is bool v && v)
            {
                (App.Current as App).Manager.SelectedGame.RemoveReview((sender as ImageButton).BindingContext as Review);
                (App.Current as App).Manager.SaveGames();
                await this.ShowPopupAsync(new MessagePopup("Commentaire supprimé !"));
            }
        }
        else await this.ShowPopupAsync(new MessagePopup("Ce commentaire ne vous appartiens pas"));
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
            await this.ShowPopupAsync(new MessagePopup("Jeu ajouté dans les suivis !"));
            ((App)App.Current).Manager.CurrentUser.FollowAGame((App.Current as App).Manager.SelectedGame);
            ((App)App.Current).Manager.SaveUser();
        }
        else
        {
            await this.ShowPopupAsync(new MessagePopup("Jeu déjà suivis !"));
        } 
    }

    private async void RemoveGame(object sender, EventArgs e)
    {
        var res = await this.ShowPopupAsync(new ConfirmationPopup("Voulez-vous vraiment supprimer " + (App.Current as App).Manager.SelectedGame.Name + " ?"));
        if (res != null && res is bool && (bool)res)
        {
            (App.Current as App).Manager.RemoveGameFromGamesList((App.Current as App).Manager.SelectedGame);
            await Navigation.PopAsync();
            await this.ShowPopupAsync(new MessagePopup("Jeu supprimé !"));
        }
    }
}