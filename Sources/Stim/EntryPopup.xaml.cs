using CommunityToolkit.Maui.Views;

namespace Stim;

public partial class EntryPopup : Popup
{
	public EntryPopup(string fieldName)
	{
		InitializeComponent();
        placeholder.Text = fieldName;
	}

    public void CloseButton(object sender, EventArgs e)
    {
        Close();
    }

    private void Valider(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Entrytxt.Text)) Close(Entrytxt.Text);
        else Error.Children.Add(new Label { Text="Champ vide", TextColor=Colors.Red });
    }
}