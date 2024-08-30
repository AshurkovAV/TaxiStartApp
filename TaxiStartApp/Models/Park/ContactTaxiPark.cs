using IntelliJ.Lang.Annotations;
using JobTaxi.Entity.Dto;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaxiStartApp.Services;

namespace TaxiStartApp.Models.Park
{
    public class ContactTaxiPark : ParkTruncated, INotifyPropertyChanged
    {
        public ParkTruncated ParkTrun { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand LikeEmpCommand { get; set; }
        public ICommand ButtonRespondCommand { get; set; }
        private IDataService _dataService;

        public ContactTaxiPark(ParkTruncated parkTruncated)
        {
            Id = parkTruncated.Id;
            ParkName = parkTruncated.ParkName;
            ParkGuid = parkTruncated.ParkGuid;           
            ParkTrun = parkTruncated;
            _dataService = DependencyService.Get<IDataService>();
            LikeCommand = new Command(Like1);
            LikeEmpCommand = new Command(Like2);
            ButtonRespondCommand = new Command(ButtonRespond);
            Avatar = ImageSource.FromStream(() => new MemoryStream(ParkTrun.CarAvatar));
        }

        ImageSource avatar;
        public ImageSource Avatar
        {
            get => this.avatar;
            set
            {
                this.avatar = value;
                OnPropertyChanged("Avatar");
            }
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
        string glyph = "&#xe802;";
        public int Id { get; set; }
        public string  ParkGuid { get; set; }
        public string  ParkName { get; set; }
        public string  ParkAddress { get; set; }
        public string  ParkPhone { get; set; }
        public string  AddressLatitude { get; set; }
        public string  AddressLongitude { get; set; }
        public double  ParkPercent { get; set; }
        public bool    SelfEmployed { get; set; } //Самозанятый
        public string? SelfEmployedSum { get; set; }//Сумма доп. взноса для самозанятых
        public string? WithdrawMoneyName { get; set; }//Расчет суммы за вывод денег *
        public double  WithdrawMoney { get; set; }//Вывод денег: значение *
        public string? Penalties { get; set; } //Штрафы

        public string  Deposit { get; set; } //Депозит *
        public string  DepositRet { get; set; } //Возврат депозита *
        public string  Waybills { get; set; } //Путевые *
        public string  Inspection { get; set; } //Осмотр *
        public bool    Insurance { get; set; } //Страховка *
        public string  MinRentalPeriod { get; set; } //Мин. срок аренды *
        public string  WorkRadius { get; set; } //Радиус работы * *
        public string  rentalWriteOffTime { get; set; } //Время списания аренды * *
        public bool    GasThrowTaxometr { get; set; } //Заправка через таксометр * *
        public string? FirstDayName { get; set; }//Первый день *
        public bool    Ransom { get; set; }//Выкуп

        public string Glyph
        {
            get => glyph;
            set
            {
                glyph = value;
                //OnPropertyChanged();
            }
        }
        public int CountCars { get; set; }
        public DateTime? PublicationDate { get; set; }        
        ImageSource carAvatar;
        public ImageSource CarAvatar
        {
            get => carAvatar;
            set
            {
                carAvatar = value;
                OnPropertyChanged("CarAvatar");
            }
        }
        public string AvatarPath => ParkAddress?.ToLower() + ".jpg";



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
