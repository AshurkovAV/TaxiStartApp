using Android.Print;
using JobTaxi.Entity.Models;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Park
{
    public static class DataCarsStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();       

        public static int _startIndex;
        public static int _batchSize;
        private static int _parkId;

        public static IEnumerable<Cars> GetBlogs(int paktId)
        {
            _parkId = paktId;
            return CreateBlogs();
        }
        public static int GetTotalCount(int parkId)
        {
            return httpClientJob.GetCarsCountAsync(parkId).Result;
        }
        static List<Cars> CreateBlogs()
        {
            var result = httpClientJob.GetCarsRowPageAsync(_parkId, _batchSize, _startIndex);
            var con = new List<Cars>();
            foreach (var contact in result.Result)
            {
                con.Add(
                    new Cars(
                        contact.Id,
                        contact.CarName,
                        contact.Model,
                        contact.Color,
                        contact.Number,
                        contact.Year,
                        contact.PriceForDay,
                        "",
                        ""));                
            }
            return con;      

        }
    }
}
