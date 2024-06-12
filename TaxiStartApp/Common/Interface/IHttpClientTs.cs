namespace TaxiStartApp.Common.Interface
{
    internal interface IHttpClientTs
    {
        public Task<string> Get();

        public Task<Stream> GetAvat();
    }
}
