using System.Net;

namespace DataCore.Http
{
    public class HttpClientTs: IHttpClientTs
    {
        private string _url;   
        public string Url { set { value = _url; } get { return _url; } }
        public async Task<string> Get() 
        {
            WebRequest request = WebRequest.Create(_url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
