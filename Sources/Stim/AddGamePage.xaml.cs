using Model;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific.Application;
using CommunityToolkit.Maui.Views;
//using Windows.Gaming.Preview.GamesEnumeration;

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
        if (string.IsNullOrEmpty(YearEntry.Text) || !int.TryParse(YearEntry.Text, out year)) message += "Année invalide\n";
        if (string.IsNullOrEmpty(LinkEntry.Text)) message += "Lien invalide\n";
        if (!string.IsNullOrEmpty(NameEntry.Text) && !string.IsNullOrEmpty(DescriptionEntry.Text) && !string.IsNullOrEmpty(YearEntry.Text) && int.TryParse(YearEntry.Text, out year) && !string.IsNullOrWhiteSpace(LinkEntry.Text) /*|| _ImgPath is null*/)
        {
            message = "Jeu ajouté !";
            ((App)App.Current).Manager.AddGametoGamesList(new Game(NameEntry.Text, DescriptionEntry.Text, year, new List<string> { TagEntry1.Text, TagEntry2.Text, TagEntry3.Text }, imgName, LinkEntry.Text));
            await this.ShowPopupAsync(new MessagePopup(message));
            await Navigation.PopModalAsync();
            ((App)App.Current).Manager.SaveGames();

        }
        //      //if (_ImgPath!=null) NameEntry.Text + ".png";
        //      //System.IO.File.Copy(_ImgPath, /**/, true);
        await this.ShowPopupAsync(new MessagePopup(message));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var ImgTask = await FilePicker.Default.PickAsync(null);
        if (ImgTask == null) return;
        _ImgPath = ImgTask.FullPath;
    }
}