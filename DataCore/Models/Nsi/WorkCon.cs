using JobTaxi.Entity.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataCore.Models.Nsi
{
    public class WorkCon : INotifyPropertyChanged
    {
        public WorkCon(WorkCondition workCondition)
        {
            Id = workCondition.Id;
            Name = workCondition.Name;
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
