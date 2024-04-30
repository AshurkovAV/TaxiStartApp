using DevExpress.Maui.Controls;
using TaxiStartApp.Common;
using TaxiStartApp.Common.OAuth;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            label.HorizontalTextAlignment = TextAlignment.Center;
            
            Connectivity.ConnectivityChanged += Current_ConnectivityChanged;            
        }       

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            bottomSheet.State = BottomSheetState.HalfExpanded;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {            
            bottomSheet.State = BottomSheetState.HalfExpanded;
            web.Source = $"https://oauth.yandex.ru/authorize?response_type=code&client_id=36d513472d924ea2901401d51958bc5c&device_id={Constant.DeviceId}";
        }      

        private async void web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url.StartsWith("https://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai/Oauth?code="))
            {
                try
                {
                    activator.IsRunning = true;
                    YandexOAuth yandexOAuth = new YandexOAuth(e);
                    yandexOAuth.OAuth();
                    
                    YandexProfil yandexProfil = new YandexProfil();
                    yandexProfil.Get(Constant.UserToken.accessToken);

                    await DisplayAlert("Добро пожаловать", Constant.yandexProfil?.realName + "\n" + Constant.yandexProfil?.defaultEmail, "OK");
                    bottomSheet.State = BottomSheetState.Hidden;
                    OnDriverClicked();
                }
                catch (Exception ex)
                {
                    activator.IsRunning = false;
                    await DisplayAlert("Внимание", "Сервис авторизации не доступен. Попробуйте через телефон", "OK");
                }
                activator.IsRunning = false;
            }            
        }       

        async void OnDriverClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckConnection();
        }
        // получаем состояние подключения
        private void CheckConnection()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                bottomSheetConnection.IsVisible = true;
                bottomSheetConnection.State = BottomSheetState.HalfExpanded;
            }
            else
            {
                bottomSheetConnection.IsVisible = false;
                bottomSheetConnection.State = BottomSheetState.Hidden;
            }
        }

        // обработка изменения состояния подключения
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckConnection();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CheckConnection();
        }
    }
}