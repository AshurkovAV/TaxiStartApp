using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using TaxiStartApp.Common.Interface;
using TaxiStartApp.Common.OAuth;
using TaxiStartApp.Views;

namespace TaxiStartApp;

public partial class AppShell : Shell
{
	private string _token;
	public AppShell()
	{
		InitializeComponent();

        if (Preferences.ContainsKey("DeviceToken"))
        {
            _token = Preferences.Get("DeviceToken", "");
        }

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(TelefonPage), typeof(TelefonPage));
        Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        Routing.RegisterRoute(nameof(VerificationPage), typeof(VerificationPage));
        Routing.RegisterRoute("MainPage/ProfilPage", typeof(ProfilPage));
        Routing.RegisterRoute("EditBioPage/ProfilPage", typeof(ProfilPage));
        Routing.RegisterRoute("ProfilPage/EditBioPage", typeof(EditBioPage));
        Routing.RegisterRoute("ContactPage/EditContactPage", typeof(EditContactPage));
        Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
        Routing.RegisterRoute(nameof(SelectedPage), typeof(SelectedPage));
        Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));


        try
        {
            var fileHelper = DependencyService.Get<IFileHelper>();
            var accessToken = fileHelper.LoadFile();
            if (accessToken.Exception == null)
            {
                YandexProfil yandexProfil = new YandexProfil();
                yandexProfil.Get(accessToken.Result);
                this.CurrentItem = mainpage;
            }
            else
            {
                this.CurrentItem = loginpage;
            }
        } catch { }
    }

	private async void ReadFireBaseAdminSdk()
	{
		var stream = await FileSystem.OpenAppPackageFileAsync("start-797ab-firebase-adminsdk-715ut-40e9483c42.json");
		var reader = new StreamReader(stream);

		var json = reader.ReadToEnd();

		if (FirebaseMessaging.DefaultInstance == null)
		{
			FirebaseApp.Create(new AppOptions()
			{
				Credential = GoogleCredential.FromJson(json)
			});
		}

	}
}
