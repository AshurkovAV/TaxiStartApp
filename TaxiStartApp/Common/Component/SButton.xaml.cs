namespace TaxiStartApp.Common.Component;

public partial class SButton : ContentPage
{
	public SButton()
	{
		InitializeComponent();
	}
    public event EventHandler ClickAction;
    private void Button_Pressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.AliceBlue;
    }

    private void Button_Released(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Colors.BlueViolet;
    }
}