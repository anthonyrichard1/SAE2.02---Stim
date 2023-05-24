using Model;

namespace Stim;

public partial class AddGamePage : ContentPage
{
	public Manager Manager { get; set; }

	public AddGamePage(Manager Mgr)
	{
		InitializeComponent();
		Manager = Mgr;
	}

	private void AddGame(object sender, EventArgs e)
	{
		int year;
		if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(DescriptionEntry.Text) || string.IsNullOrEmpty(YearEntry.Text) || !int.TryParse(YearEntry.Text, out year) || string.IsNullOrWhiteSpace(LinkEntry.Text)) return;

		Manager.AddGametoGamesList(new Game(NameEntry.Text, DescriptionEntry.Text, year, new List<string> { TagEntry1.Text, TagEntry2.Text, TagEntry3.Text }, "nyancat.png", LinkEntry.Text));
		Navigation.RemovePage(this);
	}
}