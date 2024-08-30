using System.Windows.Input;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        public const string ViewName = "MapPage";
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 2;
        private IDataService _dataService;
        private List<ContactTaxiPark> _taxiParkData;
        public List<ContactTaxiPark> TaxiParkData
        {
            get => _taxiParkData;
            set
            {
                _taxiParkData = value;
                RaisePropertyChanged();
            }
        }
        public int SourceSize
        {
            get => sourceSize;
            set
            {
                sourceSize = value;
                RaisePropertyChanged();
            }
        }
        public ICommand _loadMoreCommand;
        public ICommand LoadMoreCommand
        {
            get => _loadMoreCommand;
            set
            {
                _loadMoreCommand = value;
                RaisePropertyChanged();
            }
        }
        public MapViewModel()
        {
            TaxiParkData = new List<ContactTaxiPark>();
            LoadDataAsync();
            _dataService = DependencyService.Get<IDataService>();
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
        }
        bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    RaisePropertyChanged("IsLoading");
                }
            }
        }
        public void LoadDataAsync()
        {
            Task.Run(() =>
            {
                SourceSize = DataStorage.GetTotalCount();
                IsLoading = false;
            });
        }

        public async void LoadTaxiPark()
        {
            await Task.Run(() =>
            {
                LoadTaxi();
            });

        }
        public void LoadMore()
        {
            LoadTaxiPark();
        }
        public bool CanLoadMore()
        {
            return TaxiParkData.Count < SourceSize;
        }

        public void LoadTaxi()
        {
            IEnumerable<ContactTaxiPark> newContactTaxiPark = null;
            DataStorage._startIndex = lastLoadedIndex;
            DataStorage._batchSize = loadBatchSize;
            newContactTaxiPark = DataStorage.GetBlogsToUser(Common.Constant.yandexProfil.id);
            foreach (var item in newContactTaxiPark)
            {
                if (item.ParkTrun.SelectPark > 0)
                {
                    item.Grid1Visible = false;
                    item.Grid2Visible = true;
                }
                else
                {
                    item.Grid1Visible = true;
                    item.Grid2Visible = false;
                }
            }
            TaxiParkData.AddRange(newContactTaxiPark);
            lastLoadedIndex += 1;
            IsLoading = false;
        }
    }
}