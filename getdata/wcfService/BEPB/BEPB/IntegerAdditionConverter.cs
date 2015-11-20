namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IntegerAdditionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToInt32(value) - 8);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToInt32(value) + 8);
        }
    }
}

