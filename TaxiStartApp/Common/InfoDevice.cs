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

                sb.AppendLine($"Model:        {DeviceInfo.Current.Model}");
                sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
                sb.AppendLine($"Name:         {DeviceInfo.Current.Name}");
                sb.AppendLine($"OS Version:   {DeviceInfo.Current.VersionString}");
                sb.AppendLine($"Idiom:        {DeviceInfo.Current.Idiom}");
                sb.AppendLine($"Platform:     {DeviceInfo.Current.Platform}");

                sb.AppendLine($"-------------------//------------------");                
                sb.AppendLine($"Pixel width:  {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
                sb.AppendLine($"Density:      {DeviceDisplay.Current.MainDisplayInfo.Density}");
                sb.AppendLine($"Orientation:  {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
                sb.AppendLine($"Rotation:     {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
                sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");


                var device_id = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
                sb.AppendLine($"device_id: {Constant.DeviceId}");
                

                return sb.ToString();
            }
            catch { 
            
            }
            return "";
            
        }
    }
}
