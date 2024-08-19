using Java.Net;
using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http.Interface;

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
        private string _urlSelectPark1 = Constant.UrlGeneralService + "/selectpark?";
        private string _urlFilterUserCreate = Constant.UrlGeneralService + "/user/usersfilter/create";
        private string _urlcountFilterUser = Constant.UrlGeneralService + "/user/usersfilter/count?";
        private string _urlFilterUserToId = Constant.UrlGeneralService + "/user/usersfilter/us?";
        private string _urlFilterIsPush = Constant.UrlGeneralService + "/user/usersfilter/ispush?";
        private string _urlFilterUserDelete = Constant.UrlGeneralService + "/user/usersfilter/delete?";
        private string _urlSelectAutoClass = Constant.UrlGeneralService + "/SelectAutoClass?";
        private string _urlSelectLocationFilter = Constant.UrlGeneralService + "/SelectLocationFilter?";
        private string _urlFilterUserSelectAutoClassCreate = Constant.UrlGeneralService + "/SelectAutoClass/create";
        private string _urlFilterUserSelectLocationCreate = Constant.UrlGeneralService + "/SelectLocationFilter/create";

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

        public async Task<IEnumerable<SelectParkDto>> GetSelectParksToUserIdAsync(int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlSelectPark1 + $"userId={userId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<SelectParkDto>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<SelectParkDto>();
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

        public async Task<IEnumerable<UsersFilterDto>> GetFilterUserToIdAsync(int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlFilterUserToId + $"userid={userId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<IEnumerable<UsersFilterDto>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<UsersFilterDto>();
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

        public async Task<int> GetFilterCountAsync(int userId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlcountFilterUser + $"userid={userId}");
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

        public async Task<bool> DeleteUsersFilter(int id)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlFilterUserDelete + $"id={id}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<bool>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return false;
            }
        }


        public async Task<string> CreateFilter(UsersFilterDto usersFilterDto)
        {
            WebRequest request = WebRequest.Create(_urlFilterUserCreate);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(usersFilterDto);
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

        public async Task<string> CreateUserSelectClassAutoFilter(SelectAutoClassDto selectAutoClassDto)
        {
            WebRequest request = WebRequest.Create(_urlFilterUserSelectAutoClassCreate);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(selectAutoClassDto);
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

        public async Task<string> POSTCreateHttpUnivers(IHttp http)
        {
            WebRequest request = WebRequest.Create(http.GetUrl());
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            var json = JsonConvert.SerializeObject(http.GetObject());
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

        public async Task<bool> IsPush(int id, bool push)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlFilterIsPush + $"id={id}&push={push}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<bool>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return false;
            }
        }


        public async Task<List<SelectLocationFilter>> GetSelectLocationFilter(int userId, int filterId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlSelectLocationFilter + $"userId={userId}&filterId={filterId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<List<SelectLocationFilter>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<SelectLocationFilter>();
            }
        }

        public async Task<List<SelectAuto>> GetSelectAutoClass(int userId, int filterId)
        {
            try
            {
                HttpClientTs httpClientTs = new HttpClientTs(_urlSelectAutoClass + $"userId={userId}&filterId={filterId}");
                var responseFromServer = httpClientTs.Get();
                var result = JsonConvert.DeserializeObject<List<SelectAuto>>(responseFromServer.Result);
                return result;
            }
            catch (Exception wex)
            {
                Debug.WriteLine(wex.Message + "!!!!!! Error !!!!!!");
                return new List<SelectAuto>();
            }
        }
    }
}
