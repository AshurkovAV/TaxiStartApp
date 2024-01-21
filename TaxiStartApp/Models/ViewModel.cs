using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<ContactTaxiPark> Data { get; set; }
        public ViewModel()
        {
            LoadTaxiPark();            
        }

        async void LoadTaxiPark()
        {
            await Task.FromResult(Data = new List<ContactTaxiPark>() {
                new ContactTaxiPark("ВОДЫ1", "(206) 555-9857"),
                new ContactTaxiPark("Люберцы", "(206) 555-9482"),
                new ContactTaxiPark("Хаврино", "(206) 555-3412"),
                new ContactTaxiPark("Чертаново", "(206) 555-8122"),
                new ContactTaxiPark("Нижегородская", "(71) 555-4848"),
                new ContactTaxiPark("Пушкино", "(71) 555-7773"),
                new ContactTaxiPark("Полежаевская", "(71) 555-5598"),
                new ContactTaxiPark("Аэропорт метро", "(206) 555-1189"),
                new ContactTaxiPark("Энтузиастов / МСД", "(71) 555-4444"),
                new ContactTaxiPark("Строгино", "(71) 555-4444"),
                new ContactTaxiPark("Соколиная гора,Партизанская", "(71) 555-4444"),
                new ContactTaxiPark("Питерский Марьино", "(71) 555-4444"),
            });            
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
