﻿using DataCore.Service;
using DataCore.Models.Nsi;
using DataCore.Http;
using DataCore.Nsi;

namespace DataCore.Cache
{
    public class DriversConstrainCache : DictionaryCache<IEnumerable<DriversConstraint>>
    {
        private HttpClientNsi<DriversConstraint> httpClientNsi = new HttpClientNsi<DriversConstraint>(new HttpClientTs());
        public DriversConstrainCache() 
        {
            var result = httpClientNsi.GetNsi().Result;
            BackDictionary = result.ToDictionary(p => p.Name as object, p => (int?)p.Id);
            Dictionary = result.ToDictionary(p => (int?)p.Id, p => p.Name as object);
            Data = result;
        }        
    }
}
