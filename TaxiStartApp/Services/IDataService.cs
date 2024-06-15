using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;

namespace TaxiStartApp.Services
{
    public interface IDataService
    {
        public Driver CreateDrivers(DriverDto driverDto);

        public Offer CreateOffer(OfferDto offerDto);
    }
}
