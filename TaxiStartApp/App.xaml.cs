using System.Runtime.ExceptionServices;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Bot;
using TaxiStartApp.Common.Helper;
using TaxiStartApp.Common.Interface;
using TaxiStartApp.Services;
using TaxiStartApp.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace TaxiStartApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           // AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<IFileHelper, FileHelper>();
            DependencyService.Register<IHttpClientTs, HttpClientTs>();
           // DependencyService.Register<IPermissionsCheck, PermissionsCheck>();

            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
            
            MainPage = new AppShell();

            //CrossFirebasePushNotification.Current.OnTokenRefresh += Curren_onToken;
            // Use the NavigateToAsync<ViewModelName> method
            // to display the corresponding view.
            // Code lines below show how to navigate to a specific page.
            // Comment out all but one of these lines
            // to open the corresponding page.
            //var navigationService = DependencyService.Get<INavigationService>();
            //navigationService.NavigateToAsync<LoginViewModel>(true);
        }
        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
           // BotInfo.BotInfoTo($"SMS {DateTime.Now} \n" + e?.Exception?.Message + "\n");            
        }
        //private void Curren_onToken(object ob, FirebasePushNotificationTokenEventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Token {e.Token}" );
        //}
    }
}
