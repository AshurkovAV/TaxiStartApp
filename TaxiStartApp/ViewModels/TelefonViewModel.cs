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
        }       
       

        public string Telefon
        {
            get => this.telefon;
            set {             
                this.telefon = value;
                OnPropertyChanged("Telefon");
            }
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