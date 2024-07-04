using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Http;
using DataCore.Nsi;

namespace DataCore.Cache
{
    public class WaybillsCache : DictionaryCache<IEnumerable<Waybills>>
    {
        private HttpClientNsi<Waybills> httpClientNsi = new HttpClientNsi<Waybills>(new HttpClientTs());
        public WaybillsCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);
            Data = result;
        }        
    }
}
