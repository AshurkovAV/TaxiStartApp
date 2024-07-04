
using DataCore.Models.Nsi;
using DataCore.Nsi;
using DataCore.Http;

namespace DataCore.Data.Nsi
{
    public static class DriversConstrainStorage
    {
        private static HttpClientNsi<DriversConstraint> httpClientNsi = new HttpClientNsi<DriversConstraint>(new HttpClientTs());     
        public static List<DriversConstraint> GetBlogs()
        {
            var result = httpClientNsi.GetNsi();
            return result?.Result?.ToList();
           
        }       
    }
}
