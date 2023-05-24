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
		//faut rajouter des tests
		string tag1 = TagEntry1.Text;
        string tag2 = TagEntry2.Text;
        string tag3 = TagEntry3.Text;
		Manager.AddGametoGamesList(new Game(NameEntry.Text, DescriptionEntry.Text, int.Parse(YearEntry.Text), new List<string> { tag1, tag2, tag3 }, "null", "www.link.com"));
	}
}