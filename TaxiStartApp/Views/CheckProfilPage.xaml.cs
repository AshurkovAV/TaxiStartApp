using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckProfilPage : ContentPage
    {
        public CheckProfilPage()
        {
            InitializeComponent();
            BindingContext = new CheckProfilViewModel();
        }        
    }
}