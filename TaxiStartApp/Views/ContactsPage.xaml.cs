using Microsoft.Maui.Controls;
using TaxiStartApp.Models;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        private TaxiParkViewModel dataModel;
        public ContactsPage()
        {
            InitializeComponent();
            this.dataModel = new TaxiParkViewModel();
            BindingContext = this.dataModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await this.dataModel.LoadDataAsync();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var d = this.dataModel.TaxiParkData;

        }
    }
}