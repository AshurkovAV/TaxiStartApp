using System.Globalization;


namespace TaxiStartApp.Common.Converters.Helpers
{
    public static class BioHelper
    {
        public const string bioText = "О себе";
        public const string detailText = "Напишите что-нибудь о себе";
    }
    public class BioTextConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? BioHelper.bioText : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }

    public class BioDetailsConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? BioHelper.detailText : BioHelper.bioText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
