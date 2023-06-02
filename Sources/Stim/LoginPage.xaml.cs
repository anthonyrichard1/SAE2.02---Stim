//using Microsoft.UI.Xaml.Navigation;
using Model;

namespace Stim;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Se_connecter(object sender, EventArgs e)
    {
		if (!string.IsNullOrWhiteSpace(Username.Text) || !string.IsNullOrWhiteSpace(Pswd.Text))
		{
			User user = ((App)App.Current).Manager.SearchUser(Username.Text);
			if (user != null)
			{
				if (user.Password == Pswd.Text)
				{
					((App)App.Current).Manager.CurrentUser = user;
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//MainPage");
                }

                else throw new NotImplementedException();
			}
			else
			{
				throw new NotImplementedException();
			}
		}
    }

    private async void Creer_un_compte(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}