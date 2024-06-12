using DevExpress.Maui.Editors;
using TaxiStartApp.Models;
using TaxiStartApp.ViewModels.Park;
using TaxiStartApp.ViewModels.Profil;

namespace TaxiStartApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class EditContactPage : ContentPage
{
    private CarsViewModel dataModel;
    public EditContactPage()
    {
        InitializeComponent();
        this.dataModel = new CarsViewModel();
        BindingContext = this.dataModel;
        
    }    
   
    private async void OnAccept(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await this.dataModel.LoadAll();
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