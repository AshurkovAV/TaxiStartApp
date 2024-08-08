using System.Globalization;
using DevExpress.Maui.Controls;


namespace TaxiStartApp.Common.Converters
{
    public class ButtonSheetStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return BottomSheetState.Hidden;
            if (value == "HalfExpanded" )
            {
                return BottomSheetState.Hidden;                
            }
            else return BottomSheetState.HalfExpanded;
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
