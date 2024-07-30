using Android.Widget;
using System.Reflection.Metadata;
using System.Windows.Input;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Models
{
    public class TaxiParkViewModel : ViewModelBase
    {
        bool isLoading;
        bool isRespond;
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 3;
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
        public int SourceSize {
            get => sourceSize;
            set
            {
                sourceSize = value;
                RaisePropertyChanged();
            }
        }
        public ICommand _loadMoreCommand;
        public ICommand LoadMoreCommand {
            get => _loadMoreCommand;
            set
            {
                _loadMoreCommand = value;
                RaisePropertyChanged();
            }
        }
        public ICommand ShareCommand { get; set; }
        public ICommand OpenBlogCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand LikeEmpCommand { get; set; }
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
        


        public TaxiParkViewModel()
        {
            IsLoading = true;
            TaxiParkData = new List<ContactTaxiPark>();
            LoadDataAsync();
            _dataService = DependencyService.Get<IDataService>();
            ShareCommand = new Command<ContactTaxiPark>(ShareBlog);
            OpenBlogCommand = new Command<ContactTaxiPark>(OpenBlog);
            FilterCommand = new Command(Filter);
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }
        void ExecutePullToRefreshCommand()
        {
            Task.Run(() => {
                SourceSize = DataStorage.GetTotalCount();
                lastLoadedIndex = 1;
                TaxiParkData = new List<ContactTaxiPark>();
                IsLoading = false;
               // LoadTaxi();
            });
        }
        public void LoadDataAsync()
        {           
            Task.Run(() =>
            {
                SourceSize = DataStorage.GetTotalCount();
                IsLoading = false;
            });            
        }

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
        public async void ShareBlog(ContactTaxiPark blog)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {                
                Title = "Share the Blog With your Friends"
            });
        }
        string filterGlyph = "&#xf0b0;";
        public string FilterGlyph
        {
            get => this.filterGlyph;
            set
            {
                this.filterGlyph = value;
                RaisePropertyChanged();
            }
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
        public async void OpenBlog(ContactTaxiPark blog)
        {
            Dictionary<string, object> parameters = new() {
            { "Settings", blog }
                };
            Common.Constant.ShareParkId = blog.Id;
            Common.Constant.ShareParkGuid = blog.ParkGuid;
            Common.Constant.ShareParkCountDrive = blog.ParkTrun.CountDrive;
            Common.Constant.ShareParkCountWork = blog.ParkTrun.CountWork;
            Common.Constant.ShareParkCountCar = blog.ParkTrun.CountCars;
            await Shell.Current.GoToAsync("EditContactPage", parameters);
        }
        public async void Filter()
        {           
            await Shell.Current.GoToAsync("FilterPage");
        }

        List<ContactTaxiPark> selectedContacts;
        public List<ContactTaxiPark> SelectedContacts
        {
            get { return selectedContacts; }
            set
            {
                if (selectedContacts != value)
                {
                    selectedContacts = value;
                }
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

        
    }


    
}
