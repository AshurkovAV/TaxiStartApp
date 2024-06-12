namespace TaxiStartApp.Views;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
	}
    private async void OnAccept(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void Button_Pressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#494949");
    }

    private void Button_Released(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Color.FromArgb("#FFC71F");
    }
}