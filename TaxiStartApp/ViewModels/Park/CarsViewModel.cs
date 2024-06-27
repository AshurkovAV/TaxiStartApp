using System.Windows.Input;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Common.Interface;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TaxiStartApp.ViewModels.Park
{
    public class CarsViewModel : ViewModelBase, IQueryAttributable
    {
        bool isLoading;
        bool isRespond;
        
        bool isLoadingDrive;
        bool isLoadingWork;
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 3;
        int lastLoadedDriveIndex = 1;
        int lastLoadedWorkIndex = 1;
        int sourceDriveSize = 0;
        int sourceWorkSize = 0;
        private ICommand _loadMoreCommand;
        private ICommand _loadWorkCommand;
        private ICommand _loadDriveCommand;
        private IDataService _dataService;

        public ICommand ShareCommand { get; set; }
        public ICommand LoadDriveCommand {
            get => _loadDriveCommand;
            set
            {
                _loadDriveCommand = value;
                RaisePropertyChanged();
            }
        }
        public ICommand LoadWorkCommand {
            get => _loadWorkCommand;
            set
            {
                _loadWorkCommand = value;
                RaisePropertyChanged();
            }
        }
        public ICommand LoadMoreCommand {
            get => _loadMoreCommand;
            set
            {
                _loadMoreCommand = value;
                RaisePropertyChanged();
            }
        }
        public ICommand OpenBlogCommand { get; set; }
        public ICommand ButtonRespondCommand { get; set; }
        private List<Cars> _carsData;
        private List<ParkDriversCon> _collecDriversConstraint;
        private List<ParkWorkCon> _collecWorkConstraint;
        public List<Cars> CarsData {
            get => _carsData;
            set
            {
                _carsData = value;
                RaisePropertyChanged();
            }
        }
        public List<ParkDriversCon> CollecDriversConstraint
        {
            get => _collecDriversConstraint;
            set
            {
                _collecDriversConstraint = value;
                RaisePropertyChanged();
            }
        }
        public List<ParkWorkCon> CollecWorkConstraint {
            get => _collecWorkConstraint;
            set
            {
                _collecWorkConstraint = value;
                RaisePropertyChanged();
            }
        }
        public CarsViewModel()
        {
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
            LoadDriveCommand = new Command(LoadDrive, CanLoadDriveMore);
            LoadWorkCommand = new Command(LoadWork, CanLoadWorkMore);
            _dataService = DependencyService.Get<IDataService>();
            OpenBlogCommand = new Command<Cars>(OpenBlog);
            LikeCommand = new Command(Like1);
            LikeEmpCommand = new Command(Like2);
            ShareCommand = new Command(ShareLink);
            ButtonRespondCommand = new Command(ButtonRespond);
        }
        Task taskA;
        public async Task LoadAll()
        {
            lastLoadedIndex = 1;
            lastLoadedDriveIndex = 1;
            lastLoadedWorkIndex = 1;
            sourceSize = Common.Constant.ShareParkCountCar;
            sourceDriveSize = Common.Constant.ShareParkCountDrive;
            sourceWorkSize = Common.Constant.ShareParkCountWork;
            await Task.Run(async () =>
            {
                CarsData = new List<Cars>();
                CollecDriversConstraint = new List<ParkDriversCon>();
                CollecWorkConstraint = new List<ParkWorkCon>();
                var selectpr = DataStorage.GetSelectParkDto(Common.Constant.ShareParkId, Common.Constant.yandexProfil.id);
                if (selectpr != null && selectpr?.ParkId != 0)
                {
                    Grid1Visible = false;
                    Grid2Visible = true;
                }
                else
                {
                    Grid1Visible = true;
                    Grid2Visible = false;
                }

            });            
        }        

        public async Task LoadCars(int parkId)
        {
            IsLoading = true;
            
            await Task.Run(async() =>
            {
                IEnumerable<Cars> newCars = null;
                DataCarsStorage._startIndex = lastLoadedIndex;
                DataCarsStorage._batchSize = loadBatchSize;
                newCars = DataCarsStorage.GetBlogs(parkId);
                CarsData.AddRange(newCars);
                lastLoadedIndex += 1;
            });
            
            IsLoading = false;
        }
        public async Task LoadDriveContrain(bool? t = null)
        {
            IsLoadingDrive = true;
                    
            await Task.Run(async () =>
            {
                IEnumerable<ParkDriversCon> newDriveCars = null;
                newDriveCars = DataDriversConstrainStorage.GetBlogs(Common.Constant.ShareParkGuid);
                CollecDriversConstraint.AddRange(newDriveCars);
                lastLoadedDriveIndex += 1;
            });
            
            IsLoadingDrive = false;
        }

        public async Task LoadWorkContrain()
        {
            IsLoadingWork = true;
            
            await Task.Run(async () =>
            {
                IEnumerable<ParkWorkCon> newWorkCars = null;
                newWorkCars = DataWorkConstrainStorage.GetBlogs(Common.Constant.ShareParkGuid);
                CollecWorkConstraint.AddRange(newWorkCars);
                lastLoadedWorkIndex += 1;
            });           
            
            IsLoadingWork = false;
        }

        public void LoadMore()
        {
            LoadCars(Common.Constant.ShareParkId);            
        }
        public void LoadWork()
        {
            LoadWorkContrain();            
        }

        public void LoadDrive()
        {
            LoadDriveContrain(true);            
        }
        
        public bool CanLoadMore()
        {
            return CarsData?.Count < sourceSize;
        }
        public bool CanLoadDriveMore()
        {
            return CollecDriversConstraint?.Count < sourceDriveSize;
        }
        public bool CanLoadWorkMore()
        {
            return CollecWorkConstraint?.Count < sourceWorkSize;           
        }
        public async void ButtonRespond()
        {
            IsRespond = true;
            var driver = _dataService.RespondToRequest();
            if (driver == true) 
            {
                IsRespond = false;
                await Shell.Current.DisplayAlert("Заявка успешно отправлена", "", "OK"); 
            }
            else { IsRespond = false; }
            
        }
        
        public async void OpenBlog(Cars blog)
        {
            await Shell.Current.GoToAsync("EditContactPage");
        }
        public async void ShareLink()
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Uri = Constant.UrlGeneralSite + 
                $"/showparks/showpark.php?id={Constant.ShareParkId}&token=ACC85CA3-8A1B-470E-8FD0-2F0A7DB6F6A7",
                Title = "Share Text " + ParkName
            });
        }
        public bool IsRespond
        {
            get => isRespond;
            set
            {
                isRespond = value;
                RaisePropertyChanged();
            }
        }
        
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoadingDrive
        {
            get => isLoadingDrive;
            set
            {
                isLoadingDrive = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoadingWork
        {
            get => isLoadingWork;
            set
            {
                isLoadingWork = value;
                RaisePropertyChanged();
            }
        }

        private string parkName;
        public string ParkName
        {
            get => this.parkName;
            set
            {
                this.parkName = value;
                RaisePropertyChanged();
            }
        }

        private string parkPhone;
        public string ParkPhone
        {
            get => this.parkPhone;
            set
            {
                this.parkPhone = value;
                RaisePropertyChanged();
            }
        }

        private string addressLatitude;
        public string AddressLatitude
        {
            get => this.addressLatitude;
            set
            {
                this.addressLatitude = value;
                RaisePropertyChanged();
            }
        }
        private string addressLongitude;
        public string AddressLongitude
        {
            get => this.addressLongitude;
            set
            {
                this.addressLongitude = value;
                RaisePropertyChanged();
            }
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var settings = query["Settings"] as ContactTaxiPark;
            ParkName = settings.ParkTrun.ParkName;
            AddressLatitude = settings.ParkTrun.AddressLatitude;
            AddressLongitude = settings.ParkTrun.AddressLongitude;
            ParkPhone = settings.ParkTrun.ParkPhone;
            ParkPercent = settings.ParkTrun.ParkPercent;
            SelfEmployed = settings.ParkTrun.SelfEmployed == true ? "Да":"Нет";
            WithdrawMoneyName = settings.ParkTrun.WithdrawMoneyName;
            WithdrawMoney = settings.ParkTrun.WithdrawMoney;
            Penalties = settings.ParkTrun.Penalties;
            Deposit = settings.ParkTrun.Deposit;
            DepositRet = settings.ParkTrun.DepositRet;
            Waybills = settings.ParkTrun.Waybills;
            Inspection = settings.ParkTrun.Inspection;
            Insurance = settings.ParkTrun.Insurance == true ? "Да" : "Нет"; ;
            MinRentalPeriod = settings.ParkTrun.MinRentalPeriod;
            WorkRadius = settings.ParkTrun.WorkRadius;
            rentalWriteOffTime = settings.ParkTrun.rentalWriteOffTime;
            GasThrowTaxometr = settings.ParkTrun.GasThrowTaxometr == true ? "Да" : "Нет";
            FirstDayName = settings.ParkTrun.FirstDayName;
            Ransom = settings.ParkTrun.Ransom == true ? "Да" : "Нет"; 
        }

        private string selfEmployed; 
        public string SelfEmployed {
            get => selfEmployed;
            set
            {
                selfEmployed = value;
                RaisePropertyChanged();
            }
        } //Самозанятый
        public string? SelfEmployedSum { get; set; }//Сумма доп. взноса для самозанятых
        private string withdrawMoneyName;
        public string? WithdrawMoneyName {
            get => withdrawMoneyName;
            set
            {
                withdrawMoneyName = value;
                RaisePropertyChanged();
            }
        }//Расчет суммы за вывод денег *
        private double withdrawMoney;
        public double WithdrawMoney {
            get => withdrawMoney;
            set
            {
                withdrawMoney = value;
                RaisePropertyChanged();
            }
        }//Вывод денег: значение *
        private string? _penalties;
        public string? Penalties {
            get => _penalties;
            set
            {
                _penalties = value;
                RaisePropertyChanged();
            }
        } //Штрафы
        private string _deposit;
        public string Deposit {
            get => _deposit;
            set
            {
                _deposit = value;
                RaisePropertyChanged();
            }
        } //Депозит *
        private string _depositRet;
        public string DepositRet {
            get => _depositRet;
            set
            {
                _depositRet = value;
                RaisePropertyChanged();
            }
        } //Возврат депозита *
        private string _waybills;
        public string Waybills {
            get => _waybills;
            set
            {
                _waybills = value;
                RaisePropertyChanged();
            }
        } //Путевые *
        private string _inspection;
        public string Inspection {
            get => _inspection;
            set
            {
                _inspection = value;
                RaisePropertyChanged();
            }
        } //Осмотр *
        private string _insurance;
        public string Insurance {
            get => _insurance;
            set
            {
                _insurance = value;
                RaisePropertyChanged();
            }
        } //Страховка *
        private string _minRentalPeriod;
        public string MinRentalPeriod {
            get => _minRentalPeriod;
            set
            {
                _minRentalPeriod = value;
                RaisePropertyChanged();
            }
        } //Мин. срок аренды *
        private string _workRadius;
        public string WorkRadius {
            get => _workRadius;
            set
            {
                _workRadius = value;
                RaisePropertyChanged();
            }
        } //Радиус работы * *
        private string _rentalWriteOffTime;
        public string rentalWriteOffTime {
            get => _rentalWriteOffTime;
            set
            {
                _rentalWriteOffTime = value;
                RaisePropertyChanged();
            }
        } //Время списания аренды * *
        private string _gasThrowTaxometr;
        public string GasThrowTaxometr {
            get => _gasThrowTaxometr;
            set
            {
                _gasThrowTaxometr = value;
                RaisePropertyChanged();
            }
        } //Заправка через таксометр * *
        private string? _firstDayName;
        public string? FirstDayName {
            get => _firstDayName;
            set
            {
                _firstDayName = value;
                RaisePropertyChanged();
            }
        }//Первый день *
        private string _ransom;
        public string Ransom {
            get => _ransom;
            set
            {
                _ransom = value;
                RaisePropertyChanged();
            }
        }//Выкуп


        private double parkPercent;
        public double ParkPercent {
            get => parkPercent;
            set
            {
                parkPercent = value;
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }
        public bool Grid2Visible
        {
            get => grid2Visible;
            set
            {
                grid2Visible = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LikeCommand { get; set; }
        public ICommand LikeEmpCommand { get; set; }

        public async void Like1()
        {
            if (Grid1Visible == true) { 
                Grid1Visible = false; Grid2Visible = true;
                
                var driver = _dataService.CreateSelectPark(new JobTaxi.Entity.Dto.SelectParkDto
                {
                    ParkId = Constant.ShareParkId,
                    UserId = Constant.yandexProfil.id
                });
            }
        }
        public async void Like2()
        {
            if (Grid2Visible == true) {
                var driver = _dataService.DeleteSelectPark(new JobTaxi.Entity.Dto.SelectParkDto
                {
                    ParkId = Constant.ShareParkId,
                    UserId = Constant.yandexProfil.id
                });
                Grid2Visible = false; Grid1Visible = true; }
        }
    }
}
