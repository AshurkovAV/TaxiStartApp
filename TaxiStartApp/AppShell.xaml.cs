using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
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
        ReadFireBaseAdminSdk();


        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(TelefonPage), typeof(TelefonPage));
        Routing.RegisterRoute(nameof(VerificationPage), typeof(VerificationPage));
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
