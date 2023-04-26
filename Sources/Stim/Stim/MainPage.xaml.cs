namespace Stim;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new DetailledPage());
    }

    private async void goToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
