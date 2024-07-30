using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Http;
using DataCore.Nsi;

namespace DataCore.Cache
{
    public class LocationCache : DictionaryCache<IEnumerable<Location>>
    {
        private HttpClientNsi<Location> httpClientNsi = new HttpClientNsi<Location>(new HttpClientTs());
        public LocationCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.OblName as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.OblName as object);
            Data = result;
        }        
    }
}
