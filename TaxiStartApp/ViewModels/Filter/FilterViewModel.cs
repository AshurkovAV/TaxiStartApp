using AndroidX.ConstraintLayout.Core;
using DataCore.Cache;
using DataCore.Data.Nsi;
using DataCore.Models.Nsi;
using DataCore.Service;
using JobTaxi.Entity.Dto.User;

using System.Collections.Specialized;
using System.Windows.Input;
using TaxiStartApp.Common;
using TaxiStartApp.Models;
using TaxiStartApp.Services;

namespace TaxiStartApp.ViewModels
{
    public class FilterViewModel : ViewModelBase
    {

        private ICommand _buttonRespondCommand;
        public ICommand ButtonRespondCommand
        {
            get => _buttonRespondCommand;
            set
            {
                _buttonRespondCommand = value;
                RaisePropertyChanged();
            }
        }
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                RaisePropertyChanged();
            }
        }
        private IServiceProvider _serviceProvider;
        private IDataService _dataService;
        public FilterViewModel(
            IServiceProvider serviceProvider,
            IDataService dataService)
        {
            _serviceProvider = serviceProvider;
            _dataService = dataService;
            NsiLocation.CollectionChanged += OnBlacklistCollectionChanged;
            NsiAutoClassSelect.CollectionChanged += OnWorklistCollectionChanged;
            SaveCommand = new Command(Save);
            _usersFilter = new UsersFilterDto();   
            Load();
        }

        private void Load()
        {
            var cacheRepository = _serviceProvider.GetService<ICacheRepository>();
            Task.Run(() => {                
                //var d = (DictionaryCache<IEnumerable<DriversConstraint>>)cacheRepository.Get("DriversConstrainCache");
                var wc = (DictionaryCache<IEnumerable<WorkCondition>>)cacheRepository.Get("WorkConditionCache");
                //var dr = (DictionaryCache<IEnumerable<DepositRet>>)cacheRepository.Get("DepositRetCache");
                //var w = (DictionaryCache<IEnumerable<Waybills>>)cacheRepository.Get("WaybillsCache");
                //var fd = (DictionaryCache<IEnumerable<FirstDay>>)cacheRepository.Get("FirstDayCache");
                //var i = (DictionaryCache<IEnumerable<Inspection>>)cacheRepository.Get("InspectionCache");
                //var mrp = (DictionaryCache<IEnumerable<MinRentalPeriod>>)cacheRepository.Get("MinRentalPeriodCache");
               // var wr = (DictionaryCache<IEnumerable<WorkRadius>>)cacheRepository.Get("WorkRadiusCache");
                var loc = (DictionaryCache<IEnumerable<DataCore.Models.Nsi.Location>>)cacheRepository.Get("LocationCache");
                var auto = (DictionaryCache<IEnumerable<DataCore.Models.Nsi.AutoClass>>)cacheRepository.Get("AutoClassCache");
                LocationFiltr = loc.Data;
                AutoClasses = auto.Data;
                WorkCons = wc.Data;
                //DriversCons = d.Data;
                //DepositRets = dr.Data;
                //Waybills = w.Data;
                //WorkRadii = wr.Data;
                //Inspections = i.Data;
                //MinRentalPeriods = mrp.Data;
                //FirstDays = fd.Data;
                TimeSps = TimeSpStorage.GetBlogs();
            });
        }

        private void Save()
        {
            var filterName = UserFilter.FilterName;
            UserFilter.FilterUserId = Constant.yandexProfil.id;
            _dataService.CreateUserFilter(UserFilter);

        }
        private UsersFilterDto _usersFilter;
        public UsersFilterDto UserFilter {
            get => _usersFilter;
            set
            {
                _usersFilter = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<AutoClass> NsiAutoClassSelect { get; } = new();
        void OnWorklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(NsiAutoClassSelect));
        }
        public ObservableCollection<DataCore.Models.Nsi.Location> NsiLocation { get; } = new();
        void OnBlacklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(NsiLocation));
        }
        private IEnumerable<DriversConstraint> _driversCons;
        public IEnumerable<DriversConstraint> DriversCons
        {
            get => _driversCons;
            set
            {
                _driversCons = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<DataCore.Models.Nsi.Location> _locationFiltr;
        public IEnumerable<DataCore.Models.Nsi.Location> LocationFiltr
        {
            get => _locationFiltr;
            set
            {
                _locationFiltr = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<WorkCondition> _workCons;
        public IEnumerable<WorkCondition> WorkCons
        {
            get => _workCons;
            set
            {
                _workCons = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<AutoClass> _autoClass;
        public IEnumerable<AutoClass> AutoClasses
        {
            get => _autoClass;
            set
            {
                _autoClass = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<DepositRet> _depositRet;
        public IEnumerable<DepositRet> DepositRets
        {
            get => _depositRet;
            set
            {
                _depositRet = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<FirstDay> _firstDays;
        public IEnumerable<FirstDay> FirstDays
        {
            get => _firstDays;
            set
            {
                _firstDays = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<Inspection> _inspections;
        public IEnumerable<Inspection> Inspections
        {
            get => _inspections;
            set
            {
                _inspections = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<MinRentalPeriod> _minRentalPeriods;
        public IEnumerable<MinRentalPeriod> MinRentalPeriods
        {
            get => _minRentalPeriods;
            set
            {
                _minRentalPeriods = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<Waybills> _waybills;
        public IEnumerable<Waybills> Waybills
        {
            get => _waybills;
            set
            {
                _waybills = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<WorkRadius> _workRadii;
        public IEnumerable<WorkRadius> WorkRadii
        {
            get => _workRadii;
            set
            {
                _workRadii = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<TimeSp> _timesp;
        public IEnumerable<TimeSp> TimeSps
        {
            get => _timesp;
            set
            {
                _timesp = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}