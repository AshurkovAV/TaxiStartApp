using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStartApp.Dto;

namespace TaxiStartApp.Common.OAuth
{
    public class YandexOAuth
    {
        private WebNavigatedEventArgs _e;
        private string _urlYandexOauth = Constant.UrlGeneralService + "/YandexOauth/token?";
        public YandexOAuth(WebNavigatedEventArgs e) 
        {
            _e = e;
        }
        public void OAuth()
        {
            var urlParam = _e.Url.Split('?');
            var httpClient = new HttpClientOAuth($"{_urlYandexOauth + urlParam[1] + $"&deviceId={Constant.DeviceId}"}");
            var responseFromServer = httpClient.GetAsync();
            Constant.UserToken = JsonConvert.DeserializeObject<UserTokenJson>(responseFromServer.Result);

        }
    }
}
