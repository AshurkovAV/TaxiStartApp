using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Menu
{
    public class MenuModel : INotifyPropertyChanged
    {
        public List<MenuItem> Data { get; set; }
        public MenuModel()
        {
            LoadMenu();            
        }

        async void LoadMenu()
        {
            await Task.FromResult(Data = new List<MenuItem>() {
                new MenuItem("Профиль", "profil.png"),
                //new Menu("Оплата", "pay.png"),
                new MenuItem("Подписка" , "sub.png"),
                new MenuItem("Как это работает?", "vosh.png"),
                new MenuItem("Конфиденциальность", "secure.png"),
                new MenuItem("Промокоды", "promo.png"),

            });            
        }

        List<MenuItem> selectedContacts;
        public List<MenuItem> SelectedContacts
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
