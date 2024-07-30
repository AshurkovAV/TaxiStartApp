using DataCore.Models.Nsi;
using System.Globalization;


namespace TaxiStartApp.Common.Converters.Helpers
{
    public class AutoCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<AutoClass> contacts)
            {
                return string.Join("; ", contacts.Select(x => x.Name));
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
