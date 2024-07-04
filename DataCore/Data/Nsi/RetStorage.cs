using DataCore.Models.Nsi;
using DataCore.Nsi;

namespace DataCore.Data.Nsi
{
    public static class RetStorage
    {
        private static HttpClientNsi<DriversConstraint> httpClientNsi = new HttpClientNsi<DriversConstraint>();     
        public static List<DriversConstraint> GetBlogs()
        {        
            return CreateBlogs();
        }

        static List<DriversConstraint> CreateBlogs()
        {
            var result = httpClientNsi.GetNsi();
            var con = new List<DriversConstraint>();
            foreach (var item in result.Result)
            {
                con.Add(item);
            }
            return con;
        }
    }
}
