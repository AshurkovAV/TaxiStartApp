

using TaxiStartApp.Common.OAuth;
using TaxiStartApp.Dto;

namespace TaxiStartApp.Common
{
    public class Constant
    {
        public static string TokenService { get; set; } = "631DFC6B-5080-4E4B-BBDD-2E74DEFA8025";
        public static YandexProfil yandexProfil = new YandexProfil();
        public static UserTokenJson UserToken = new UserTokenJson();
        public static string DeviceId;
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
