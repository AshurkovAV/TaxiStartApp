using TaxiStartApp.Common.Interface;

namespace TaxiStartApp.Common
{
    public class HttpClientTs: IHttpClientTs
    {
        private string _url;          
        public HttpClientTs() { }
            
        public HttpClientTs(string url) { 
            _url = url;
        }
        public string Url { get { return _url;} }
        public async Task<string> Get() 
        {
            var httpClient = new HttpClientOAuth($"{_url}");             
            var responseFromServer = await httpClient.GetAsync();
            return responseFromServer;
        }

        public async Task<Stream?> GetAvat()
        {
            var httpClient = new HttpClientOAuth($"https://avatars.yandex.net/get-yapic/{Constant.yandexProfil.defaultAvatarId}/islands-300");
            var stream =  await httpClient.GetStreamAsync();
            if (stream.Item2 == System.Net.HttpStatusCode.OK)
            {
                return stream.Item1;
            }
            else
            {
                return null;
            }
        }
    }
}
