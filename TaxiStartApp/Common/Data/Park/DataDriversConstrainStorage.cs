using Android.Print;
using JobTaxi.Entity.Models;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Park
{
    public static class DataDriversConstrainStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();       

        public static int _startIndex;
        public static int _batchSize;
        private static string _paktGuid;

        public static IEnumerable<ParkDriversCon> GetBlogs(string paktGuid)
        {
            _paktGuid = paktGuid;
            return CreateBlogs(paktGuid);
        }
        public static int GetTotalCount(string paktGuid)
        {
            return CreateBlogs(paktGuid).Count;
        }
        static List<ParkDriversCon> CreateBlogs(string paktGuid)
        {
            var result = httpClientJob.GetParksDriversConstraintAsync(paktGuid);
            var con = new List<ParkDriversCon>();
            foreach (var constraint in result.Result)
            {
                con.Add(new ParkDriversCon(constraint));
            }
            return con;      
        }
    }
}
