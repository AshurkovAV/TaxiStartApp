using JobTaxi.Entity.Models;
using TaxiStartApp.Models.Nsi;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Nsi
{
    public static class DriversConstrainStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();     
        public static List<DriversCon> GetBlogs()
        {        
            return CreateBlogs();
        }

        static List<DriversCon> CreateBlogs()
        {
            var result = httpClientJob.GetNsiDriversConstraint();
            var con = new List<DriversCon>();
            foreach (var item in result.Result)
            {
                con.Add(new DriversCon(item));
            }
            return con;
        }
    }
}
