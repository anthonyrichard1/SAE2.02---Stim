//using Microsoft.UI.Xaml.Navigation;
using Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stim;
public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Se_connecter(object sender, EventArgs e)
    {
        Error.Clear();
        if (!string.IsNullOrWhiteSpace(Username.Text) || !string.IsNullOrWhiteSpace(Pswd.Text))
		{
			User user = ((App)App.Current).Manager.SearchUser(Username.Text);
            if (user != null)
            {
                if (user.Password == Pswd.Text)
                {
                    ((App)App.Current).Manager.CurrentUser = user;
                    ((App)App.Current).Manager.UpdateReferences();
                    Application.Current.MainPage = new AppShell();
                    await Navigation.PushModalAsync(new MainPage());
                }
                else Error.Children.Add(new Label { Text = "Mot de passe incorrect",
                    TextColor = Colors.Red,
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Start });
            }
            else Error.Children.Add(new Label { Text = "Information incorrecte",
                TextColor = Colors.Red,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Start});
		}
        else Error.Children.Add(new Label { Text = "Champs vides",
            TextColor = Colors.Red, 
            VerticalTextAlignment = TextAlignment.Start,
            HorizontalTextAlignment=TextAlignment.Start});
    }

    private void Creer_un_compte(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Create();
    }
}