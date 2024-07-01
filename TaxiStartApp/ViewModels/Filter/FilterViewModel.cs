using DataCore.Data.Nsi;
using DataCore.Models.Nsi;
using System.Collections.Specialized;
using System.Windows.Input;
using TaxiStartApp.Models;

namespace TaxiStartApp.ViewModels
{
    public class FilterViewModel : ViewModelBase
    {
        public FilterViewModel()
        {
            NsiDriversSelect.CollectionChanged += OnBlacklistCollectionChanged;
            NsiWorkSelect.CollectionChanged += OnWorklistCollectionChanged;
            Load();
        }

        private void Load()
        {
            Task.Run(() => {
                DriversCons = DriversConstrainStorage.GetBlogs();
                WorkCons = WorkConditionStorage.GetBlogs();
            });
        }

        private List<WorkCon> _workCons;
        public List<WorkCon> WorkCons
        {
            get => _workCons;
            set
            {
                _workCons = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<WorkCon> NsiWorkSelect { get; } = new();
        void OnWorklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(NsiWorkSelect));
        }
        public ObservableCollection<DriversCon> NsiDriversSelect { get; } = new();
        void OnBlacklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(NsiDriversSelect));
        }
        private List<DriversCon> _driversCons;
        public List<DriversCon> DriversCons
        {
            get => _driversCons;
            set
            {
                _driversCons = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}