namespace TaxiStartApp.Common
{
    public class InfoDevice
    {
        /// <summary>
        /// Сведения о девайсе 
        /// </summary>
        /// <returns></returns>
        public static string GetInfo()
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.AppendLine($"Model: {DeviceInfo.Current.Model}");
                sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
                sb.AppendLine($"Name: {DeviceInfo.Current.Name}");
                sb.AppendLine($"OS Version: {DeviceInfo.Current.VersionString}");
                sb.AppendLine($"Idiom: {DeviceInfo.Current.Idiom}");
                sb.AppendLine($"Platform: {DeviceInfo.Current.Platform}");
                return sb.ToString();
            }
            catch { 
            
            }
            return "";
            
        }
    }
}
