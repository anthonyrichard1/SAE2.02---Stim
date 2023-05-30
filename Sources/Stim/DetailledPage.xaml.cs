using Model;
using StimPersistance;

namespace Stim;

public partial class DetailledPage : ContentPage
{
	public DetailledPage(Game game)
	{
		InitializeComponent();
        BindingContext = game;

        avgLabel.Text = game.Average.ToString();
        AddStars(starsContainer, game.Average);
    }

    private void AddStars(object sender, EventArgs e)
    {
        HorizontalStackLayout layout = sender as HorizontalStackLayout;
        Review rev = layout.BindingContext as Review;
        AddStars(layout, rev.Rate);
    }

    private static void AddStars(HorizontalStackLayout container, float rate)
    {
        for (int i = 0; i < (int)rate; i++) container.Children.Add(new Image { Source = "etoile_pleine.png", WidthRequest = 30 });
        if ((int)rate != rate) container.Children.Add(new Image { Source = "etoile_mi_pleine.png", WidthRequest = 30 });
        while (container.Children.Count != 6) container.Children.Add(new Image { Source = "etoile_vide.png", WidthRequest = 30 });
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void AddReview(object sender, EventArgs e)
    {
        //popup add review
    }
}