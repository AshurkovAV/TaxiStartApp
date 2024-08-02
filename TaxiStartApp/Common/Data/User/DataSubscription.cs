using Android.Print;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;
using TaxiStartApp.Models;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Models.User;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.User
{
    public static class DataSubscription
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();       

        private static int _userId;

        public static IEnumerable<Subscription> GetBlogs(int userId)
        {
            _userId = userId;
            return CreateBlogs();
        }
        public static int GetTotalCount(int userId)
        {
            return httpClientJob.GetFilterCountAsync(userId).Result;
        }
        static List<Subscription> CreateBlogs()
        {
            var result = httpClientJob.GetFilterUserToIdAsync(_userId);
            var con = new List<Subscription>();
            foreach (var contact in result.Result)
            {
                con.Add(new Subscription(contact));                
            }
            return con;
            

        }
    }
}
