using System.Reflection.Metadata;
using System.Windows.Input;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models.Park;

namespace TaxiStartApp.Models
{
    public class TaxiParkViewModel : ViewModelBase
    {
        bool isLoading;
        int lastLoadedIndex = 1;
        int sourceSize = 0;
        int loadBatchSize = 3;
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
        public ICommand ShareCommand { get; set; }
        public ICommand OpenBlogCommand { get; set; }  

        public TaxiParkViewModel()
        {
            IsLoading = true;
            LoadDataAsync();
            LoadMoreCommand = new Command(LoadMore, CanLoadMore);
            ShareCommand = new Command<ContactTaxiPark>(ShareBlog);
            OpenBlogCommand = new Command<ContactTaxiPark>(OpenBlog);
            
        }
        public async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {                
                sourceSize = DataStorage.GetTotalCount();
                TaxiParkData = new List<ContactTaxiPark>();
                LoadTaxiPark();
            });
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
        public async void LoadTaxiPark()
        {
            IEnumerable<ContactTaxiPark> newContactTaxiPark = null;
            await Task.Run(() =>
            {   
                DataStorage._startIndex = lastLoadedIndex;
                DataStorage._batchSize = loadBatchSize;
                newContactTaxiPark = DataStorage.GetBlogs();
                
            });
            TaxiParkData.AddRange(newContactTaxiPark);
            IsLoading = false;                       
        }        
        public void LoadMore()
        {
            LoadTaxiPark();
            lastLoadedIndex += 1;
        }
        public bool CanLoadMore()
        {
            return TaxiParkData?.Count < sourceSize;
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

        public async void OpenBlog(ContactTaxiPark blog)
        {
            Dictionary<string, object> parameters = new() {
            { "Settings", blog }
                };
            Common.Constant.ShareParkId = blog.Id;
            Common.Constant.ShareParkGuid = blog.ParkGuid;
            await Shell.Current.GoToAsync("EditContactPage", parameters);
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
    }


    
}
