using JobTaxi.Entity.Dto;

namespace TaxiStartApp.Services.Http.Interface
{
    public interface IHttp
    {
        public string GetUrl();      
        public BaseDto GetObject();
    }
}
