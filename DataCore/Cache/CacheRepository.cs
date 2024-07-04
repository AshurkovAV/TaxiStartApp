using Autofac;
using Core.Services;
using DataCore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DataCore.Cache
{
    public class CacheRepository : ICacheRepository
    {
        public static string DriversConstrainCache = "DriversConstrainCache";
        public static string WorkConditionCache = "WorkConditionCache";
        public static string DepositRetCache = "DepositRetCache";
        public static string FirstDayCache = "FirstDayCache";
        public static string InspectionCache = "InspectionCache";
        public static string MinRentalPeriodCache = "MinRentalPeriodCache";
        public static string WaybillsCache = "WaybillsCache";
        public static string WorkRadiusCache = "WorkRadiusCache";


        protected static Dictionary<string, ICache> Caches = new Dictionary<string, ICache>();
        protected IEnumerable<string> CachesList = new List<string>
    {
            DriversConstrainCache,
            WorkConditionCache,
            DepositRetCache,
            FirstDayCache,
            InspectionCache,
            MinRentalPeriodCache,
            WaybillsCache,  
            WorkRadiusCache
        };

        public CacheRepository(IServiceProvider serviceProvider)
        {
            if (Caches.Count == 0)
            {
                var scaches = serviceProvider.GetServices<ICache>();
                foreach (var item in scaches)
                {
                    Type myType = item.GetType();
                    foreach (var item1 in CachesList.ToList())
                    {
                        if (item1 == myType.Name)
                        {
                            Caches.Add(item1, item);
                        }
                    }
                }
            }
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
