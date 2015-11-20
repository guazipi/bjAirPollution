namespace BEPB
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class PushedImageButton : Button
    {
        private Image ButtonImage;
        public static readonly DependencyProperty NormalImageProperty = DependencyProperty.Register("NormalImage", typeof(BitmapImage), typeof(PushedImageButton), null);
        public static readonly DependencyProperty PushedImageProperty = DependencyProperty.Register("PushedImage", typeof(BitmapImage), typeof(PushedImageButton), null);

        public PushedImageButton()
        {
            base.set_DefaultStyleKey(typeof(PushedImageButton));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ButtonImage = base.GetTemplateChild("ButtonImage") as Image;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (this.PushedImage != null)
            {
                this.ButtonImage.set_Source(this.PushedImage);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (this.ButtonImage.get_Source() != this.NormalImage)
            {
                this.ButtonImage.set_Source(this.NormalImage);
            }
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public BitmapImage NormalImage
        {
            get
            {
                return (BitmapImage) base.GetValue(NormalImageProperty);
            }
            set
            {
                base.SetValue(NormalImageProperty, value);
            }
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public BitmapImage PushedImage
        {
            get
            {
                return (BitmapImage) base.GetValue(PushedImageProperty);
            }
            set
            {
                base.SetValue(PushedImageProperty, value);
            }
        }
    }
}

