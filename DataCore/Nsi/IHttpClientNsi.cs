namespace DataCore.Nsi
{
    interface IHttpClientNsi<T>
    {
        public Task<IEnumerable<T>> GetNsi();
    }
}
