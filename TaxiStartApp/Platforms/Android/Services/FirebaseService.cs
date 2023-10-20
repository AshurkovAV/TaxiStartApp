//using Android.App;
//using Firebase.Messaging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaxiStartApp.Platforms.Android.Services
//{
//    [Service (Exported = true)]
//    [IntentFilter(new[] {"com.google.firebase.MESSEGING_EVENT"})]
//    public class FirebaseService: FirebaseMessagingService
//    {
//        public FirebaseService()
//        { }

//        public override void OnNewToken(string token)
//        {
//            base.OnNewToken(token);
//            if (Preferences.ContainsKey("DeviceToken"))
//            {
//                Preferences.Remove("DeviceToken");
//            }
//            Preferences.Set("DeviceToken", token);
//        }
//    }
//}
