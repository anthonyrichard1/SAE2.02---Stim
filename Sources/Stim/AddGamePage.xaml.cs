using Model;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific.Application;
//using Windows.Gaming.Preview.GamesEnumeration;

namespace Stim;

public partial class AddGamePage : ContentPage
{
	public AddGamePage()
	{
		InitializeComponent();
	}

    private string? _ImgPath;


    private void AddGame(object sender, EventArgs e)
	{
		int year;
        string imgName = "no_cover.png";
        if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(DescriptionEntry.Text) || string.IsNullOrEmpty(YearEntry.Text) || !int.TryParse(YearEntry.Text, out year) || string.IsNullOrWhiteSpace(LinkEntry.Text) /*|| _ImgPath is null*/) return;
        //if (_ImgPath!=null) NameEntry.Text + ".png";
        //System.IO.File.Copy(_ImgPath, /**/, true);
        ((App)App.Current).Manager.AddGametoGamesList(new Game(NameEntry.Text, DescriptionEntry.Text, year, new List<string> { TagEntry1.Text, TagEntry2.Text, TagEntry3.Text }, imgName, LinkEntry.Text));
		Navigation.RemovePage(this);
        ((App)App.Current).Manager.SaveGames();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var ImgTask = await FilePicker.Default.PickAsync(null);
        if (ImgTask == null) return;
        _ImgPath = ImgTask.FullPath;
    }
}