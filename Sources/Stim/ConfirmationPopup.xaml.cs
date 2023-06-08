using CommunityToolkit.Maui.Views;

namespace Stim;

public partial class ConfirmationPopup : Popup
{
	public ConfirmationPopup(string message)
	{
		InitializeComponent();
		placeholder.Text = message;
	}

	public void Yes(object sender, EventArgs e)
		=> Close(true);
	public void No(object sender, EventArgs e)
		=> Close(false);
}