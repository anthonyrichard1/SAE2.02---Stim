namespace Stim;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
		{
			if (count == 69)
				CounterBtn.Text = $"Clicked {count} times, funny number";
			else
                CounterBtn.Text = $"Clicked {count} times";
        }

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

