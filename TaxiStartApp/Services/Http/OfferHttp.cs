using JobTaxi.Entity.Dto;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http.Interface;

namespace TaxiStartApp.Services.Http
{
    public class OfferHttp : IHttp
    {
        private OfferDto _offerDto;
        public OfferHttp(OfferDto offerDto)
        {
            _offerDto = offerDto;
        }
        public BaseDto GetObject()
        {
            return _offerDto;
        }
        public string GetUrl()
        {
            return Constant.UrlGeneralService + "/offer/create";
        }
    }
}
