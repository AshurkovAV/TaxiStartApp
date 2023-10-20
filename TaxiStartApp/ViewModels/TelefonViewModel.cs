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

        public TelefonViewModel()
        {
            PushCommand = new Command(OnPushClicked);
            BackCommand = new Command(OnBackClicked);
            PropertyChanged +=
                (_, __) => PushCommand.ChangeCanExecute();
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