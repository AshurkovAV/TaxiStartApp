using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Http;
using DataCore.Nsi;

namespace DataCore.Cache
{
    public class FirstDayCache : DictionaryCache<IEnumerable<FirstDay>>
    {
        private HttpClientNsi<FirstDay> httpClientNsi = new HttpClientNsi<FirstDay>(new HttpClientTs());
        public FirstDayCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);
            Data = result;
        }        
    }
}
