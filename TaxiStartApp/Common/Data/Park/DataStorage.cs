using JobTaxi.Entity.Dto;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Park
{
    public static class DataStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();
        static DataStorage()
        {
        }

        public static int _startIndex;
        public static int _batchSize;

        public static SelectParkDto GetSelectParkDto(int selectParkId,  int userId)
        {
            return GetSelectParks(selectParkId, userId);
        }

        public static IEnumerable<SelectParkDto> GetSelectParkDto(int userId)
        {
            return GetSelectParks(userId);
        }

        /// <summary>
        /// old
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContactTaxiPark> GetBlogs()
        {
            return CreateBlogs();
        }

        public static IEnumerable<ContactTaxiPark> GetBlogsToUser(int userId)
        {
            return CreateBlogsToUser(userId);
        }
        public static IEnumerable<ContactTaxiPark> GetBlogs(int userId)
        {
            return CreateBlogs(userId);
        }
        public static int GetTotalCount()
        {
            return httpClientJob.GetParksCountAsync().Result;
        }
        public static int GetTotalCount(int userId)
        {
            return httpClientJob.GetSelectParkCountAsync(userId).Result;
        }
        static List<ContactTaxiPark> CreateBlogs()
        {
            var result = httpClientJob.GetParksTruncatedAsync(_batchSize, _startIndex);
            var con = new List<ContactTaxiPark>();
            foreach (var contact in result.Result)
            {
                con.Add(new ContactTaxiPark(contact));
                if (contact.CarAvatar != null)
                {
                    con.FirstOrDefault(x => x.Id == contact.Id).CarAvatar = ImageSource.FromStream(() => new MemoryStream(contact.CarAvatar));
                }
            }
            return con;      

        }

        static List<ContactTaxiPark> CreateBlogsToUser(int userId)
        {
            var result = httpClientJob.GetParksTruncatedToUserIdAsync(_batchSize, _startIndex, userId);
            var con = new List<ContactTaxiPark>();
            foreach (var contact in result.Result)
            {
                con.Add(new ContactTaxiPark(contact));
                if (contact.CarAvatar != null)
                {
                    con.FirstOrDefault(x => x.Id == contact.Id).CarAvatar = ImageSource.FromStream(() => new MemoryStream(contact.CarAvatar));
                }
            }
            return con;

        }

        static List<ContactTaxiPark> CreateBlogs(int userId)
        {
            var result = httpClientJob.GetParksTruncatedAsync(_batchSize, _startIndex, userId);
            var con = new List<ContactTaxiPark>();
            foreach (var contact in result.Result)
            {
                con.Add(new ContactTaxiPark(contact));                
            }
            return con;           

        }
        static SelectParkDto GetSelectParks(int selectparkId, int userId)
        {
            var result = httpClientJob.GetSelectParks(selectparkId, userId);
            
            return result.Result;

        }

        static IEnumerable<SelectParkDto> GetSelectParks(int userId)
        {
            var result = httpClientJob.GetSelectParksToUserIdAsync(userId);

            return result.Result;

        }
    }
}
