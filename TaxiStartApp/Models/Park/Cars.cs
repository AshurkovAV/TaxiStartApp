using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Park
{
    public class Cars : INotifyPropertyChanged
    {
        public Cars(int id, string carName, string model, string color, string number, int year, double priceForDay, string shemaName, string className)
        {
            Id = id;
            CarName = carName;
            Model = model;
            Color = color;
            Number = number;
            Year = year;
            PriceForDay = priceForDay;
            ShemaName = shemaName;
            ClassName = className;
        }
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public double PriceForDay { get; set; }
        public string ShemaName { get; set; }
        public string ClassName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
