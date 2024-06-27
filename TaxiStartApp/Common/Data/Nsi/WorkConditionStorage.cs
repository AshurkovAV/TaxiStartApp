using JobTaxi.Entity.Models;
using TaxiStartApp.Models.Nsi;
using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Nsi
{
    public static class WorkConditionStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();     
        public static List<WorkCon> GetBlogs()
        {        
            return CreateBlogs();
        }

        static List<WorkCon> CreateBlogs()
        {
            var result = httpClientJob.GetNsiWorkConstraint();
            var con = new List<WorkCon>();
            foreach (var item in result.Result)
            {
                con.Add(new WorkCon(item));
            }
            return con;
        }
    }
}
