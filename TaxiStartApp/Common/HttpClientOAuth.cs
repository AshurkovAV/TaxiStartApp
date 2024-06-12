﻿using System.Net;

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

        public async Task<Tuple<string, HttpStatusCode>> GetStStatusAsync() 
        {
            try
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
                return new Tuple<string, HttpStatusCode>(responseFromServer, HttpStatusCode.OK);

            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<string, HttpStatusCode>(e.Message, HttpStatusCode.RequestTimeout);
            }
        }

        public async Task<string> GetAsync()
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
        

        public async Task<Tuple<Stream?, HttpStatusCode>> GetStreamAsync()
        {
            try
            {
                WebRequest request = WebRequest.Create(_url);
               // request.Timeout = 1000;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                return new Tuple<Stream, HttpStatusCode>(dataStream, HttpStatusCode.OK); ;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<Stream, HttpStatusCode>(null, HttpStatusCode.RequestTimeout);
            }

        }
    }
}
