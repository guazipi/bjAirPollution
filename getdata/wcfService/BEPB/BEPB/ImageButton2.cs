namespace BEPB
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using System.Windows.Shapes;

    public class ImageButton2 : Button
    {
        private Rectangle ButtonImage;
        private DropShadowEffect ButtonShadow;
        public static readonly DependencyProperty HighlightImageProperty = DependencyProperty.Register("HighlightImage", typeof(ImageBrush), typeof(ImageButton2), null);
        public static readonly DependencyProperty NormalImageProperty = DependencyProperty.Register("NormalImage", typeof(ImageBrush), typeof(ImageButton2), null);
        public static readonly DependencyProperty ShadowDepthProperty = DependencyProperty.Register("ShadowDepth", typeof(double), typeof(ImageButton2), null);
        public static readonly DependencyProperty ShadowOpacityProperty = DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(ImageButton2), null);

        public ImageButton2()
        {
            base.set_DefaultStyleKey(typeof(ImageButton2));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ButtonShadow = base.GetTemplateChild("ButtonShadow") as DropShadowEffect;
            this.ButtonShadow.set_Opacity(this.ShadowOpacity);
            this.ButtonShadow.set_ShadowDepth(this.ShadowDepth);
            this.ButtonImage = base.GetTemplateChild("ButtonImage") as Rectangle;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.ButtonImage.set_Fill(this.HighlightImage);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.ButtonImage.set_Fill(this.NormalImage);
        }

        public ImageBrush HighlightImage
        {
            get
            {
                return (ImageBrush) base.GetValue(HighlightImageProperty);
            }
            set
            {
                base.SetValue(HighlightImageProperty, value);
            }
        }

        public ImageBrush NormalImage
        {
            get
            {
                return (ImageBrush) base.GetValue(NormalImageProperty);
            }
            set
            {
                base.SetValue(NormalImageProperty, value);
            }
        }

        public double ShadowDepth
        {
            get
            {
                return (double) base.GetValue(ShadowDepthProperty);
            }
            set
            {
                base.SetValue(ShadowDepthProperty, value);
                if (this.ButtonShadow != null)
                {
                    this.ButtonShadow.set_ShadowDepth(this.ShadowDepth);
                }
            }
        }

        public double ShadowOpacity
        {
            get
            {
                return (double) base.GetValue(ShadowOpacityProperty);
            }
            set
            {
                base.SetValue(ShadowOpacityProperty, value);
                if (this.ButtonShadow != null)
                {
                    this.ButtonShadow.set_Opacity(this.ShadowOpacity);
                }
            }
        }
    }
}

