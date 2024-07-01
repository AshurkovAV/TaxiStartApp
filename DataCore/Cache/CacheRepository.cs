using Autofac;
using Core.Services;
using DataCore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DataCore.Cache
{
    public class CacheRepository : ICacheRepository
    {
        public static string DriversConstrainCache = "DriversConstrainCache";

        protected static Dictionary<string, ICache> Caches = new Dictionary<string, ICache>();
        protected IEnumerable<string> CachesList = new List<string>
    {
            DriversConstrainCache
        };

        public CacheRepository(IServiceProvider serviceProvider)
        {            
            foreach (var item in CachesList.ToList())
            {
                var s = serviceProvider.GetService<ICache>();
                Caches.Add(item, s);
            }
            //CachesList.ToList().ForEach(p => Caches.Add(p, serviceProvider.GetService<ICache>(p)));
        }
        public ICache Get(string name)
        {
            if (Caches.ContainsKey(name))
            {
                return Caches[name];
            }
            return null;
        }

        public bool Has(string name)
        {
            return Caches.ContainsKey(name);
        }

        public void Put(string name, ICache cache)
        {
            if (!Caches.ContainsKey(name))
            {
                Caches.Add(name, cache);
            }
        }
    }
}
