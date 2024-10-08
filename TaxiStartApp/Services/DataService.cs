﻿using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http;

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
            var resultOffer = httpClientJob.POSTCreateHttpUnivers(new OfferHttp(offer));

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
        

        public SelectAutoClass CreateUserSelectClassAutoFilter(SelectAutoClassDto selectAutoClassDto)
        {
            try
            {
                HttpClientJob httpClientJob = new HttpClientJob();
                var resultData = httpClientJob.CreateUserSelectClassAutoFilter(selectAutoClassDto);

                var result = JsonConvert.DeserializeObject<SelectAutoClass>(resultData.Result);
                return result;
            }
            catch (Exception ex)
            { }
            return null;

        }


        public bool IsPushNotif(int filterId, bool push)
        {
            try
            {
                HttpClientJob httpClientJob = new HttpClientJob();
                var resultdata = httpClientJob.IsPush(filterId, push);
                return resultdata.Result;
            }
            catch (Exception ex)
            { }
            return false;

        }

        public bool DeleteUsersFilter(int id)
        {
            HttpClientJob httpClientJob = new HttpClientJob();
            var resuldata= httpClientJob.DeleteUsersFilter(id);

            var result = resuldata.Result;
            return result;
        }
    }
}
