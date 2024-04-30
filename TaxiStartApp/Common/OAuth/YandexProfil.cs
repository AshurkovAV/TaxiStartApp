using Newtonsoft.Json;

namespace TaxiStartApp.Common.OAuth
{
    public class YandexProfil
    {
        private readonly string _urlYandexProfil = "https://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai/YandexOauth/login/info";
        public YandexProfil() { }

        public async void Get(string token)
        {
            HttpClientOAuth httpClientOAuth = new HttpClientOAuth(_urlYandexProfil + 
                $"?code={Constant.TokenService}&token={token}&deviceId={Constant.DeviceId}");
            string responseBody = await httpClientOAuth.GetAsync();

            Constant.yandexProfil = JsonConvert.DeserializeObject<YandexProfil>(responseBody);            
        }

        public string id { get; set; }
        public string idYandex { get; set; }
        public string login { get; set; }
        public string clientId { get; set; }
        public string displayName { get; set; }
        public string realName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sex { get; set; }
        public string defaultEmail { get; set; }        
        public string birthday { get; set; }
        public string defaultAvatarId { get; set; }
        public bool isAvatarEmpty { get; set; }
        public string defaultPhone { get; set; }        
        public string deviceId { get; set; }

    }
}
