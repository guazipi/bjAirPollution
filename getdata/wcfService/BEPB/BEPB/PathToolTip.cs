namespace BEPB
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class PathToolTip : ToolTip
    {
        public static readonly DependencyProperty ArrowHeightProperty = DependencyProperty.Register("ArrowHeight", typeof(double), typeof(PathToolTip), null);
        private RowDefinition ArrowRow;
        private LineSegment BottomCenterLeft;
        private LineSegment BottomCenterRight;
        private LineSegment BottomLeftCorner1;
        private ArcSegment BottomLeftCorner2;
        private LineSegment BottomRightCorner1;
        private ArcSegment BottomRightCorner2;
        public static readonly DependencyProperty MapScaleProperty = DependencyProperty.Register("MapScale", typeof(double), typeof(PathToolTip), null);
        private Border Root;
        private PathFigure ToolTipPathFigure;
        private LineSegment TopLeftCorner1;
        private ArcSegment TopLeftCorner2;
        private LineSegment TopRightCorner1;
        private ArcSegment TopRightCorner2;

        public PathToolTip()
        {
            base.set_DefaultStyleKey(typeof(PathToolTip));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = base.MeasureOverride(availableSize);
            this.ArrowRow.set_Height(new GridLength(this.ArrowHeight));
            this.ToolTipPathFigure.set_StartPoint(new Point(14.0, size.get_Height()));
            this.BottomCenterLeft.set_Point(new Point((size.get_Width() / 2.0) - 10.0, size.get_Height() - this.ArrowHeight));
            this.BottomLeftCorner1.set_Point(new Point(this.Root.get_CornerRadius().get_BottomLeft(), size.get_Height() - this.ArrowHeight));
            this.BottomLeftCorner2.set_Point(new Point(0.0, (size.get_Height() - this.ArrowHeight) - this.Root.get_CornerRadius().get_BottomLeft()));
            this.BottomLeftCorner2.set_Size(new Size(this.Root.get_CornerRadius().get_BottomLeft(), this.Root.get_CornerRadius().get_BottomLeft()));
            this.TopLeftCorner1.set_Point(new Point(0.0, this.Root.get_CornerRadius().get_TopLeft()));
            this.TopLeftCorner2.set_Point(new Point(this.Root.get_CornerRadius().get_TopLeft(), 0.0));
            this.TopLeftCorner2.set_Size(new Size(this.Root.get_CornerRadius().get_TopLeft(), this.Root.get_CornerRadius().get_TopLeft()));
            this.TopRightCorner1.set_Point(new Point(size.get_Width() - this.Root.get_CornerRadius().get_TopRight(), 0.0));
            this.TopRightCorner2.set_Point(new Point(size.get_Width(), this.Root.get_CornerRadius().get_TopRight()));
            this.TopRightCorner2.set_Size(new Size(this.Root.get_CornerRadius().get_TopRight(), this.Root.get_CornerRadius().get_TopRight()));
            double introduced17 = size.get_Width();
            this.BottomRightCorner1.set_Point(new Point(introduced17, (size.get_Height() - this.ArrowHeight) - this.Root.get_CornerRadius().get_BottomRight()));
            this.BottomRightCorner2.set_Point(new Point(size.get_Width() - this.Root.get_CornerRadius().get_BottomRight(), size.get_Height() - this.ArrowHeight));
            this.BottomRightCorner2.set_Size(new Size(this.Root.get_CornerRadius().get_BottomRight(), this.Root.get_CornerRadius().get_BottomRight()));
            this.BottomCenterRight.set_Point(new Point((size.get_Width() / 2.0) + 10.0, size.get_Height() - this.ArrowHeight));
            return size;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Root = base.GetTemplateChild("Root") as Border;
            this.ArrowRow = base.GetTemplateChild("ArrowRow") as RowDefinition;
            this.ToolTipPathFigure = base.GetTemplateChild("ToolTipPathFigure") as PathFigure;
            this.BottomCenterLeft = base.GetTemplateChild("BottomCenterLeft") as LineSegment;
            this.BottomLeftCorner1 = base.GetTemplateChild("BottomLeftCorner1") as LineSegment;
            this.BottomLeftCorner2 = base.GetTemplateChild("BottomLeftCorner2") as ArcSegment;
            this.TopLeftCorner1 = base.GetTemplateChild("TopLeftCorner1") as LineSegment;
            this.TopLeftCorner2 = base.GetTemplateChild("TopLeftCorner2") as ArcSegment;
            this.TopRightCorner1 = base.GetTemplateChild("TopRightCorner1") as LineSegment;
            this.TopRightCorner2 = base.GetTemplateChild("TopRightCorner2") as ArcSegment;
            this.BottomRightCorner1 = base.GetTemplateChild("BottomRightCorner1") as LineSegment;
            this.BottomRightCorner2 = base.GetTemplateChild("BottomRightCorner2") as ArcSegment;
            this.BottomCenterRight = base.GetTemplateChild("BottomCenterRight") as LineSegment;
        }

        public double ArrowHeight
        {
            get
            {
                return (double) base.GetValue(ArrowHeightProperty);
            }
            set
            {
                base.SetValue(ArrowHeightProperty, value);
            }
        }

        public double MapScale
        {
            get
            {
                return (double) base.GetValue(MapScaleProperty);
            }
            set
            {
                base.SetValue(MapScaleProperty, value);
            }
        }
    }
}

