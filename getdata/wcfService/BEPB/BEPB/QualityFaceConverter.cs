namespace BEPB
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class QualityFaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            BitmapImage image = new BitmapImage();
            switch (((QualityFace) value))
            {
                case QualityFace.NoData:
                    return null;

                case QualityFace.Happy:
                    image.set_UriSource(new Uri("/BEPB;component/Images/Popup/HappyFace.png", UriKind.Relative));
                    return image;

                case QualityFace.Normal:
                    image.set_UriSource(new Uri("/BEPB;component/Images/Popup/NormalFace.png", UriKind.Relative));
                    return image;

                case QualityFace.Sad:
                    image.set_UriSource(new Uri("/BEPB;component/Images/Popup/SadFace.png", UriKind.Relative));
                    return image;
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

