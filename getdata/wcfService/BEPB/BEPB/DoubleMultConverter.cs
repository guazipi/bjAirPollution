namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class DoubleMultConverter : IValueConverter
    {
        public WRWData wrwData;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            return (System.Convert.ToDouble(value) * 3.0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            return (System.Convert.ToDouble(value) / 3.0);
        }
    }
}

