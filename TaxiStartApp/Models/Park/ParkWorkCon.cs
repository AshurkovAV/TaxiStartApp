using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Park
{
    public class ParkWorkCon : INotifyPropertyChanged
    {
        public ParkWorkCon(WorkConditionTruncated workConditionTruncated)
        {
            Id = workConditionTruncated.Id;
            WorkName = workConditionTruncated.WorkName;
        }
        public int Id { get; set; }
        public string WorkName { get; set; }
       

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
