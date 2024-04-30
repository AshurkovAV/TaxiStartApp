using Java.Net;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TaxiStartApp.Common;

namespace TaxiStartApp.Services
{
    public class HttpClientJob
    {
        private string _url = "http://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai/park";
        public HttpClientJob() { }

        public async Task<IEnumerable<Park>> GetParksAsync()
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_url);
                var responseFromServer =  httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<Park>>(responseFromServer.Result);
                return result;
            }
            catch(Exception wex) {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<Park>(); }
        }
    }
}
