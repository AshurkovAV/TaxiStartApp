namespace TaxiStartApp.Services.Http
{
    public abstract class BaseHttp
    {
        private string _url;
        protected string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
