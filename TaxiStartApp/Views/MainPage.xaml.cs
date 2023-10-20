using System.Runtime.CompilerServices;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}