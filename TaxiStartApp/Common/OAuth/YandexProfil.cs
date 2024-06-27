using Newtonsoft.Json;
using TaxiStartApp.Common.Interface;

namespace TaxiStartApp.Common.OAuth
{
    public class YandexProfil
    {
        //private readonly string _urlYandexProfil = "https://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai/YandexOauth/login/info";
        private readonly string _urlYandexProfil = Constant.UrlGeneralService + "/YandexOauth/login/info";
        IHttpClientTs _httpClientTs;
        public YandexProfil() {
            var httpClientTs = DependencyService.Get<IHttpClientTs>();
            _httpClientTs = httpClientTs;
        }

        public async void Get(string token)
        {
            try
            {
                HttpClientOAuth httpClientOAuth = new HttpClientOAuth(_urlYandexProfil +
                    $"?code={Constant.TokenService}&token={token}&deviceId={Constant.DeviceId}");
                var responseBody = await httpClientOAuth.GetStStatusAsync();
                if(responseBody.Item2 == System.Net.HttpStatusCode.OK)
                { 
                    Constant.yandexProfil = JsonConvert.DeserializeObject<YandexProfil>(responseBody.Item1);
                    //var avat = await _httpClientTs.GetAvat();
                    //Constant.yandexProfil.Avatar = ImageSource.FromStream(() => avat);
                }
                
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public int id { get; set; }
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
        public ImageSource? Avatar { get; set; }

    }
}
