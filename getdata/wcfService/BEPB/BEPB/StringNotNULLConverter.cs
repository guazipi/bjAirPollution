namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class StringNotNULLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value != null) && !string.IsNullOrEmpty(value.ToString()))
            {
                return (double) 1.0 / (double) 0.0;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

