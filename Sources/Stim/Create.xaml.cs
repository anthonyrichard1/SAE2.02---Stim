using Microsoft.Maui.Graphics;
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
        Error.Clear();
        if (!string.IsNullOrWhiteSpace(Username.Text) || !string.IsNullOrWhiteSpace(Pswd.Text) || !string.IsNullOrWhiteSpace(Email.Text))
        {
            if (((App)App.Current).Manager.SearchUser(Username.Text) == null)
            {
                Regex rg = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (rg.IsMatch(Email.Text))
                {
                    rg = new Regex("^(?=.*[A-Za-z])(?=.*[0-9@$!%*#?&])[A-Za-z-0-9@$!%*#?&]{8,}$");
                    if (rg.IsMatch(Pswd.Text))
                    {
                        ((App)App.Current).Manager.AddUsertoUserList(new("", Username.Text, "", Email.Text, Pswd.Text));
                        ((App)App.Current).Manager.CurrentUser = ((App)App.Current).Manager.SearchUser(Username.Text);
                        Application.Current.MainPage = new AppShell();
                        await Shell.Current.GoToAsync("//MainPage");
                    }
                    else Error.Children.Add(new Label { Text = "Mot de passe invalide, votre mot de passe doit contenir une Majuscule, une minuscule, un chiffre et faire au moins 8 caractères", TextColor = Colors.Red, VerticalTextAlignment = TextAlignment.Start });
                }
                else Error.Children.Add(new Label { Text = "Email invalide", TextColor = Colors.Red, VerticalTextAlignment = TextAlignment.Start });
            }
            else Error.Children.Add(new Label { Text = "Ce nom d'utilisateur est déjà pris", TextColor = Colors.Red, VerticalTextAlignment = TextAlignment.Start });
        }
        else Error.Children.Add(new Label { Text = "Champs vides", TextColor = Colors.Red, VerticalTextAlignment = TextAlignment.Start });
    }
    private void Se_connecter(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
}