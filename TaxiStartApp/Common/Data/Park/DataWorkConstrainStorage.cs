using Android.Print;
using JobTaxi.Entity.Models;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Park
{
    public static class DataWorkConstrainStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();       

        public static int _startIndex;
        public static int _batchSize;
        private static string _paktGuid;

        public static IEnumerable<ParkWorkCon> GetBlogs(string paktGuid)
        {
            _paktGuid = paktGuid;
            return CreateBlogs(paktGuid);
        }
        public static int GetTotalCount(string paktGuid)
        {
            return CreateBlogs(paktGuid).Count;
        }
        static List<ParkWorkCon> CreateBlogs(string paktGuid)
        {
            var result = httpClientJob.GetParksWorkConditionTruncatedAsync(paktGuid);
            var con = new List<ParkWorkCon>();
            foreach (var constraint in result.Result)
            {
                con.Add(new ParkWorkCon(constraint));
            }
            return con;      
        }
    }
}
