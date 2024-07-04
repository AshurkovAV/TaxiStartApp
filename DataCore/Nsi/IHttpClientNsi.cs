namespace DataCore.Nsi
{
    public interface IHttpClientNsi<T>
    {
        public Task<IEnumerable<T>> GetNsi();
    }
}
