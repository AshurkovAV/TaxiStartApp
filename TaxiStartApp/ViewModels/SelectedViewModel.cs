using DevExpress.Maui.Controls;
using System.Windows.Input;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Common.Data.User;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Models.User;


namespace TaxiStartApp.ViewModels
{
    public class SelectedViewModel : ViewModelBase
    {
        bool isLoading;
        bool isLoadingSubscription;
        int lastLoadedIndex = 1;
        int sourceSize = 0; 
        int sourceSizeSubscription = 0;
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

        public int SourceSizeSubscription
        {
            get => sourceSizeSubscription;
            set
            {
                sourceSizeSubscription = value;
                RaisePropertyChanged();
            }
        }

        private List<Subscription> _subscription;
        public List<Subscription> SubscriptionData
        {
            get => _subscription;
            set
            {
                _subscription = value;
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
        
        public ICommand LoadSubscriptionCommand { get; set; }
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

        ICommand pullSubToRefreshCommand = null;
        public ICommand PullSubToRefreshCommand
        {
            get { return pullSubToRefreshCommand; }
            set
            {
                if (pullSubToRefreshCommand != value)
                {
                    pullSubToRefreshCommand = value;
                    RaisePropertyChanged("PullSubToRefreshCommand");
                }
            }
        }
        public SelectedViewModel()
        {
            TaxiParkData = new List<ContactTaxiPark>();
            SubscriptionData = new List<Subscription>();
            DataStorage._batchSize = loadBatchSize;
            LoadDataAsync();
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
            LoadSubscriptionCommand = new Command(LoadSub, CanLoadSub);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
            PullSubToRefreshCommand = new Command(ExecutePullSubToRefreshCommand);           
           
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
        void ExecutePullSubToRefreshCommand()
        {
            Task.Run(() => {
                SourceSizeSubscription = DataSubscription.GetTotalCount(Constant.yandexProfil.id);
                SubscriptionData = new List<Subscription>();
                IsLoadingSubscription = false;
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
                SourceSizeSubscription = DataSubscription.GetTotalCount(Constant.yandexProfil.id);
            });
        }

        public void LoadSubscription()
        {
            IEnumerable<Subscription> newSubscription = null;
            newSubscription = DataSubscription.GetBlogs(Common.Constant.yandexProfil.id);
            SubscriptionData.AddRange(newSubscription);
            IsLoadingSubscription = false;
        }
        public void LoadTaxi()
        {
            IEnumerable<ContactTaxiPark> newContactTaxiPark = null;
            DataStorage._startIndex = lastLoadedIndex;
            newContactTaxiPark = DataStorage.GetBlogs(Common.Constant.yandexProfil.id);
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
        public void LoadSub()
        {
            Task.Run(() =>
            {
                LoadSubscription();
            });
        }
        

        public bool CanLoadMore()
        {
            return TaxiParkData?.Count < SourceSize;
        }

        public bool CanLoadSub()
        {
            return SubscriptionData?.Count < SourceSizeSubscription;
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

        public bool IsLoadingSubscription
        {
            get => isLoadingSubscription;
            set
            {
                isLoadingSubscription = value;
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