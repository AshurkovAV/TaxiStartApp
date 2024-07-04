using DataCore.Http;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace DataCore.Nsi
{
    public class HttpClientNsi<T> : IHttpClientNsi<T>        
    {
        private readonly IHttpClientTs _httpClientTs;

        public HttpClientNsi(IHttpClientTs httpClientTs)
        {
            _httpClientTs = httpClientTs;
        }
        public HttpClientNsi(){           
        }
        public async Task<IEnumerable<T>> GetNsi()
        {
            try
            {
                Type type = typeof(T);                 
                _httpClientTs.Url = Constant.UrlGeneralService + "/nsi/" + type.Name;
                var responseFromServer = _httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<T>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<T>();
            }
        }
    }
}
