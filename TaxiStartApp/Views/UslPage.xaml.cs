using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UslPage : ContentPage
    {
        public UslPage()
        {
            InitializeComponent();
            BindingContext = new UslViewModel();
        }
    }
}