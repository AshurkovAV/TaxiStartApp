using Android.Widget;
using JobTaxi.Entity.Dto;
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
        public ICommand LikeCommand { get; set; }
        public ICommand LikeEmpCommand { get; set; }
        public ICommand ButtonRespondCommand { get; set; }
        private IDataService _dataService;
        

        public Subscription(UsersFilterDto usersFilterDto)
        {
            Id = usersFilterDto.Id;
            Filter = usersFilterDto;
            _dataService = DependencyService.Get<IDataService>();
            LikeCommand = new Command(Like1);
            LikeEmpCommand = new Command(Like2);
            ButtonRespondCommand = new Command(ButtonRespond);
        }
        public async void ButtonRespond()
        {
            
                var driver = _dataService.RespondToRequest(Id);
                if (driver == true)
                {
                    await Shell.Current.DisplayAlert("Заявка успешно отправлена", "", "OK");
                }
            
        }
        public async void Like1()
        {
            if (Grid1Visible == true)
            {
                Grid1Visible = false; Grid2Visible = true;

                var driver = _dataService.CreateSelectPark(new JobTaxi.Entity.Dto.SelectParkDto
                {
                    ParkId = Id,
                    UserId = Common.Constant.yandexProfil.id
                });
            }
        }
        public async void Like2()
        {
            if (Grid2Visible == true)
            {
                var driver = _dataService.DeleteSelectPark(new JobTaxi.Entity.Dto.SelectParkDto
                {
                    ParkId = Id,
                    UserId = Common.Constant.yandexProfil.id
                });
                Grid2Visible = false; Grid1Visible = true;
            }
        }
        private bool grid1Visible = true;
        private bool grid2Visible = false;
        public bool Grid1Visible
        {
            get => grid1Visible;
            set
            {
                grid1Visible = value;
                OnPropertyChanged();
            }
        }
        public bool Grid2Visible
        {
            get => grid2Visible;
            set
            {
                grid2Visible = value;
                OnPropertyChanged();
            }
        }       
        public DateTime? PublicationDate { get; set; }   


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
