using TaxiStartApp.Models;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        bool loaded = false;
        public MainPage()
        {
            InitializeComponent();              
        }
        protected internal void DisplayStack()
        {
            //NavigationPage navPage = (AppShell)Application.Current.MainPage;
            ////stackLabel.Text = "";
            //foreach (Page p in navPage.Navigation.NavigationStack)
            //{
            //    //stackLabel.Text += p.Title + "\n";
            //}
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (loaded == false)
            {
                DisplayStack();
                loaded = true;
            }
        }

    }
}