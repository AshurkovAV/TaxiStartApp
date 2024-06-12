using Android.Webkit;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Interface;
using Application = Microsoft.Maui.Controls.Application;

namespace TaxiStartApp.ViewModels.Profil
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        string language;
        bool isPrivateChatEnabled = true;
        bool isGroupChatEnabled;
        bool isSoundEnabled = true;
        string vibrationMode;
        string bio;
        string displayName;
        string defaultEmail;
        string telefon;
        ImageSource avatar;
        IHttpClientTs _httpClientTs;

        public SettingsViewModel()
        {
            var httpClientTs = DependencyService.Get<IHttpClientTs>();
            _httpClientTs = httpClientTs;
            
            Blacklist.CollectionChanged += OnBlacklistCollectionChanged;
        }      

        public async Task LoadDataAsync()
        {
            //DealersLoading = true;            
            Language = "Русский";
            DisplayName = Constant.yandexProfil.displayName;
            DefaultEmail = Constant.yandexProfil.defaultEmail;
            Telefon = Constant.yandexProfil.defaultPhone;
            VibrationMode = "Default";
            var avat = await _httpClientTs.GetAvat();
            Avatar = ImageSource.FromStream(() => avat);
           // DealersLoading = false;
        }

        private bool dealersLoading = true;
        public bool DealersLoading
        {
            get => dealersLoading;
            set
            {
                dealersLoading = value;
                OnPropertyChanged();
            }
        }

        public ImageSource Avatar
        {
            get => this.avatar;
            set
            {
                this.avatar = value;
                OnPropertyChanged();
            }
        }

        public string Telefon
        {
            get => this.telefon;
            set
            {
                this.telefon = value;
                OnPropertyChanged();
            }
        }

        public string DefaultEmail
        {
            get => this.defaultEmail;
            set
            {
                this.defaultEmail = value;
                OnPropertyChanged();
            }
        }
        public string DisplayName
        {
            get => this.displayName;
            set
            {
                this.displayName = value;
                OnPropertyChanged();
            }
        }
        public string Language
        {
            get => this.language;
            set
            {
                this.language = value;
                OnPropertyChanged();
            }
        }
        public bool IsPrivateChatEnabled
        {
            get => this.isPrivateChatEnabled;
            set
            {
                this.isPrivateChatEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsGroupChatEnabled
        {
            get => this.isGroupChatEnabled;
            set
            {
                this.isGroupChatEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsSoundEnabled
        {
            get => this.isSoundEnabled;
            set
            {
                this.isSoundEnabled = value;
                OnPropertyChanged();
            }
        }
        public string VibrationMode
        {
            get => this.vibrationMode;
            set
            {
                this.vibrationMode = value;
                OnPropertyChanged();
            }
        }
        public string Bio
        {
            get => this.bio;
            set
            {
                this.bio = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Blacklist { get; } = new();
        void OnBlacklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Blacklist));
        }
        public List<string> VibrationModes { get; } = new() {
        "Disabled", "Default", "Short", "Long", "Only in Silent Mode"
    };
        public List<string> Contacts { get; } = new() {
        "Bruce Cambell", "Andrea Deville", "Anita Ryan", "George Bunkelman", "Anita Cardle", "Andrew Carter", "Almas Basinger", "Carolyn Baker", "Anthony Rounds"
    };
        public List<string> Languages { get; } = new() {
        "English", "Русский", "Белорусский"
    };
        public ICommand EditBioCommand => new Command(EditBio);
        public ICommand ExitCommand => new Command(Exit);
        public ICommand BackCommand => new Command(Back);


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        async void EditBio()
        {
            Dictionary<string, object> parameters = new() {
            { "Settings", this }
                };
            var st = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync("EditBioPage", parameters);
        }
        async void Exit()
        {
            CookieManager.Instance.RemoveAllCookie();
            var fileHelper = DependencyService.Get<IFileHelper>();
            fileHelper.DeleteFile();
            await Shell.Current.GoToAsync("///LoginPage");
        }

        async void Back()
        {
            await Shell.Current.GoToAsync($"///MainPage");                    
        }


    }
}
