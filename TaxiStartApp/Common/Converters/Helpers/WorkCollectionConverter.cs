using System.Globalization;
using TaxiStartApp.Models.Nsi;


namespace TaxiStartApp.Common.Converters.Helpers
{
    public class WorkCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<WorkCon> contacts)
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
