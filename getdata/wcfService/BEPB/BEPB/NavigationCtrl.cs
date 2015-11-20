namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class NavigationCtrl : Control
    {
        public static readonly DependencyProperty bCanZoomProperty = DependencyProperty.Register("bCanZoom", typeof(bool), typeof(NavigationCtrl), null);
        public static readonly DependencyProperty bsMapModeProperty = DependencyProperty.Register("bsMapMode", typeof(BSMapMode), typeof(NavigationCtrl), null);
        private RepeatButton btnMoveEast;
        private RepeatButton btnMoveNorth;
        private RepeatButton btnMoveSouth;
        private RepeatButton btnMoveWest;
        private Button btnZoomHome;
        private RepeatButton btnZoomIn;
        private RepeatButton btnZoomOut;
        private Rectangle SliderStick;
        private double SpanHeight = 6.0;
        private double ThumbHeight = 9.0;
        private int ZoomLevelCount;
        public static readonly DependencyProperty ZoomLevelProperty = DependencyProperty.Register("ZoomLevel", typeof(double), typeof(NavigationCtrl), null);
        public static readonly DependencyProperty ZoomMaxLevelProperty = DependencyProperty.Register("ZoomMaxLevel", typeof(double), typeof(NavigationCtrl), null);
        public static readonly DependencyProperty ZoomMinLevelProperty = DependencyProperty.Register("ZoomMinLevel", typeof(double), typeof(NavigationCtrl), null);
        private Grid ZoomSlider;
        private Thumb ZoomThumb;

        public NavigationCtrl()
        {
            base.set_DefaultStyleKey(typeof(NavigationCtrl));
        }

        private void airDataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ZoomLevel")
            {
                this.ZoomLevel = this.bsMapMode.airDataContext.ZoomLevel;
                this.ZoomThumb.set_Tag(this.ZoomLevel + "级");
            }
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            Location center = this.bsMapMode.Center;
            if (sender == this.btnMoveWest)
            {
                center.Longitude -= 0.01;
            }
            else if (sender == this.btnMoveNorth)
            {
                center.Latitude += 0.005;
            }
            else if (sender == this.btnMoveEast)
            {
                center.Longitude += 0.01;
            }
            else if (sender == this.btnMoveSouth)
            {
                center.Latitude -= 0.005;
            }
            this.bsMapMode.Center = center;
        }

        private void btnZoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender == this.btnZoomHome)
            {
                this.bsMapMode.ZoomHome(true);
            }
            else if (sender == this.btnZoomIn)
            {
                this.bsMapMode.ZoomIn();
            }
            else if (sender == this.btnZoomOut)
            {
                this.bsMapMode.ZoomOut();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.btnMoveWest = base.GetTemplateChild("btnMoveWest") as RepeatButton;
            this.btnMoveWest.set_Content("向西平移");
            this.btnMoveNorth = base.GetTemplateChild("btnMoveNorth") as RepeatButton;
            this.btnMoveNorth.set_Content("向北平移");
            this.btnMoveEast = base.GetTemplateChild("btnMoveEast") as RepeatButton;
            this.btnMoveEast.set_Content("向东平移");
            this.btnMoveSouth = base.GetTemplateChild("btnMoveSouth") as RepeatButton;
            this.btnMoveSouth.set_Content("向南平移");
            this.btnZoomHome = base.GetTemplateChild("btnZoomHome") as Button;
            this.btnZoomHome.set_Content("回到原位");
            this.btnZoomIn = base.GetTemplateChild("btnZoomIn") as RepeatButton;
            this.btnZoomIn.set_Content("放大");
            this.btnZoomOut = base.GetTemplateChild("btnZoomOut") as RepeatButton;
            this.btnZoomOut.set_Content("缩小");
            this.btnMoveWest.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnMove_Click));
            this.btnMoveNorth.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnMove_Click));
            this.btnMoveEast.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnMove_Click));
            this.btnMoveSouth.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnMove_Click));
            this.btnZoomHome.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnZoom_Click));
            this.btnZoomIn.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnZoom_Click));
            this.btnZoomOut.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnZoom_Click));
            this.ZoomSlider = base.GetTemplateChild("ZoomSlider") as Grid;
            this.ZoomSlider.add_MouseLeftButtonDown(new MouseButtonEventHandler(this, (IntPtr) this.ZoomSlider_MouseLeftButtonDown));
            this.SliderStick = base.GetTemplateChild("SliderStick") as Rectangle;
            this.ZoomThumb = base.GetTemplateChild("ZoomThumb") as Thumb;
            this.ZoomThumb.set_IsEnabled(this.bCanZoom);
            this.ZoomThumb.set_Tag(this.ZoomLevel.ToString() + "级");
            this.ZoomThumb.add_DragDelta(new DragDeltaEventHandler(this, (IntPtr) this.ZoomThumb_DragDelta));
            this.ZoomThumb.add_DragCompleted(new DragCompletedEventHandler(this, (IntPtr) this.ZoomThumb_DragCompleted));
            this.bsMapMode.airDataContext.PropertyChanged += new PropertyChangedEventHandler(this.airDataContext_PropertyChanged);
            this.ResetSliderHeight();
        }

        private void ResetSliderHeight()
        {
            if (this.ZoomSlider != null)
            {
                this.ZoomLevelCount = ((int) (this.ZoomMaxLevel - this.ZoomMinLevel)) + 1;
                this.SliderStick.set_Height((this.ThumbHeight * this.ZoomLevelCount) + (this.SpanHeight * (this.ZoomLevelCount - 1)));
                for (int i = 1; i < (this.ZoomLevelCount - 1); i++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.set_Width(10.0);
                    rectangle.set_Height(2.0);
                    rectangle.set_Fill(new SolidColorBrush(SystemColors.get_ControlDarkDarkColor()));
                    rectangle.set_HorizontalAlignment(1);
                    rectangle.set_VerticalAlignment(0);
                    rectangle.set_Margin(new Thickness(0.0, ((this.SliderStick.get_Height() / ((double) (this.ZoomLevelCount - 1))) * i) - 1.0, 0.0, 0.0));
                    ToolTip tip = new ToolTip();
                    tip.set_Content(((this.ZoomMaxLevel - i)).ToString() + "级");
                    ToolTipService.SetToolTip(rectangle, tip);
                    this.ZoomSlider.get_Children().Add(rectangle);
                }
                this.SetThumbPosition();
            }
        }

        private void SetThumbPosition()
        {
            if (this.ZoomThumb != null)
            {
                this.ZoomThumb.set_Margin(new Thickness(0.0, (this.ZoomMaxLevel - this.ZoomLevel) * (this.ThumbHeight + this.SpanHeight), 0.0, 0.0));
            }
        }

        private void ZoomSlider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.bCanZoom)
            {
                Point position = e.GetPosition(this.ZoomSlider);
                double num = this.ZoomThumb.get_Margin().get_Left();
                double num2 = position.get_Y();
                double num3 = this.ZoomThumb.get_Margin().get_Right();
                double num4 = this.ZoomThumb.get_Margin().get_Bottom();
                int num5 = 0;
                while ((((num5 + 1) * (this.ThumbHeight + this.SpanHeight)) - (this.SpanHeight / 2.0)) < num2)
                {
                    num5++;
                }
                num2 = num5 * (this.ThumbHeight + this.SpanHeight);
                this.ZoomThumb.set_Margin(new Thickness(num, num2, num3, num4));
                this.ZoomLevel = this.ZoomMaxLevel - num5;
                this.bsMapMode.ZoomTo(this.ZoomLevel);
            }
        }

        private void ZoomThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            double num = this.ZoomThumb.get_Margin().get_Left();
            double num2 = this.ZoomThumb.get_Margin().get_Top();
            double num3 = this.ZoomThumb.get_Margin().get_Right();
            double num4 = this.ZoomThumb.get_Margin().get_Bottom();
            int num5 = 0;
            while ((((num5 + 1) * (this.ThumbHeight + this.SpanHeight)) - (this.SpanHeight / 2.0)) < num2)
            {
                num5++;
            }
            num2 = num5 * (this.ThumbHeight + this.SpanHeight);
            this.ZoomThumb.set_Margin(new Thickness(num, num2, num3, num4));
            this.ZoomLevel = this.ZoomMaxLevel - num5;
            this.bsMapMode.ZoomTo(this.ZoomLevel);
        }

        private void ZoomThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double num = this.ZoomThumb.get_Margin().get_Left();
            double num2 = this.ZoomThumb.get_Margin().get_Top();
            double num3 = this.ZoomThumb.get_Margin().get_Right();
            double num4 = this.ZoomThumb.get_Margin().get_Bottom();
            num2 += e.get_VerticalChange();
            if (num2 < 0.0)
            {
                num2 = 0.0;
            }
            double num5 = (this.ThumbHeight + this.SpanHeight) * (this.ZoomLevelCount - 1);
            if (num2 > num5)
            {
                num2 = num5;
            }
            this.ZoomThumb.set_Margin(new Thickness(num, num2, num3, num4));
        }

        public bool bCanZoom
        {
            get
            {
                return (bool) base.GetValue(bCanZoomProperty);
            }
            set
            {
                base.SetValue(bCanZoomProperty, value);
                if (this.ZoomThumb != null)
                {
                    this.ZoomThumb.set_IsEnabled(value);
                }
            }
        }

        public BSMapMode bsMapMode
        {
            get
            {
                return (BSMapMode) base.GetValue(bsMapModeProperty);
            }
            set
            {
                base.SetValue(bsMapModeProperty, value);
            }
        }

        public double ZoomLevel
        {
            get
            {
                return (double) base.GetValue(ZoomLevelProperty);
            }
            set
            {
                base.SetValue(ZoomLevelProperty, value);
                this.SetThumbPosition();
            }
        }

        public double ZoomMaxLevel
        {
            get
            {
                return (double) base.GetValue(ZoomMaxLevelProperty);
            }
            set
            {
                base.SetValue(ZoomMaxLevelProperty, value);
                this.ResetSliderHeight();
            }
        }

        public double ZoomMinLevel
        {
            get
            {
                return (double) base.GetValue(ZoomMinLevelProperty);
            }
            set
            {
                base.SetValue(ZoomMinLevelProperty, value);
                this.ResetSliderHeight();
            }
        }
    }
}

