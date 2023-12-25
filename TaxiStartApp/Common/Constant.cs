

namespace TaxiStartApp.Common
{
    public class Constant
    {
        /// <summary>
        /// Запросить повторно
        /// </summary>
        public static string PushNotification = "Запросить повторно";
        /// <summary>
        /// Не верный код
        /// </summary>
        public static string PushErrorText    = "Не верный код";

        public static string UrlService()
        {
           return "http://91.240.209.20:8884/AttachedMo/startplus";           
        }

        /// <summary>
        /// Ключ для бота 
        /// @HabUnloadBot
        /// </summary>
        public static string KeyReestr { get; set; } = "6956643460:AAGEsTrMb2MB-RBwSWCPmHIcMjHecyrsz1Q";
    }
}
