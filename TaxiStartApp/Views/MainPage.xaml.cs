using TaxiStartApp.Models;

namespace TaxiStartApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<string> _itemsMenu;
        public ObservableCollection<Item> Items { get; }
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MainViewModel();
            Items = new ObservableCollection<Item> 
            { 
                new Item { Text = "Профиль" },
                new Item { Text = "Подписка" },
                new Item { Text = "Оплата" }
            };  
        }

        public ObservableCollection<string> ItemsMenu { get { return _itemsMenu; } }
    }
}