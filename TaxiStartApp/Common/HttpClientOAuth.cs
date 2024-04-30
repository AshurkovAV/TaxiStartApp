using System.Net;

namespace TaxiStartApp.Common
{
    public class HttpClientOAuth
    {
        private string _url;          
        public HttpClientOAuth() { }
            
        public HttpClientOAuth(string url) { 
            _url = url;
        }
        public string Url { get { return _url;} }

        public async Task<string> GetAsync() 
        {
            WebRequest request = WebRequest.Create(_url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = await reader.ReadToEndAsync();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;            
        }       
    }
}
