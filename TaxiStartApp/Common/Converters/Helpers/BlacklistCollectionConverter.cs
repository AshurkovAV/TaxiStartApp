﻿using System.Globalization;


namespace TaxiStartApp.Common.Converters.Helpers
{
    public class BlacklistCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<DataCore.Models.Nsi.Location> contacts)
            {
                return string.Join("; ", contacts.Select(x => x.OblName));
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
