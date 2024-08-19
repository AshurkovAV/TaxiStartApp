using JobTaxi.Entity.Dto;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http.Interface;

namespace TaxiStartApp.Services.Http.User
{
    public class FilterHttp: IHttp
    {
        private BaseDto _data;
        private HttpClientJob _httpClientJob = new HttpClientJob();
        public FilterHttp(BaseDto data)
        {
            _data = data;
        }
        public BaseDto GetObject()
        {
            return _data;
        }
        public string GetUrl()
        {
            return Constant.UrlGeneralService + "/user/usersfilter/create";
        }
        public void PostCreate() {
            var result = _httpClientJob.POSTCreateHttpUnivers(this);
        }

    }
}
