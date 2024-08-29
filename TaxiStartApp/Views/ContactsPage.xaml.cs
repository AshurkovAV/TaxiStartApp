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
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var d = this.dataModel.TaxiParkData;

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
}