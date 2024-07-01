namespace DataCore.Http
{
    public interface IHttpClientTs
    {
        public Task<string> Get();
        public string Url { get; set; }

    }
}
