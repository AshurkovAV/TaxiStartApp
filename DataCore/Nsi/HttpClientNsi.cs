using DataCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace DataCore.Nsi
{
    public class HttpClientNsi<T> : IHttpClientNsi<T>        
    {
        private readonly IHttpClientTs _httpClientTs;

        public HttpClientNsi(IHttpClientTs httpClientTs)
        {
            _httpClientTs = httpClientTs;
        }
        public HttpClientNsi()
        {   
        }
        public async Task<IEnumerable<T>> GetNsi()
        {
            try
            {
                
                Type type = typeof(T);                 
                _httpClientTs.Url = Constant.UrlGeneralService + "/nsi/" + type.Name;
                var responseFromServer = _httpClientTs.Get();
                //byte[] byteArray = Encoding.UTF8.GetBytes(responseFromServer.Result);
                //using (Stream stream = new MemoryStream(byteArray))
                //{
                //    var result1 = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>(stream);
                //    return result1;
                //}

                var result = JsonConvert.DeserializeObject<IEnumerable<T>>(responseFromServer);
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
