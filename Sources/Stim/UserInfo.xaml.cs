namespace Stim;
public partial class UserInfo : ContentView
{
    public static readonly BindableProperty BindProperty =
        BindableProperty.Create(nameof(Bind), typeof(string), typeof(UserInfo), string.Empty, propertyChanged: OnBindChanged);

    public string Bind
    {
        get { return (string)GetValue(BindProperty); }
        set { SetValue(BindProperty, value); }
    }

    private static void OnBindChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var contentView = (UserInfo)bindable;
        contentView.OnBindChanged((string)oldValue, (string)newValue);
    }

    public UserInfo()
    {
        InitializeComponent();
        BindingContext = ((App)App.Current).Manager;
    }

    private void OnBindChanged(string oldValue, string newValue)
    {
        // Réagissez aux changements de la propriété de liaison ici
    }
}
