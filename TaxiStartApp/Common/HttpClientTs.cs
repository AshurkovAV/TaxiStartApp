namespace TaxiStartApp.Common
{
    public class HttpClientTs
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
    }
}
