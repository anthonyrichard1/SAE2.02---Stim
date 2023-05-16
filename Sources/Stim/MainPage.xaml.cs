namespace Stim;
using Model;
using StimPersistance;

public partial class MainPage : ContentPage
{
    public IPersistance persistance = new Persistance();
    public Manager Manager;

	public MainPage()
	{
		InitializeComponent();
        Manager = new(persistance);
        BindingContext = Manager;
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
