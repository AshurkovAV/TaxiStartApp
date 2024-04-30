using System.Windows.Input;
using TaxiStartApp.Views;

namespace TaxiStartApp.ViewModels
{
    public class CheckProfilViewModel : BaseViewModel
    {        
        public CheckProfilViewModel()
        {
            Title = "Выбор профиля";
            DriverCommand = new Command(OnDriverClicked);
        }
        public Command DriverCommand { get; }
        async void OnDriverClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }
        
    }
}