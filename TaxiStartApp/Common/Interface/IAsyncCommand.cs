using System.Windows.Input;

namespace TaxiStartApp.Common.Interface
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
