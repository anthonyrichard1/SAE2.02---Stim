using CommunityToolkit.Maui.Views;
using Model;
using System.Globalization;

namespace Stim;

public partial class ReviewPopUp : Popup
{
	public ReviewPopUp()
	{
		InitializeComponent();
	}

    public void CloseButton(object sender, EventArgs e)
    {
        Close();
    }

    private void Valider(object sender, EventArgs e)
    {
        if ((App.Current as App).Manager.SelectedGame == null)
        {
            throw new Exception();
        }
        bool isDouble = double.TryParse(Val.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double rate);
        if (!string.IsNullOrWhiteSpace(Entrytxt.Text) && isDouble)
        {
            ((App)App.Current).Manager.CurrentUser.AddReview((App.Current as App).Manager.SelectedGame, rate, Entrytxt.Text);
            ((App)App.Current).Manager.SaveGames();
            Close();
        }
        else Error.Children.Add(new Label { Text="Champ vide ou invalide", TextColor=Colors.Red });
    }
}