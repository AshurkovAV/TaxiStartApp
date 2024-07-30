using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataCore.Models.Nsi
{
    public class Location : INotifyPropertyChanged
    {
        public Location()
        {
            
        }
        public int Id { get; set; }

        public string OblName { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
