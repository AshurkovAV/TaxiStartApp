using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataCore.Models.Nsi
{
    public class Inspection : INotifyPropertyChanged
    {
        public Inspection()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
       

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
