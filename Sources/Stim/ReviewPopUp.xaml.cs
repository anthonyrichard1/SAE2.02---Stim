using CommunityToolkit.Maui.Views;
using Model;
using System.Globalization;

namespace Stim;

public partial class ReviewPopUp : Popup
{
    Game CurrGame { get; set; }
	public ReviewPopUp(Game currGame)
	{
		InitializeComponent();
        CurrGame = currGame;
	}

    public void CloseButton(object sender, EventArgs e)
    {
        Close();
    }

    private void Valider(object sender, EventArgs e)
    {
        if (CurrGame == null)
        {
            throw new Exception();
        }
        bool IsFloat = float.TryParse(Val.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float rate);
        if (!string.IsNullOrWhiteSpace(Entrytxt.Text) && IsFloat)
        {
            ((App)App.Current).Manager.CurrentUser.AddReview(CurrGame, rate, Entrytxt.Text);
            Close();
        }
        else Error.Children.Add(new Label { Text="Champ vide ou invalide", TextColor=Colors.Red });
    }
}