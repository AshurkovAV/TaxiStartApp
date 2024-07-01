using JobTaxi.Entity.Models;
using DataCore.Models.Nsi;
using DataCore.Nsi;
using DataCore.Service;

namespace DataCore.Data.Nsi
{
    public static class DriversConstrainStorage
    {
        private static HttpClientNsi<DriversConstraint> httpClientNsi = new HttpClientNsi<DriversConstraint>();     
        public static List<DriversCon> GetBlogs()
        {
            var result = httpClientNsi.GetNsi();
            var con = new List<DriversCon>();
            foreach (var item in result.Result)
            {
                con.Add(new DriversCon(item));
            }
            return con;
           
        }       
    }
}
