using System.Windows.Input;

namespace TaxiStartApp.ViewModels
{
    public class UslViewModel : BaseViewModel
    {
        public const string ViewName = "UslPage";
        public UslViewModel()
        {
            Title = "Условия использования сервиса";            
        }

        public ICommand OpenWebCommand { get; }
    }
}