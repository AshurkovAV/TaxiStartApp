using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage : ContentPage
    {
        public InputPage()
        {
            InitializeComponent();
            //BindingContext = new AboutViewModel();
        }
    }
}