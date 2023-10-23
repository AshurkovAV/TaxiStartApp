using Android.Bluetooth;
using Microsoft.Maui.Controls;
using System;
using TaxiStartApp.Views;

namespace TaxiStartApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _textAlignment;
        public LoginViewModel()
        {
            TelefonCommand = new Command(OnTelefonClicked);
            UslCommand = new Command(OnUslClicked);
            PropertyChanged +=
                (_, __) => TelefonCommand.ChangeCanExecute();                        
        }        

        public Command TelefonCommand { get; }
        public Command UslCommand { get; }

        
        async void OnTelefonClicked()
        {            
            await Shell.Current.GoToAsync($"//{nameof(TelefonPage)}");           
        }
        async void OnUslClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(UslPage)}");
        }
        public TextAlignment TextAlignmentForms { get; set; } = TextAlignment.Center;       
    }
}