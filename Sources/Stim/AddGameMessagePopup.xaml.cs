using CommunityToolkit.Maui.Views;

namespace Stim;

public partial class AddGameMessagePopup : Popup
{
	public AddGameMessagePopup(string message)
	{
		InitializeComponent();
		placeholder.Text = message;
	}

	public void CloseButton(object sender, EventArgs e)
	{
		Close();
	}
}