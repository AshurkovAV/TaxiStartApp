using DevExpress.Maui.Controls;
using JobTaxi.Entity.Dto.User;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaxiStartApp.Services;

namespace TaxiStartApp.Models.User
{
    public class Subscription : UsersFilterDto, INotifyPropertyChanged
    {
        public UsersFilterDto Filter { get; set; }
        public ICommand ButtonRespondCommand { get; set; }
        public ICommand ButtonSheetCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RenameCommand { get; set; }
        public ICommand EditCommand { get; set; }
        



        public string textPush;

        private IDataService _dataService;

        public Subscription(UsersFilterDto usersFilterDto)
        {
            Id = usersFilterDto.Id;
            Filter = usersFilterDto;
            _dataService = DependencyService.Get<IDataService>();
            ButtonRespondCommand = new Command(ButtonRespond);
            ButtonSheetCommand = new Command(ButtonSheetLoad);
            BackCommand = new Command(Back);
            DeleteCommand = new Command(Delete);
            EditCommand = new Command(Edit);
            RenameCommand = new Command(Back);
            BottomSheetState = BottomSheetState.Hidden;
        }
        BottomSheetState bottomSheetState;
        public BottomSheetState BottomSheetState
        {
            get => bottomSheetState;
            set
            {
                bottomSheetState = value;
                OnPropertyChanged();
            }
        }
        public string TextPush
        {
            get
            {
                if (Filter.IsPush)
                {
                    textPush = "Уведомления включены";
                }
                else
                {
                    textPush = "Уведомления выключенны";
                }
                return textPush;
            }
            set
            {
                textPush = value;
                OnPropertyChanged();
            }
        }

        void Back()
        {
            BottomSheetState = BottomSheetState.Hidden;
        }
        void Delete()
        {
            _ = Task.Run(() =>
            {
                var data = _dataService.DeleteUsersFilter(Filter.Id);
                if (data == true)
                {                    
                }

                BottomSheetState = BottomSheetState.Hidden;
            });
        }
        void Edit()
        {
            
        }
        void Rename()
        {
            
        }
        

        void ButtonSheetLoad()
        {
            if (BottomSheetState == BottomSheetState.HalfExpanded)
            {
                BottomSheetState = BottomSheetState.Hidden;
            }
            else
            {
                BottomSheetState = BottomSheetState.HalfExpanded;
            }
        }
        public async void ButtonRespond()
        {
            _ = Task.Run(() =>
            {
                var data = _dataService.IsPushNotif(Filter.Id, !(bool)Filter.IsPush);
                if (data == true)
                {
                    Filter.IsPush = !(bool)Filter.IsPush;
                    if (Filter.IsPush)
                    {
                        TextPush = "Уведомления включены";
                    }
                    else
                    {
                        TextPush = "Уведомления выключенны";
                    }
                }
            });
        }
        public DateTime? PublicationDate { get; set; }   


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
