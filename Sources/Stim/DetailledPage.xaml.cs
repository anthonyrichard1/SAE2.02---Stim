namespace Stim;

public partial class DetailledPage : ContentPage
{
	public DetailledPage()
	{
		InitializeComponent();
	}
    private async void goToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}