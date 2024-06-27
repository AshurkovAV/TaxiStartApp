using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;

namespace TaxiStartApp.Services
{
    public interface IDataService
    {
        public Driver CreateDrivers(DriverDto driverDto);

        public Offer CreateOffer(OfferDto offerDto);
        public SelectPark CreateSelectPark(SelectParkDto selectParkDto);
        public bool DeleteSelectPark(SelectParkDto selectParkDto);
        public bool RespondToRequest(int? parkId = null);
    }
}
