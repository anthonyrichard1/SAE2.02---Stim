using CommunityToolkit.Maui.Views;

namespace Stim;

public partial class MessagePopup : Popup
{
    public MessagePopup(string message)
    {
        InitializeComponent();
        placeholder.Text = message;
    }

    public void CloseButton(object sender, EventArgs e)
    {
        Close();
    }
}