using Model;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific.Application;
using CommunityToolkit.Maui.Views;
namespace Stim;

public partial class AddGamePage : ContentPage
{
	public AddGamePage()
	{
		InitializeComponent();
	}

    private string? _ImgPath;


    private async void AddGame(object sender, EventArgs e)
	{
		int year;
        string imgName = "no_cover.png";
        string message = "";
        if (string.IsNullOrEmpty(NameEntry.Text)) message += "Nom invalide\n";
        if (string.IsNullOrEmpty(DescriptionEntry.Text)) message += "Description invalide\n";
        if (string.IsNullOrEmpty(YearEntry.Text) || !int.TryParse(YearEntry.Text, out year) || year < 1957 || year > 2023) message += "Année invalide\n";
        if (string.IsNullOrEmpty(LinkEntry.Text)) message += "Lien invalide\n";
        if (message == "" && int.TryParse(YearEntry.Text, out year))
        {
            Game game = new(NameEntry.Text, DescriptionEntry.Text, year, new List<string> { TagEntry1.Text, TagEntry2.Text, TagEntry3.Text }, imgName, LinkEntry.Text);
            if ((App.Current as App).Manager.GameList.Contains(game)) message = "Jeu déjà existant\n";
            else
            {
                message = "Jeu ajouté !";
                ((App)App.Current).Manager.AddGametoGamesList(game);
                await Navigation.PopAsync();
            }
        }
        await this.ShowPopupAsync(new MessagePopup(message));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var ImgTask = await FilePicker.Default.PickAsync(null);
        if (ImgTask == null) return;
        _ImgPath = ImgTask.FullPath;
    }
}