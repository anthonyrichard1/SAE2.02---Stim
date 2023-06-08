namespace Stim;

public partial class StarsContainer : ContentView
{
	public static readonly BindableProperty RateProperty =
		BindableProperty.Create(nameof(Rate), typeof(double), typeof(StarsContainer), double.NaN); 

	public double Rate
	{
		get => (double)GetValue(StarsContainer.RateProperty);
		set => SetValue(StarsContainer.RateProperty, value);
	}

	public StarsContainer()
	{
		InitializeComponent();
	}
}