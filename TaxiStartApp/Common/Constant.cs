using TaxiStartApp.Common.OAuth;
using TaxiStartApp.Dto;

namespace TaxiStartApp.Common
{
    public class Constant
    {
        //public static CacheRepository cacheRepository = new CacheRepository();
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

        public static string UrlGeneralService {  get; set; } = "https://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai";
        //return "https://api.xn--80aaaaadxhwt3bixfhni.xn--p1ai"; http://192.168.10.7:8555

        public static string UrlGeneralSite { get; set; } = "https://lk.таксиработааренда.рф";
        //http://192.168.10.7:8556
        public static int ShareParkId { get; set; }
        public static string ShareParkGuid { get; set; }
        public static int ShareParkCountDrive { get; set; }
        public static int ShareParkCountWork { get; set; }
        public static int ShareParkCountCar { get; set; }

        public static double MainDisplayWidth { get; set; }
        public static double MainDisplayHeight { get; set; }

        /// <summary>
        /// Ключ для бота 
        /// @HabUnloadBot
        /// </summary>
        public static string KeyReestr { get; set; } = "6956643460:AAGEsTrMb2MB-RBwSWCPmHIcMjHecyrsz1Q";
    }
}
