using Java.Net;
using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TaxiStartApp.Common;

namespace TaxiStartApp.Services
{
    public class HttpClientJob
    {
        private string _url = Constant.UrlGeneralService + "/park";
        private string _urlid = Constant.UrlGeneralService + "/park/id";
        private string _urlcount = Constant.UrlGeneralService + "/park/count";
        private string _urltruncated = Constant.UrlGeneralService + "/park/truncated?";
        private string _urltruncatedTouseid = Constant.UrlGeneralService + "/park/truncated/touser?";
        private string _urltruncatedUser = Constant.UrlGeneralService + "/park/truncated/user?";
        private string _cars = Constant.UrlGeneralService + "/car?";
        private string _carsNav = Constant.UrlGeneralService + "/car/nav?";
        private string _urlcountCar = Constant.UrlGeneralService + "/car/count?";
        private string _urlDriversConstraint = Constant.UrlGeneralService + "/park/DriversConstraint?";
        private string _urlWorkConstraint = Constant.UrlGeneralService + "/park/WorkCondition?";
        private string _urlDriverCreate = Constant.UrlGeneralService + "/driver/create";
        private string _urlOfferCreate = Constant.UrlGeneralService + "/offer/create";
        private string _selectParkCount = Constant.UrlGeneralService + "/selectpark/count?";
        private string _urlSelectParkCreate = Constant.UrlGeneralService + "/selectpark/create";
        private string _urlSelectParkDelete = Constant.UrlGeneralService + "/selectpark/delete";
        private string _urlSelectPark = Constant.UrlGeneralService + "/selectpark/sp?";       

      
        public HttpClientJob() { }

        public async Task<IEnumerable<Park>> GetParksAsync()
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_url);
                var responseFromServer =  httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<Park>>(responseFromServer.Result);
                return result;
            }
            catch(Exception wex) {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<Park>(); }
        }

        public async Task<IEnumerable<ParkTruncated>> GetParksTruncatedAsync(int rows, int page)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urltruncated + $"rows={rows}&page={page}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<ParkTruncated>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<ParkTruncated>();
            }
        }

        public async Task<IEnumerable<ParkTruncated>> GetParksTruncatedToUserIdAsync(int rows, int page, int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urltruncatedTouseid + $"rows={rows}&page={page}&userId={userId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<ParkTruncated>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<ParkTruncated>();
            }
        }

        public async Task<IEnumerable<ParkTruncated>> GetParksTruncatedAsync(int rows, int page, int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urltruncatedUser + $"rows={rows}&page={page}&userid={userId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<ParkTruncated>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<ParkTruncated>();
            }
        }

        public async Task<int> GetSelectParkCountAsync(int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_selectParkCount + $"userid={userId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<int>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return 0;
            }
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(int parkId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_cars + $"parkid={parkId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<Car>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<Car>();
            }
        }

        public async Task<IEnumerable<CarDto>> GetCarsRowPageAsync(int parkId, int rows, int page)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_carsNav + $"parkid={parkId}&rows={rows}&page={page}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<CarDto>();
            }
        }

        public async Task<int> GetParksCountAsync()
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlcount);
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<int>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return 0;
            }
        }

        public async Task<int> GetCarsCountAsync(int parkId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlcountCar + $"parkid={parkId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<int>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return 0;
            }
        }

        public async Task<IEnumerable<int>> GetIdParksAsync()
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlid);
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<int>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<int>();
            }
        }

        public async Task<IEnumerable<DriversConstraintTruncated>> GetParksDriversConstraintAsync(string parkGuid)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlDriversConstraint + $"parkGuid={parkGuid}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<DriversConstraintTruncated>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<DriversConstraintTruncated>();
            }
        }       

        

        public async Task<IEnumerable<WorkConditionTruncated>> GetParksWorkConditionTruncatedAsync(string parkGuid)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlWorkConstraint + $"parkGuid={parkGuid}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<WorkConditionTruncated>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<WorkConditionTruncated>();
            }
        }

        public async Task<string> CreateDriver(DriverDto driverDto)
        {
            WebRequest request = WebRequest.Create(_urlDriverCreate);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(driverDto);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string dataStream = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return dataStream;
        }

        public async Task<string> CreateOffer(OfferDto offer)
        {
            WebRequest request = WebRequest.Create(_urlOfferCreate);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(offer);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string dataStream = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return dataStream;
        }

        public async Task<string> CreateSelectPark(SelectParkDto selectParkDto)
        {
            WebRequest request = WebRequest.Create(_urlSelectParkCreate);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(selectParkDto);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string dataStream = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return dataStream;
        }

        public async Task<string> DeleteSelectPark(SelectParkDto selectParkDto)
        {
            WebRequest request = WebRequest.Create(_urlSelectParkDelete);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(selectParkDto);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string dataStream = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return dataStream;
        }

        public async Task<SelectParkDto> GetSelectParks(int selectparkid, int userid)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlSelectPark + $"selectParkId={selectparkid}&userId={userid}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<SelectParkDto>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new SelectParkDto();
            }
        }
    }
}
