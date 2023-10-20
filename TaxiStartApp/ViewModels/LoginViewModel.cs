using Microsoft.Maui.Controls;
using System;
using TaxiStartApp.Views;

namespace TaxiStartApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    { 
        public LoginViewModel()
        {
            TelefonCommand = new Command(OnTelefonClicked);
            PropertyChanged +=
                (_, __) => TelefonCommand.ChangeCanExecute();
        }       

        public Command TelefonCommand { get; }


        async void OnTelefonClicked()
        {            
            await Shell.Current.GoToAsync($"//{nameof(TelefonPage)}");           
        }        
    }
}