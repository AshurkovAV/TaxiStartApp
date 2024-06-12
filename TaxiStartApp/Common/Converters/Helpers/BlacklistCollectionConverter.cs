using System.Globalization;


namespace TaxiStartApp.Common.Converters.Helpers
{
    public class BlacklistCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<string> contacts)
            {
                return string.Join("; ", contacts.Select(x => x));
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
