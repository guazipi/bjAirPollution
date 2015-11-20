namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Data;

    public class StringSpitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value.ToString();
            Regex regex = new Regex(".*过去24小时(.*)浓度变化曲线图.*", RegexOptions.IgnoreCase);
            return regex.Match("returnValue").Groups[1].Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

