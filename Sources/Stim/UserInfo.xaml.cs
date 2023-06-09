using Microsoft.VisualBasic;
using CommunityToolkit.Maui.Views;

namespace Stim;
public partial class UserInfo : ContentView
{
    public bool IsPswd
    {
        get => (bool)GetValue(IsPswdProperty);
        set => SetValue(IsPswdProperty, value);
    }
    public static readonly BindableProperty IsPswdProperty =
        BindableProperty.Create(nameof(Name), typeof(bool), typeof(UserInfo), false);
    public int LabelHeight
    {
        get => (int)GetValue(LabelHeightProperty);
        set => SetValue(LabelHeightProperty, value);
    }
    public static readonly BindableProperty LabelHeightProperty =
        BindableProperty.Create(nameof(Name), typeof(int), typeof(UserInfo), 32);
    public event EventHandler PopUp;
    public void popUp(object sender, EventArgs e)
    {
        PopUp?.Invoke(sender, e);
    }
    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    public static readonly BindableProperty NameProperty =
    BindableProperty.Create(nameof(Name), typeof(string), typeof(UserInfo), "Erreur");

    public UserInfo()
    {
        InitializeComponent();
        if (IsPswd)
        {
            Label.IsVisible = false;
        }
        else Label.IsVisible = true;
    }
}