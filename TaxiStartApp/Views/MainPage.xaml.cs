namespace TaxiStartApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<string> _itemsMenu;
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MainViewModel();
            _itemsMenu = new ObservableCollection<string> { "Профиль", "Подписка", "Оплата" };
        }

        public ObservableCollection<string> ItemsMenu { get { return _itemsMenu; } }
    }
}