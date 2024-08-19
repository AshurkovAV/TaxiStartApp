using System.Net;

namespace DataCore.Http
{
    public class HttpClientTs: IHttpClientTs
    {
        private string _url;   
        public string Url { set { _url = value; } get { return _url; } }
        public string Get() 
        {
            WebRequest request = WebRequest.Create(_url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Headers.Add("Host", "api.xn--80aaaaadxhwt3bixfhni.xn--p1ai:443");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;            
        }      
    }
}
