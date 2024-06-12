using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Park
{
    public class ParkDriversCon : INotifyPropertyChanged
    {
        public ParkDriversCon(DriversConstraintTruncated parksDriversConstraint)
        {
            Id = parksDriversConstraint.Id;
            DriverName = parksDriversConstraint.DriveName;
        }
        public int Id { get; set; }
        public string DriverName { get; set; }
       

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
