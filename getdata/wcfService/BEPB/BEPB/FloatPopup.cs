namespace BEPB
{
    using System;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    public class FloatPopup : ContentControl
    {
        public static readonly DependencyProperty ArrowPlacementProperty = DependencyProperty.Register("ArrowPlacement", typeof(Dock), typeof(FloatPopup), null);
        private bool bExpanding;
        private Path BorderPath;
        private PathFigure BorderPathFigure;
        public static readonly DependencyProperty BorderWidthProperty = DependencyProperty.Register("BorderWidth", typeof(double), typeof(FloatPopup), null);
        private FrameworkElement Content;
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(System.Windows.CornerRadius), typeof(FloatPopup), null);
        public static readonly DependencyProperty HalfArrowWidthProperty = DependencyProperty.Register("HalfArrowWidth", typeof(double), typeof(FloatPopup), null);
        private DoubleAnimation HeightAnimation;
        private DoubleAnimation HOffsetAnimation;
        public static readonly DependencyProperty HOriginOffsetProperty = DependencyProperty.Register("HOriginOffset", typeof(double), typeof(FloatPopup), null);
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(FloatPopup), null);
        private Canvas Overlay;
        private LineSegment PathPoint1;
        private LineSegment PathPoint10;
        private PointAnimation PathPoint10Animation;
        private PointAnimation PathPoint1Animation;
        private LineSegment PathPoint2;
        private PointAnimation PathPoint2Animation;
        private ArcSegment PathPoint3;
        private PointAnimation PathPoint3Animation;
        private LineSegment PathPoint4;
        private PointAnimation PathPoint4Animation;
        private ArcSegment PathPoint5;
        private PointAnimation PathPoint5Animation;
        private LineSegment PathPoint6;
        private PointAnimation PathPoint6Animation;
        private ArcSegment PathPoint7;
        private PointAnimation PathPoint7Animation;
        private LineSegment PathPoint8;
        private PointAnimation PathPoint8Animation;
        private ArcSegment PathPoint9;
        private PointAnimation PathPoint9Animation;
        private Storyboard PopupStoryboard;
        private Thumb PopupThumb;
        private Rect rect;
        private Popup RootPopup;
        private PointAnimation StartPointAnimation;
        private DoubleAnimation VOffsetAnimation;
        public static readonly DependencyProperty VOriginOffsetProperty = DependencyProperty.Register("VOriginOffset", typeof(double), typeof(FloatPopup), null);
        private DoubleAnimation WidthAnimation;

        public event EventHandler ExpandCompleted;

        public event EventHandler StoryboardCompleted;

        public FloatPopup()
        {
            base.set_DefaultStyleKey(typeof(FloatPopup));
        }

        public void Expand(double TargetWidth, double TargetHeight)
        {
            this.bExpanding = true;
            double num = 0.0;
            if ((this.RootPopup.get_VerticalOffset() + TargetHeight) > this.rect.get_Height())
            {
                num = (this.RootPopup.get_VerticalOffset() + TargetHeight) - this.rect.get_Height();
            }
            this.HOffsetAnimation.set_From(new double?(this.RootPopup.get_HorizontalOffset()));
            this.HOffsetAnimation.set_To(new double?(this.RootPopup.get_HorizontalOffset()));
            this.VOffsetAnimation.set_From(new double?(this.RootPopup.get_VerticalOffset()));
            this.VOffsetAnimation.set_To(new double?(this.RootPopup.get_VerticalOffset() - num));
            this.WidthAnimation.set_To(new double?(TargetWidth));
            this.HeightAnimation.set_To(new double?(TargetHeight));
            this.StartPointAnimation.set_From(new Point?(this.BorderPathFigure.get_StartPoint()));
            this.StartPointAnimation.set_To(new Point(this.BorderPathFigure.get_StartPoint().get_X(), this.BorderPathFigure.get_StartPoint().get_Y() + num));
            switch (this.ArrowPlacement)
            {
                case Dock.Left:
                    this.PathPoint1Animation.set_From(new Point?(this.PathPoint1.get_Point()));
                    this.PathPoint1Animation.set_To(new Point(-1.0 * this.BorderWidth, (TargetHeight / 2.0) - this.HalfArrowWidth));
                    this.PathPoint2Animation.set_From(new Point?(this.PathPoint2.get_Point()));
                    this.PathPoint2Animation.set_To(new Point(-1.0 * this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft()));
                    this.PathPoint3Animation.set_From(new Point?(this.PathPoint3.get_Point()));
                    this.PathPoint3Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft(), -1.0 * this.BorderWidth));
                    this.PathPoint4Animation.set_From(new Point?(this.PathPoint4.get_Point()));
                    this.PathPoint4Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_TopRight(), -1.0 * this.BorderWidth));
                    this.PathPoint5Animation.set_From(new Point?(this.PathPoint5.get_Point()));
                    this.PathPoint5Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopRight()));
                    this.PathPoint6Animation.set_From(new Point?(this.PathPoint6.get_Point()));
                    this.PathPoint6Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (TargetHeight + this.BorderWidth) - this.CornerRadius.get_BottomRight()));
                    this.PathPoint7Animation.set_From(new Point?(this.PathPoint7.get_Point()));
                    this.PathPoint7Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_BottomRight(), TargetHeight + this.BorderWidth));
                    this.PathPoint8Animation.set_From(new Point?(this.PathPoint8.get_Point()));
                    this.PathPoint8Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_BottomLeft(), TargetHeight + this.BorderWidth));
                    this.PathPoint9Animation.set_From(new Point?(this.PathPoint9.get_Point()));
                    this.PathPoint9Animation.set_To(new Point(-1.0 * this.BorderWidth, (TargetHeight + this.BorderWidth) - this.CornerRadius.get_BottomLeft()));
                    this.PathPoint10Animation.set_From(new Point?(this.PathPoint10.get_Point()));
                    this.PathPoint10Animation.set_To(new Point(-1.0 * this.BorderWidth, (TargetHeight / 2.0) + this.HalfArrowWidth));
                    break;

                case Dock.Right:
                    this.PathPoint1Animation.set_From(new Point?(this.PathPoint1.get_Point()));
                    this.PathPoint1Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (TargetHeight / 2.0) + this.HalfArrowWidth));
                    this.PathPoint2Animation.set_From(new Point?(this.PathPoint2.get_Point()));
                    this.PathPoint2Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (TargetHeight + this.BorderWidth) - this.CornerRadius.get_BottomRight()));
                    this.PathPoint3Animation.set_From(new Point?(this.PathPoint3.get_Point()));
                    this.PathPoint3Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_BottomRight(), TargetHeight + this.BorderWidth));
                    this.PathPoint4Animation.set_From(new Point?(this.PathPoint4.get_Point()));
                    this.PathPoint4Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_BottomLeft(), TargetHeight + this.BorderWidth));
                    this.PathPoint5Animation.set_From(new Point?(this.PathPoint5.get_Point()));
                    this.PathPoint5Animation.set_To(new Point(-1.0 * this.BorderWidth, (TargetHeight + this.BorderWidth) - this.CornerRadius.get_BottomLeft()));
                    this.PathPoint6Animation.set_From(new Point?(this.PathPoint6.get_Point()));
                    this.PathPoint6Animation.set_To(new Point(-1.0 * this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft()));
                    this.PathPoint7Animation.set_From(new Point?(this.PathPoint7.get_Point()));
                    this.PathPoint7Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft(), -1.0 * this.BorderWidth));
                    this.PathPoint8Animation.set_From(new Point?(this.PathPoint8.get_Point()));
                    this.PathPoint8Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_TopRight(), -1.0 * this.BorderWidth));
                    this.PathPoint9Animation.set_From(new Point?(this.PathPoint9.get_Point()));
                    this.PathPoint9Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopRight()));
                    this.PathPoint10Animation.set_From(new Point?(this.PathPoint10.get_Point()));
                    this.PathPoint10Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (TargetHeight / 2.0) - this.HalfArrowWidth));
                    break;
            }
            this.PopupStoryboard.Begin();
        }

        private void FloatPopup_LostFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement focusedElement = FocusManager.GetFocusedElement() as FrameworkElement;
            FrameworkElement element2 = focusedElement.get_Parent() as FrameworkElement;
            while ((element2 != null) && !(element2 is FloatPopup))
            {
                focusedElement = element2;
                element2 = focusedElement.get_Parent() as FrameworkElement;
            }
            if (!(element2 is FloatPopup))
            {
                this.IsOpen = false;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.RootPopup = base.GetTemplateChild("RootPopup") as Popup;
            this.Overlay = base.GetTemplateChild("Overlay") as Canvas;
            this.BorderPath = base.GetTemplateChild("BorderPath") as Path;
            this.PopupThumb = base.GetTemplateChild("PopupThumb") as Thumb;
            this.Content = base.GetTemplateChild("Content") as FrameworkElement;
            this.BorderPathFigure = base.GetTemplateChild("BorderPathFigure") as PathFigure;
            this.PathPoint1 = base.GetTemplateChild("PathPoint1") as LineSegment;
            this.PathPoint2 = base.GetTemplateChild("PathPoint2") as LineSegment;
            this.PathPoint3 = base.GetTemplateChild("PathPoint3") as ArcSegment;
            this.PathPoint4 = base.GetTemplateChild("PathPoint4") as LineSegment;
            this.PathPoint5 = base.GetTemplateChild("PathPoint5") as ArcSegment;
            this.PathPoint6 = base.GetTemplateChild("PathPoint6") as LineSegment;
            this.PathPoint7 = base.GetTemplateChild("PathPoint7") as ArcSegment;
            this.PathPoint8 = base.GetTemplateChild("PathPoint8") as LineSegment;
            this.PathPoint9 = base.GetTemplateChild("PathPoint9") as ArcSegment;
            this.PathPoint10 = base.GetTemplateChild("PathPoint10") as LineSegment;
            this.PopupStoryboard = base.GetTemplateChild("PopupStoryboard") as Storyboard;
            this.HOffsetAnimation = base.GetTemplateChild("HOffsetAnimation") as DoubleAnimation;
            this.VOffsetAnimation = base.GetTemplateChild("VOffsetAnimation") as DoubleAnimation;
            this.WidthAnimation = base.GetTemplateChild("WidthAnimation") as DoubleAnimation;
            this.HeightAnimation = base.GetTemplateChild("HeightAnimation") as DoubleAnimation;
            this.StartPointAnimation = base.GetTemplateChild("StartPointAnimation") as PointAnimation;
            this.PathPoint1Animation = base.GetTemplateChild("PathPoint1Animation") as PointAnimation;
            this.PathPoint2Animation = base.GetTemplateChild("PathPoint2Animation") as PointAnimation;
            this.PathPoint3Animation = base.GetTemplateChild("PathPoint3Animation") as PointAnimation;
            this.PathPoint4Animation = base.GetTemplateChild("PathPoint4Animation") as PointAnimation;
            this.PathPoint5Animation = base.GetTemplateChild("PathPoint5Animation") as PointAnimation;
            this.PathPoint6Animation = base.GetTemplateChild("PathPoint6Animation") as PointAnimation;
            this.PathPoint7Animation = base.GetTemplateChild("PathPoint7Animation") as PointAnimation;
            this.PathPoint8Animation = base.GetTemplateChild("PathPoint8Animation") as PointAnimation;
            this.PathPoint9Animation = base.GetTemplateChild("PathPoint9Animation") as PointAnimation;
            this.PathPoint10Animation = base.GetTemplateChild("PathPoint10Animation") as PointAnimation;
            this.PopupStoryboard.add_Completed(new EventHandler(this.PopupStoryboard_Completed));
            this.PopupThumb.add_DragDelta(new DragDeltaEventHandler(this, (IntPtr) this.PopupThumb_DragDelta));
            this.PopupThumb.add_DragCompleted(new DragCompletedEventHandler(this, (IntPtr) this.PopupThumb_DragCompleted));
            base.add_LostFocus(new RoutedEventHandler(this, (IntPtr) this.FloatPopup_LostFocus));
        }

        public void Open(Point point, Rect rect)
        {
            this.rect = rect;
            switch (this.ArrowPlacement)
            {
                case Dock.Left:
                    this.PathPoint3.set_Size(new Size(this.CornerRadius.get_TopLeft(), this.CornerRadius.get_TopLeft()));
                    this.PathPoint5.set_Size(new Size(this.CornerRadius.get_TopRight(), this.CornerRadius.get_TopRight()));
                    this.PathPoint7.set_Size(new Size(this.CornerRadius.get_BottomRight(), this.CornerRadius.get_BottomRight()));
                    this.PathPoint9.set_Size(new Size(this.CornerRadius.get_BottomLeft(), this.CornerRadius.get_BottomLeft()));
                    this.RootPopup.set_HorizontalOffset(point.get_X() + this.HOriginOffset);
                    if ((this.RootPopup.get_HorizontalOffset() + base.get_Width()) <= rect.get_Width())
                    {
                        if (this.RootPopup.get_HorizontalOffset() < rect.get_Left())
                        {
                            this.RootPopup.set_HorizontalOffset(rect.get_Left());
                        }
                        break;
                    }
                    this.RootPopup.set_HorizontalOffset(rect.get_Width() - base.get_Width());
                    break;

                case Dock.Right:
                    this.PathPoint3.set_Size(new Size(this.CornerRadius.get_BottomRight(), this.CornerRadius.get_BottomRight()));
                    this.PathPoint5.set_Size(new Size(this.CornerRadius.get_BottomLeft(), this.CornerRadius.get_BottomLeft()));
                    this.PathPoint7.set_Size(new Size(this.CornerRadius.get_TopLeft(), this.CornerRadius.get_TopLeft()));
                    this.PathPoint9.set_Size(new Size(this.CornerRadius.get_TopRight(), this.CornerRadius.get_TopRight()));
                    this.RootPopup.set_HorizontalOffset((point.get_X() - this.HOriginOffset) - base.get_Width());
                    if ((this.RootPopup.get_HorizontalOffset() + base.get_Width()) <= rect.get_Width())
                    {
                        if (this.RootPopup.get_HorizontalOffset() < rect.get_Left())
                        {
                            this.RootPopup.set_HorizontalOffset(rect.get_Left());
                        }
                    }
                    else
                    {
                        this.RootPopup.set_HorizontalOffset(rect.get_Width() - base.get_Width());
                    }
                    this.RootPopup.set_VerticalOffset((point.get_Y() - base.get_Height()) + this.VOriginOffset);
                    if ((this.RootPopup.get_VerticalOffset() + base.get_Height()) > rect.get_Height())
                    {
                        this.RootPopup.set_VerticalOffset(rect.get_Height() - base.get_Height());
                    }
                    else if (this.RootPopup.get_VerticalOffset() < rect.get_Top())
                    {
                        this.RootPopup.set_VerticalOffset(rect.get_Top());
                    }
                    this.HOffsetAnimation.set_From(new double?(point.get_X()));
                    this.HOffsetAnimation.set_To(new double?(this.RootPopup.get_HorizontalOffset()));
                    this.VOffsetAnimation.set_From(new double?(point.get_Y()));
                    this.VOffsetAnimation.set_To(new double?(this.RootPopup.get_VerticalOffset()));
                    this.WidthAnimation.set_From(0.0);
                    this.WidthAnimation.set_To(new double?(base.get_Width()));
                    this.HeightAnimation.set_From(0.0);
                    this.HeightAnimation.set_To(new double?(base.get_Height()));
                    this.StartPointAnimation.set_From(new Point(0.0, 0.0));
                    this.StartPointAnimation.set_To(new Point(point.get_X() - this.RootPopup.get_HorizontalOffset(), point.get_Y() - this.RootPopup.get_VerticalOffset()));
                    this.PathPoint1Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint1Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (base.get_Height() / 2.0) + this.HalfArrowWidth));
                    this.PathPoint2Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint2Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (base.get_Height() + this.BorderWidth) - this.CornerRadius.get_BottomRight()));
                    this.PathPoint3Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint3Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_BottomRight(), base.get_Height() + this.BorderWidth));
                    this.PathPoint4Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint4Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_BottomLeft(), base.get_Height() + this.BorderWidth));
                    this.PathPoint5Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint5Animation.set_To(new Point(-1.0 * this.BorderWidth, (base.get_Height() + this.BorderWidth) - this.CornerRadius.get_BottomLeft()));
                    this.PathPoint6Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint6Animation.set_To(new Point(-1.0 * this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft()));
                    this.PathPoint7Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint7Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft(), -1.0 * this.BorderWidth));
                    this.PathPoint8Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint8Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_TopRight(), -1.0 * this.BorderWidth));
                    this.PathPoint9Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint9Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopRight()));
                    this.PathPoint10Animation.set_From(new Point(0.0, 0.0));
                    this.PathPoint10Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (base.get_Height() / 2.0) - this.HalfArrowWidth));
                    goto Label_0DE2;

                default:
                    goto Label_0DE2;
            }
            this.RootPopup.set_VerticalOffset((point.get_Y() - base.get_Height()) + this.VOriginOffset);
            if ((this.RootPopup.get_VerticalOffset() + base.get_Height()) > rect.get_Height())
            {
                this.RootPopup.set_VerticalOffset(rect.get_Height() - base.get_Height());
            }
            else if (this.RootPopup.get_VerticalOffset() < rect.get_Top())
            {
                this.RootPopup.set_VerticalOffset(rect.get_Top());
            }
            this.HOffsetAnimation.set_From(new double?(point.get_X()));
            this.HOffsetAnimation.set_To(new double?(this.RootPopup.get_HorizontalOffset()));
            this.VOffsetAnimation.set_From(new double?(point.get_Y()));
            this.VOffsetAnimation.set_To(new double?(this.RootPopup.get_VerticalOffset()));
            this.WidthAnimation.set_From(0.0);
            this.WidthAnimation.set_To(new double?(base.get_Width()));
            this.HeightAnimation.set_From(0.0);
            this.HeightAnimation.set_To(new double?(base.get_Height()));
            this.StartPointAnimation.set_From(new Point(0.0, 0.0));
            this.StartPointAnimation.set_To(new Point(point.get_X() - this.RootPopup.get_HorizontalOffset(), point.get_Y() - this.RootPopup.get_VerticalOffset()));
            this.PathPoint1Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint1Animation.set_To(new Point(-1.0 * this.BorderWidth, (base.get_Height() / 2.0) - this.HalfArrowWidth));
            this.PathPoint2Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint2Animation.set_To(new Point(-1.0 * this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft()));
            this.PathPoint3Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint3Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_TopLeft(), -1.0 * this.BorderWidth));
            this.PathPoint4Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint4Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_TopRight(), -1.0 * this.BorderWidth));
            this.PathPoint5Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint5Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (-1.0 * this.BorderWidth) + this.CornerRadius.get_TopRight()));
            this.PathPoint6Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint6Animation.set_To(new Point(base.get_Width() + this.BorderWidth, (base.get_Height() + this.BorderWidth) - this.CornerRadius.get_BottomRight()));
            this.PathPoint7Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint7Animation.set_To(new Point((base.get_Width() + this.BorderWidth) - this.CornerRadius.get_BottomRight(), base.get_Height() + this.BorderWidth));
            this.PathPoint8Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint8Animation.set_To(new Point((-1.0 * this.BorderWidth) + this.CornerRadius.get_BottomLeft(), base.get_Height() + this.BorderWidth));
            this.PathPoint9Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint9Animation.set_To(new Point(-1.0 * this.BorderWidth, (base.get_Height() + this.BorderWidth) - this.CornerRadius.get_BottomLeft()));
            this.PathPoint10Animation.set_From(new Point(0.0, 0.0));
            this.PathPoint10Animation.set_To(new Point(-1.0 * this.BorderWidth, (base.get_Height() / 2.0) + this.HalfArrowWidth));
        Label_0DE2:
            base.set_Width(0.0);
            base.set_Height(0.0);
            this.IsOpen = true;
            this.PopupStoryboard.Begin();
        }

        private void PopupStoryboard_Completed(object sender, EventArgs e)
        {
            this.WidthAnimation.set_From(this.WidthAnimation.get_To());
            this.HeightAnimation.set_From(this.HeightAnimation.get_To());
            base.set_Width(this.WidthAnimation.get_To().Value);
            base.set_Height(this.HeightAnimation.get_To().Value);
            if (!this.bExpanding)
            {
                if (this.StoryboardCompleted != null)
                {
                    this.StoryboardCompleted(this, new EventArgs());
                }
            }
            else
            {
                this.bExpanding = false;
                if (this.ExpandCompleted != null)
                {
                    this.ExpandCompleted(this, new EventArgs());
                }
            }
            base.Focus();
        }

        private void PopupThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
        }

        private void PopupThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this.RootPopup.set_HorizontalOffset(this.RootPopup.get_HorizontalOffset() + e.get_HorizontalChange());
            this.RootPopup.set_VerticalOffset(this.RootPopup.get_VerticalOffset() + e.get_VerticalChange());
            Point point = this.BorderPathFigure.get_StartPoint();
            point.set_X(point.get_X() - e.get_HorizontalChange());
            point.set_Y(point.get_Y() - e.get_VerticalChange());
            this.BorderPathFigure.set_StartPoint(point);
        }

        public Dock ArrowPlacement
        {
            get
            {
                return (Dock) base.GetValue(ArrowPlacementProperty);
            }
            set
            {
                base.SetValue(ArrowPlacementProperty, value);
            }
        }

        public double BorderWidth
        {
            get
            {
                return (double) base.GetValue(BorderWidthProperty);
            }
            set
            {
                base.SetValue(BorderWidthProperty, value);
            }
        }

        public System.Windows.CornerRadius CornerRadius
        {
            get
            {
                return (System.Windows.CornerRadius) base.GetValue(CornerRadiusProperty);
            }
            set
            {
                base.SetValue(CornerRadiusProperty, value);
            }
        }

        public double HalfArrowWidth
        {
            get
            {
                return (double) base.GetValue(HalfArrowWidthProperty);
            }
            set
            {
                base.SetValue(HalfArrowWidthProperty, value);
            }
        }

        public double HOriginOffset
        {
            get
            {
                return (double) base.GetValue(HOriginOffsetProperty);
            }
            set
            {
                base.SetValue(HOriginOffsetProperty, value);
            }
        }

        public bool IsOpen
        {
            get
            {
                return (bool) base.GetValue(IsOpenProperty);
            }
            set
            {
                base.SetValue(IsOpenProperty, value);
                if (this.RootPopup != null)
                {
                    this.RootPopup.set_IsOpen(value);
                }
            }
        }

        public double VOriginOffset
        {
            get
            {
                return (double) base.GetValue(VOriginOffsetProperty);
            }
            set
            {
                base.SetValue(VOriginOffsetProperty, value);
            }
        }
    }
}

