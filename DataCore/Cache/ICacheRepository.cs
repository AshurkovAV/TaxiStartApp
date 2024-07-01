using DataCore.Service;

namespace DataCore.Cache
{
    public interface ICacheRepository
    {
        ICache Get(string name);
        bool Has(string name);
        void Put(string name, ICache cache);
    }
}
