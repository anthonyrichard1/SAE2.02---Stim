using CommunityToolkit.Maui.Views;

namespace Stim;

public partial class EntryPopup : Popup
{
	public EntryPopup(string fieldName)
	{
		InitializeComponent();
        LabelTxt.Text = fieldName;
	}

    public void CloseButton(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Entrytxt.Text)) Close(Entrytxt.Text);
    }
}