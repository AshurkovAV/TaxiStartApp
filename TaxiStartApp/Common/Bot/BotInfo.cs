using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace TaxiStartApp.Common.Bot
{
    public class BotInfo
    {
        public static void BotInfoTo(string str)
        {
            string str_ = String.Empty;
            Bot.Rec rec = new Bot.Rec
            {
                token = Constant.KeyReestr,
                messeng = $"{str} {DateTime.Now} \n"                         
                          
            };
            HttpClientTo(JsonConvert.SerializeObject(rec));
        }

        private static void HttpClientTo(string jsonString)
        {
            string url = Constant.UrlService();

            WebRequest request = WebRequest.Create(url);
            request.Timeout = 500;
            request.Method = "POST";
            request.ContentType = "text/plain";

            if (jsonString == String.Empty)
                throw new Exception("Во входящем запросе не найден ожидаемый тег");

            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            request.ContentLength = byteArray.Length;

            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                //Возвращает ответ на запрос
                WebResponse response = request.GetResponse();

                if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
                {
                    dataStream = response.GetResponseStream();
                    if (dataStream != null)
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        reader.Close();
                        dataStream.Close();
                    }
                }
                else
                {
                }
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
