using DataCore.Service;
using JobTaxi.Entity.Models;
using DataCore.Models.Nsi;
using DataCore.Data.Nsi;

namespace DataCore.Cache
{
    public class DriversConstrainCache : DictionaryCache<IEnumerable<DriversCon>>
    {
        public DriversConstrainCache() 
        {
            var result = DriversConstrainStorage.GetBlogs();
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);            
        }        
    }
}
