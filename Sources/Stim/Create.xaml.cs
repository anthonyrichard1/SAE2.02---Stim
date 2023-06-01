using System.Text.RegularExpressions;

namespace Stim;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}
    private async void Creer_un_compte(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Username.Text) || !string.IsNullOrWhiteSpace(Pswd.Text) || !string.IsNullOrWhiteSpace(Email.Text))
        {
            if (((App)App.Current).Manager.SearchUser(Username.Text) == null)
            {
                Regex rg = new Regex("^(?=.*[A-Za-z])(?=.*[0-9@$!%*#?&])[A-Za-z-0-9@$!%*#?&]{8,}$");
                if (rg.IsMatch(Pswd.Text))
                {
                    ((App)App.Current).Manager.AddUsertoUserList(new("", Username.Text, "", Email.Text, Pswd.Text));
                    ((App)App.Current).Manager.CurrentUser = ((App)App.Current).Manager.SearchUser(Username.Text);
                    await Navigation.PushAsync(new MainPage());
                }
                else throw new NotImplementedException();
            }
            else throw new NotImplementedException();
        }
    }
    private async void Se_connecter(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}