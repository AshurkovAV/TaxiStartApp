using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views;

public partial class SelectedPage : ContentPage
{
    private SelectedViewModel dataModel;
    public SelectedPage()
	{
		InitializeComponent();
        this.dataModel = new SelectedViewModel();
        BindingContext = this.dataModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await this.dataModel.LoadDataAsync();
    }
    
    private async void OnAccept(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }   
}