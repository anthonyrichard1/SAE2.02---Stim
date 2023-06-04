using CommunityToolkit.Maui.Views;
using Model;

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
    }

    private async void ChangeUsername(object sender, EventArgs e)
    {
        var newName = await this.ShowPopupAsync(new EntryPopup("Username"));
        if (string.IsNullOrWhiteSpace(newName as string)) await this.ShowPopupAsync(new MessagePopup("Nom d'utilisateur invalide"));
        else ((App)App.Current).Manager.CurrentUser.Username = (newName as string);
    }
}