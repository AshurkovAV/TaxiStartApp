using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Http;
using DataCore.Nsi;

namespace DataCore.Cache
{
    public class MinRentalPeriodCache : DictionaryCache<IEnumerable<MinRentalPeriod>>
    {
        private HttpClientNsi<MinRentalPeriod> httpClientNsi = new HttpClientNsi<MinRentalPeriod>(new HttpClientTs());
        public MinRentalPeriodCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);
            Data = result;
        }        
    }
}
