using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Nsi;
using DataCore.Http;

namespace DataCore.Cache
{
    public class WorkConditionCache : DictionaryCache<IEnumerable<WorkCondition>>
    {
        private static HttpClientNsi<WorkCondition> httpClientNsi = new HttpClientNsi<WorkCondition>(new HttpClientTs());
        public WorkConditionCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);
            Data = result;
        }        
    }
}
