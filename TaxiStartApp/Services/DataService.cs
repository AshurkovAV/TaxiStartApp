using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;

namespace TaxiStartApp.Services
{
    public class DataService: IDataService
    {
        public DataService() { }

        public Driver CreateDrivers(DriverDto driverDto) 
        {
            HttpClientJob httpClientJob = new HttpClientJob();
            var driver = httpClientJob.CreateDriver(driverDto);

            var result = JsonConvert.DeserializeObject<Driver>(driver.Result);
            return result;
        }

        public Offer CreateOffer(OfferDto offer)
        {
            HttpClientJob httpClientJob = new HttpClientJob();
            var resultOffer = httpClientJob.CreateOffer(offer);

            var result = JsonConvert.DeserializeObject<Offer>(resultOffer.Result);
            return result;
        }
    }
}
