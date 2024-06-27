using JobTaxi.Entity.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Nsi
{
    public class DriversCon : INotifyPropertyChanged
    {
        public DriversCon(DriversConstraint driversConstraint)
        {
            Id = driversConstraint.Id;
            Name = driversConstraint.Name;
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
