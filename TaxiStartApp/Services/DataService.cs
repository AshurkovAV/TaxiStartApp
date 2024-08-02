using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Data.Park;
using TaxiStartApp.Models.Park;

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

        public SelectPark CreateSelectPark(SelectParkDto selectParkDto)
        {
            HttpClientJob httpClientJob = new HttpClientJob();
            var resultOffer = httpClientJob.CreateSelectPark(selectParkDto);

            var result = JsonConvert.DeserializeObject<SelectPark>(resultOffer.Result);
            return result;
        }

        public bool DeleteSelectPark(SelectParkDto selectParkDto)
        {
            HttpClientJob httpClientJob = new HttpClientJob();
            var resultOffer = httpClientJob.DeleteSelectPark(selectParkDto);

            var result = JsonConvert.DeserializeObject<bool>(resultOffer.Result);
            return result;
        }

        public bool RespondToRequest(int? parkId = null)
        {            
            try
            {
                var driver = CreateDrivers(new JobTaxi.Entity.Dto.DriverDto
                {
                    Fam = Constant.yandexProfil.lastName,
                    Im = Constant.yandexProfil.firstName,
                    Phone = Constant.yandexProfil.defaultPhone,
                });
                var offer = CreateOffer(new JobTaxi.Entity.Dto.OfferDto
                {
                    DriverId = driver.Id,
                    ParkId = parkId != null? (int)parkId: Constant.ShareParkId
                });               
                return true;
            } 
            catch { return false; }
            
        }

        public UsersFilterDto CreateUserFilter(UsersFilterDto usersFilterDto)
        {
            try
            {
                HttpClientJob httpClientJob = new HttpClientJob();
                var resultOffer = httpClientJob.CreateFilter(usersFilterDto);

                var result = JsonConvert.DeserializeObject<UsersFilterDto>(resultOffer.Result);
                return result;
            }
            catch(Exception ex) 
            { }
            return null;
            
        }
    }
}
