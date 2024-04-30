using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
