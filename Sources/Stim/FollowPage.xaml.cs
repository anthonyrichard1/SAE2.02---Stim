using Model;

namespace Stim;

public partial class FollowPage : ContentPage
{
	public FollowPage()
	{
		InitializeComponent();
		BindingContext = (App.Current as App).Manager.CurrentUser;
	}

	public async void GoToDetail(object sender, EventArgs e)
	{
		(App.Current as App).Manager.SelectedGame = (sender as CollectionView).SelectedItem as Game;
		await Navigation.PushAsync(new DetailledPage());
	}
}