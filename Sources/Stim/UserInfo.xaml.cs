using Microsoft.VisualBasic;
using CommunityToolkit.Maui.Views;

namespace Stim;
public partial class UserInfo : ContentView
{
    public event EventHandler popUp;
    public void PopUp(object sender, EventArgs e)
    {
        popUp?.Invoke(sender, e);
    }
    public string Name
    {
        get => (string)GetValue(NameProperty); 
        set => SetValue(NameProperty, value); 
    }
    public static readonly BindableProperty NameProperty =
    BindableProperty.Create(nameof(Name), typeof(string), typeof(UserInfo), "Erreur");

    public int Button
    {
        get => (int)GetValue(ButtonProperty);
        set => SetValue(ButtonProperty, value);
    }
    public static readonly BindableProperty ButtonProperty =
    BindableProperty.Create(nameof(Button), typeof(int), typeof(UserInfo), 4);

    public UserInfo()
    {
        InitializeComponent();
    }

    private async void Modif(object sender, EventArgs e)
    {
        //if      (Button == 0)
        //{
        //    //var result = await CurrentPage.ShowPopupAsync(new EntryPopup("Username"));
        //    if (string.IsNullOrWhiteSpace((string)result))
        //    {
        //        ((App)App.Current).Manager.CurrentUser.Username = (string)result;
        //    }
        //}
        //else if (Button == 1)
        //{
        //    //var result = await CurrentPage.ShowPopupAsync(new EntryPopup("Username"));
        //    if (string.IsNullOrWhiteSpace((string)result))
        //    {
        //        ((App)App.Current).Manager.CurrentUser.Username = (string)result;
        //    }
        //}
        //else if (Button == 2)
        //{
        //    //var result = await CurrentPage.ShowPopupAsync(new EntryPopup("Username"));
        //    if (string.IsNullOrWhiteSpace((string)result))
        //    {
        //        ((App)App.Current).Manager.CurrentUser.Username = (string)result;
        //    }
        //}
        //else if (Button == 3)
        //{
        //    //var result = await CurrentPage.ShowPopupAsync(new EntryPopup("Username"));
        //    if (string.IsNullOrWhiteSpace((string)result))
        //    {
        //        ((App)App.Current).Manager.CurrentUser.Username = (string)result;
        //    }
        //}
        throw new ArgumentOutOfRangeException();
    }
}