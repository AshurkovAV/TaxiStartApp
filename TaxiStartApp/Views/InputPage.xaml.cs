using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage : ContentPage
    {
        private readonly ObservableCollection<string> _itemsMenu;
        public InputPage()
        {
            InitializeComponent();
            _itemsMenu = new ObservableCollection<string> { "Профиль", "Подписка", "Оплата"};
            //BindingContext = new AboutViewModel();
        }

        public ObservableCollection<string> ItemsMenu { get { return _itemsMenu; } }
    }
}