using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Linq;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelefonPage : ContentPage
    {
        public TelefonPage()
        {
            InitializeComponent();           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(VerificationPage)}?{nameof(VerificationViewModel.Telefon)}={txName.Text}");
        }
    }
}