namespace Stim;

public partial class HeaderView : ContentView
{
	public HeaderView()
	{
		InitializeComponent();
	}
    private async void goToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
    private async void goToFollowPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new FollowPage());
    }
    private async void goToProfilPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }
}