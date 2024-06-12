using TaxiStartApp.ViewModels;
using TaxiStartApp.ViewModels.Shimmer;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage : ContentPage
    {
        private ShimmerViewModel dataModel;
        public InputPage()
        {
            InitializeComponent();
            this.dataModel = new ShimmerViewModel();
            BindingContext = this.dataModel;
        }               

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.dataModel.LoadDataAsync();
        }

    }
}