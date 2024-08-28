using JobTaxi.Entity.Dto;
using Newtonsoft.Json;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http.Interface;

namespace TaxiStartApp.Services.Http.Park
{
    public class ParkHttp: BaseHttp, IHttp
    {
        private string _urlcount = Constant.UrlGeneralService + "/park/count";
        private HttpClientJob _httpClientJob = new HttpClientJob();
        private BaseDto _data;
        public BaseDto GetObject()
        {
            return _data;
        }
        public string GetUrl()
        {
            return Url;
        }
        public BaseDto SetObject { set{ _data = value; } }
        public async Task<int> PostCount(){
            Url = _urlcount;
            var result = await _httpClientJob.POSTCreateHttpUnivers(this);
            return JsonConvert.DeserializeObject<int>(result);
        }        
    }
}
