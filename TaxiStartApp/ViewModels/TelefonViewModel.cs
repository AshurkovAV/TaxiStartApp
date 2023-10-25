using FirebaseAdmin.Messaging;
using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using System;
using TaxiStartApp.Views;

namespace TaxiStartApp.ViewModels
{

    public class TelefonViewModel : BaseViewModel
    {
        string telefon;
        bool _btEnabled;

        public TelefonViewModel()
        {
            PushCommand = new Command(OnPushClicked);
            BackCommand = new Command(OnBackClicked);
            PropertyChanged +=
                (_, __) => PushCommand.ChangeCanExecute();
            _btEnabled = false;
        }
        
        public bool BtEnabled {
            get => this._btEnabled;
            set {
                if (Telefon?.Length == 10)
                {
                    _btEnabled = true;
                }
                else {
                    _btEnabled = false;
                }
                SetProperty(ref this._btEnabled, value); 
            }
        }

        public string Telefon
        {
            get => this.telefon;
            set => SetProperty(ref this.telefon, value);
        }

        public Command PushCommand { get; }
        public Command BackCommand { get; }
        
        async void OnPushClicked()
        {
            await Shell.Current.GoToAsync($"{nameof(VerificationPage)}?{nameof(VerificationViewModel.Telefon)}={telefon}");
        }
        async void OnBackClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}