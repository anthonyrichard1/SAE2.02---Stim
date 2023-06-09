using CommunityToolkit.Maui.Views;
using Model;
using System.Text.RegularExpressions;

namespace Stim;

public partial class ProfilPage : ContentPage
{
    public ProfilPage()
    {
        InitializeComponent();
        BindingContext = ((App)App.Current).Manager;
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ((App)App.Current).Manager.CurrentUser.RemoveAGame((sender as CollectionView).SelectedItem as Game);
        ((App)App.Current).Manager.SaveUser();
    }

    private async void ChangeUsername(object sender, EventArgs e)
    {
        var newName = await this.ShowPopupAsync(new EntryPopup("Username"));
        if (string.IsNullOrWhiteSpace(newName as string)) await this.ShowPopupAsync(new MessagePopup("Nom d'utilisateur invalide"));
        else ((App)App.Current).Manager.CurrentUser.Username = (newName as string);
    }
    public async void PopUpUsername(object sender, EventArgs e)
    {
        var newName = await this.ShowPopupAsync(new EntryPopup("Username"));
        if (string.IsNullOrWhiteSpace(newName as string)) await this.ShowPopupAsync(new MessagePopup("Nom d'utilisateur invalide"));
        else ((App)App.Current).Manager.CurrentUser.Username = (newName as string);
    }
    public async void PopUpBio(object sender, EventArgs e)
    {
        var newBio = await this.ShowPopupAsync(new EntryPopup("Biographie"));
        ((App)App.Current).Manager.CurrentUser.Biographie = (newBio as string);
    }
    public async void PopUpPswd(object sender, EventArgs e)
    {
        Regex rg = new Regex("^(?=.*[A-Za-z])(?=.*[0-9@$!%*#?&])[A-Za-z-0-9@$!%*#?&]{8,}$");
        var newPswd = await this.ShowPopupAsync(new EntryPopup("Password"));
        if (string.IsNullOrWhiteSpace(newPswd as string) || rg.IsMatch(newPswd as string)) await this.ShowPopupAsync(new MessagePopup("Nom d'utilisateur invalide"));
        else ((App)App.Current).Manager.CurrentUser.Password = (newPswd as string);
    }
    public async void PopUpEmail(object sender, EventArgs e)
    {
        Regex rg = new Regex("^([a-zA-Z0-9_-]+[.])*[a-zA-Z0-9_-]+@([a-zA-Z0-9_-]+[.])+[a-zA-Z0-9_-]{2,4}$");
        var newMail = await this.ShowPopupAsync(new EntryPopup("Email"));
        if (string.IsNullOrWhiteSpace(newMail as string) || rg.IsMatch(newMail as string)) await this.ShowPopupAsync(new MessagePopup("Email Invalide"));
        else ((App)App.Current).Manager.CurrentUser.Email = (newMail as string);
    }
}