using CommunityToolkit.Maui.Views;
using Model;
using System.Globalization;

namespace Stim;

public partial class ReviewPopUp : Popup
{
    private readonly bool editing = false;
    private Review prevRev = null;
	public ReviewPopUp(Review previousRev = null)
	{
		InitializeComponent();
        if (previousRev != null)
        {
            prevRev = previousRev;
            Entrytxt.Text = previousRev.Text;
            Val.Text = previousRev.Rate.ToString();
            editing = true;
        }
	}

    public void CloseButton(object sender, EventArgs e)
    {
        Close(0);
    }

    private void Valider(object sender, EventArgs e)
    {
        int res;
        if ((App.Current as App).Manager.SelectedGame == null)
        {
            throw new Exception();
        }
        bool isDouble = double.TryParse(Val.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double rate);
        if (!string.IsNullOrWhiteSpace(Entrytxt.Text) && isDouble)
        {
            //Error.Text = "";
            if (editing == true)
            {
                if (prevRev.Text != Entrytxt.Text) prevRev.EditReview(Entrytxt.Text);
                prevRev.EditRate(rate);
                (App.Current as App).Manager.SelectedGame.UpdateReviews();
                res = 2;
            }
            else
            {
                ((App)App.Current).Manager.CurrentUser.AddReview((App.Current as App).Manager.SelectedGame, rate, Entrytxt.Text);
                res = 1;
            }

            ((App)App.Current).Manager.SaveGames();
            Close(res);
        }
        //else Error.Text = "Champ vide ou invalide";
    }
}