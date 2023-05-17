using Model;

namespace Stim;

public partial class DetailledPage : ContentPage
{
	public DetailledPage(Game game)
	{
		InitializeComponent();
        BindingContext = game;
	}
    private async void goToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}