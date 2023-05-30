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
}