using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using TaxiStartApp.Common;
using TaxiStartApp.Models.User;
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
        public UsersFilterDto PostCreate() {
            var result = _httpClientJob.POSTCreateHttpUnivers(this);
            return JsonConvert.DeserializeObject<UsersFilterDto>(result.Result);
        }

    }
}
