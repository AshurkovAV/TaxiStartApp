using JobTaxi.Entity.Models;
using DataCore.Models.Nsi;
using DataCore.Nsi;

namespace DataCore.Data.Nsi
{
    public static class WorkConditionStorage
    {
        private static HttpClientNsi<WorkCondition> httpClientNsi = new HttpClientNsi<WorkCondition>();
        public static List<WorkCon> GetBlogs()
        {        
            return CreateBlogs();
        }

        static List<WorkCon> CreateBlogs()
        {
            var result = httpClientNsi.GetNsi();
            var con = new List<WorkCon>();
            foreach (var item in result.Result)
            {
                con.Add(new WorkCon(item));
            }
            return con;
        }
    }
}
