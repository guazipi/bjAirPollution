namespace BEPB
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class ImageButton : Button
    {
        private Image ButtonImage;
        public static readonly DependencyProperty HighlightImageProperty = DependencyProperty.Register("HighlightImage", typeof(BitmapImage), typeof(ImageButton), null);
        public static readonly DependencyProperty NormalImageProperty = DependencyProperty.Register("NormalImage", typeof(BitmapImage), typeof(ImageButton), null);

        public ImageButton()
        {
            base.set_DefaultStyleKey(typeof(ImageButton));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ButtonImage = base.GetTemplateChild("ButtonImage") as Image;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.HighlightImage != null)
            {
                this.ButtonImage.set_Source(this.HighlightImage);
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.ButtonImage.get_Source() != this.NormalImage)
            {
                this.ButtonImage.set_Source(this.NormalImage);
            }
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public BitmapImage HighlightImage
        {
            get
            {
                return (BitmapImage) base.GetValue(HighlightImageProperty);
            }
            set
            {
                base.SetValue(HighlightImageProperty, value);
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
    }
}

