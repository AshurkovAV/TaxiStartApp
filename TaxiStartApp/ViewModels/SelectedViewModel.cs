using System.Windows.Input;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;

namespace TaxiStartApp.ViewModels
{
    public class SelectedViewModel : ViewModelBase
    {
        bool isLoading;
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 4;
        public int SourceSize
        {
            get => sourceSize;
            set
            {
                sourceSize = value;
                RaisePropertyChanged();
            }
        }
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
        public ICommand LoadMoreCommand { get; set; }
        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand
        {
            get { return pullToRefreshCommand; }
            set
            {
                if (pullToRefreshCommand != value)
                {
                    pullToRefreshCommand = value;
                    RaisePropertyChanged("PullToRefreshCommand");
                }
            }
        }
        public SelectedViewModel()
        {
            TaxiParkData = new List<ContactTaxiPark>();
            DataStorage._batchSize = loadBatchSize;
            LoadDataAsync();
            LoadMoreCommand = new Command(LoadMore);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);

        }
        void ExecutePullToRefreshCommand()
        {
            Task.Run(() => {
                SourceSize = DataStorage.GetTotalCount(Constant.yandexProfil.id);
                lastLoadedIndex = 1;
                TaxiParkData = new List<ContactTaxiPark>();
                IsLoading = false;
                //LoadTaxi();
            });
        }
        public async Task LoadDataAsync()
        {            
            await Task.Run(() =>
            {
                SourceSize = DataStorage.GetTotalCount(Constant.yandexProfil.id);
                if (SourceSize > 0)
                {
                    IsVisibleGrid = false;
                }                                
            });
        }
        public void LoadTaxi()
        {
            IEnumerable<ContactTaxiPark> newContactTaxiPark = null;
            DataStorage._startIndex = lastLoadedIndex;
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
            if (sourceSize > 0)
            {
                isVisibleGrid = false;
            }
            IsLoading = false;
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
            return TaxiParkData?.Count < SourceSize;
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
        private bool isVisibleGrid = true;
        
        public bool IsVisibleGrid
        {
            get => isVisibleGrid;
            set
            {
                isVisibleGrid = value;
                RaisePropertyChanged();
            }
        }
    }
}