using TaxiStartApp.Common;
using TaxiStartApp.Views;

namespace TaxiStartApp.ViewModels
{
    [QueryProperty(nameof(Telefon), nameof(Telefon))]
    public class VerificationViewModel : BaseViewModel
    {
        string _telefon;
        int? _kod;
        bool _btIsEnabled = false;
        string _btText = "Вход";
        string _errorText = string.Empty;
        private int _num = 60;
        private System.Threading.Timer _timer;

        public VerificationViewModel()
        {
            BackCommand = new Command(OnBackClicked);
            PushCommand = new Command(OnPushClicked);
            CommCommand = new Command(OnCommClicked);
            StartTimer();
        }

        private async void OnCommClicked(object obj)
        {
            if (Kod?.ToString().Length == 4)
            {
                if (Kod == 3939)
                {
                    await Shell.Current.GoToAsync($"//{nameof(CheckProfilPage)}");
                }
                else
                {
                    ErrorText = Constant.PushErrorText;
                }
            }
        }

        private void StartTimer()
        {
            //Создание потока в потоке пользовательского интерфейса
            if (MainThread.IsMainThread)
                MyMainThreadCode();
            else
                MainThread.BeginInvokeOnMainThread(MyMainThreadCode);            
        }
        void MyMainThreadCode()
        {
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            if (_timer == null)
                _timer = new System.Threading.Timer(tm, _num, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }
        #region propert

        public string ErrorText
        {
            get { return this._errorText; }
            set { SetProperty(ref this._errorText, value); }
        }
        
        public string BtText
        {
            get { return this._btText; }
            set { SetProperty(ref this._btText, value); }
        }

        public bool BtIsEnabled
        {
            get { return this._btIsEnabled; }
            set { SetProperty(ref this._btIsEnabled, value); }
        }

        public string Telefon
        {
            get { return this._telefon; }
            set { SetProperty(ref this._telefon, value); }
        }

        public int? Kod
        {
            get { return this._kod; }
            set { SetProperty(ref this._kod, value); }
        } 
        #endregion

        public Command BackCommand { get; }
        public Command PushCommand { get; }
        public Command CommCommand { get; }

        async void OnPushClicked()
        {
            _num = 60;
            StartTimer();
            BtIsEnabled = false;
        }
        async void OnBackClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(TelefonPage)}");
        }

        private void Count(object obj)
        {
            if (_num > 0)
            {
                string strInvo = "Отправить код повторно (";
                BtText = strInvo + _num.ToString() + " сек)";
                BtIsEnabled = false;               
                _num--;
            }
            else
            {
                BtText = Constant.PushNotification;
                BtIsEnabled = true;                
            }
        }

        
    }
}