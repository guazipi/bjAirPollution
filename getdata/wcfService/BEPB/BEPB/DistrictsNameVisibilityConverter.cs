namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class DistrictsNameVisibilityConverter : IValueConverter
    {
        public BSMapMode bsMapMode;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (this.bsMapMode == null)
                {
                    return (Visibility) 1;
                }
                double num = (double) value;
                if (num >= this.bsMapMode.MapZoomRange.To)
                {
                    return (Visibility) 0;
                }
            }
            return (Visibility) 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

