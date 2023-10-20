using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStartApp.Models
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Contact> Data { get; }
        public ViewModel()
        {
            Data = new List<Contact>() {
                new Contact("ВОДЫ", "(206) 555-9857"),
                new Contact("Люберцы", "(206) 555-9482"),
                new Contact("Хаврино", "(206) 555-3412"),
                new Contact("Чертаново", "(206) 555-8122"),
                new Contact("Нижегородская", "(71) 555-4848"),
                new Contact("Пушкино", "(71) 555-7773"),
                new Contact("Полежаевская", "(71) 555-5598"),
                new Contact("Аэропорт метро", "(206) 555-1189"),
                new Contact("Энтузиастов / МСД", "(71) 555-4444"),
                new Contact("Строгино", "(71) 555-4444"),
                new Contact("Соколиная гора,Партизанская", "(71) 555-4444"),
                new Contact("Питерский Марьино", "(71) 555-4444"),
            };
            
        }
        
        List<Contact> selectedContacts;
        public List<Contact> SelectedContacts
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
