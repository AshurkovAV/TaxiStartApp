using JobTaxi.Entity.Models;
using System.ComponentModel;
using System.Windows.Input;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;

namespace TaxiStartApp.ViewModels.Park
{
    public class CarsViewModel : ViewModelBase, IQueryAttributable
    {
        bool isLoading;
        bool isLoadingDrive;
        bool isLoadingWork;
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 2;
        int lastLoadedDriveIndex = 1;
        int lastLoadedWorkIndex = 1;
        int sourceDriveSize = 0;
        int sourceWorkSize = 0;        
        public ICommand LoadDriveCommand { get; set; }
        public ICommand LoadWorkCommand { get; set; }
        public ICommand LoadMoreCommand { get; set; }
        public ICommand OpenBlogCommand { get; set; }
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
            OpenBlogCommand = new Command<Cars>(OpenBlog);
            LikeCommand = new Command(Like1);
            LikeEmpCommand = new Command(Like2);
        }

        public async Task LoadAll()
        {            
            await Task.Run(async () =>
            {
                CarsData = new List<Cars>();
                CollecDriversConstraint = new List<ParkDriversCon>();
                CollecWorkConstraint = new List<ParkWorkCon>();

                sourceSize = DataCarsStorage.GetTotalCount(Common.Constant.ShareParkId);
                sourceDriveSize = DataDriversConstrainStorage.GetTotalCount(Common.Constant.ShareParkGuid);
                sourceWorkSize = DataWorkConstrainStorage.GetTotalCount(Common.Constant.ShareParkGuid);
               
                // LoadDataAsync(Common.Constant.ShareParkId);
                // LoadDataDriveAsync();
                //LoadDataWorkAsync();               
            });            
        }        

        public async Task LoadCars(int parkId)
        {
            IsLoading = true;
            IEnumerable<Cars> newCars = null;
            await Task.Run(() =>
            {                                
                DataCarsStorage._startIndex = lastLoadedIndex;
                DataCarsStorage._batchSize = loadBatchSize;
                newCars = DataCarsStorage.GetBlogs(parkId);
            });
            CarsData.AddRange(newCars);
            IsLoading = false;
        }
        public async Task LoadDriveContrain(bool? t = null)
        {
            IsLoadingDrive = true;
            IEnumerable<ParkDriversCon> newDriveCars = null;            
            await Task.Run(() =>
            {
                newDriveCars = DataDriversConstrainStorage.GetBlogs(Common.Constant.ShareParkGuid);
            });
            CollecDriversConstraint.AddRange(newDriveCars);
            IsLoadingDrive = false;
        }

        public async Task LoadWorkContrain()
        {
            IsLoadingWork = true;
            IEnumerable<ParkWorkCon> newWorkCars = null;
            await Task.Run(() =>
            {
                newWorkCars = DataWorkConstrainStorage.GetBlogs(Common.Constant.ShareParkGuid);
                
            });
            CollecWorkConstraint.AddRange(newWorkCars);          
            
            IsLoadingWork = false;
        }
        public void LoadWork()
        {
            LoadWorkContrain();
            lastLoadedWorkIndex += 1;
        }

        public void LoadDrive()
        {
            LoadDriveContrain(true);
            lastLoadedDriveIndex += 1;
        }
        public void LoadMore()
        {
            LoadCars(Common.Constant.ShareParkId);
            lastLoadedIndex += 1;
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
        public async void OpenBlog(Cars blog)
        {
            await Shell.Current.GoToAsync("EditContactPage");
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
        public double WithdrawMoney { get; set; }//Вывод денег: значение *
        public string? Penalties { get; set; } //Штрафы

        public string Deposit { get; set; } //Депозит *
        public string DepositRet { get; set; } //Возврат депозита *
        public string Waybills { get; set; } //Путевые *
        public string Inspection { get; set; } //Осмотр *
        public bool Insurance { get; set; } //Страховка *
        public string MinRentalPeriod { get; set; } //Мин. срок аренды *
        public string WorkRadius { get; set; } //Радиус работы * *
        public string rentalWriteOffTime { get; set; } //Время списания аренды * *
        public bool GasThrowTaxometr { get; set; } //Заправка через таксометр * *
        public string? FirstDayName { get; set; }//Первый день *
        public bool Ransom { get; set; }//Выкуп


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
            if (Grid1Visible == true) { Grid1Visible = false; Grid2Visible = true; }
        }
        public async void Like2()
        {
            if (Grid2Visible == true) { Grid2Visible = false; Grid1Visible = true; }
        }
    }
}
