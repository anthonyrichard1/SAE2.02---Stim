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
		await Navigation.PushAsync(new DetailledPage((sender as CollectionView).SelectedItem as Game));
	}
}