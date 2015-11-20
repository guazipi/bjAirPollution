namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    public class StationPushpin : Pushpin
    {
        public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(StationPushpin), null);
        public static readonly DependencyProperty DataVisibilityProperty = DependencyProperty.Register("DataVisibility", typeof(Visibility), typeof(StationPushpin), null);
        public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(StationPushpin), null);
        private DoubleAnimation EllipseHeightCollapseAnimation;
        private DoubleAnimation EllipseHeightExpandAnimation;
        private DoubleAnimation EllipseWidthCollapseAnimation;
        private DoubleAnimation EllipseWidthExpandAnimation;
        private ColorAnimation FocusedColorAnimation;
        public static readonly DependencyProperty FocusedDiameterProperty = DependencyProperty.Register("FocusedDiameter", typeof(double), typeof(StationPushpin), null);
        private Ellipse FocusedEllipse;
        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.Register("IsFocused", typeof(bool), typeof(StationPushpin), null);
        public static readonly DependencyProperty NoDataImageBrushProperty = DependencyProperty.Register("NoDataImageBrush", typeof(ImageBrush), typeof(StationPushpin), null);
        private Grid Root;
        private Ellipse StationEllipse;

        public StationPushpin()
        {
            base.set_DefaultStyleKey(typeof(StationPushpin));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Root = base.GetTemplateChild("Root") as Grid;
            this.StationEllipse = base.GetTemplateChild("StationEllipse") as Ellipse;
            this.StationEllipse.add_MouseEnter(new MouseEventHandler(this, (IntPtr) this.StationEllipse_MouseEnter));
            this.StationEllipse.add_MouseLeave(new MouseEventHandler(this, (IntPtr) this.StationEllipse_MouseLeave));
            this.StationEllipse.add_MouseLeftButtonDown(new MouseButtonEventHandler(this, (IntPtr) this.StationEllipse_MouseLeftButtonDown));
            this.FocusedEllipse = base.GetTemplateChild("FocusedEllipse") as Ellipse;
            this.FocusedEllipse.add_MouseLeftButtonDown(new MouseButtonEventHandler(this, (IntPtr) this.StationEllipse_MouseLeftButtonDown));
            VisualStateGroup group = VisualStateManager.GetVisualStateGroups(this.Root)[0] as VisualStateGroup;
            Storyboard storyboard = (group.get_States()[1] as VisualState).get_Storyboard();
            this.EllipseWidthExpandAnimation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
            this.EllipseHeightExpandAnimation = storyboard.get_Children().get_Item(1) as DoubleAnimation;
            Storyboard storyboard2 = (group.get_Transitions()[0] as VisualTransition).get_Storyboard();
            this.EllipseWidthCollapseAnimation = storyboard2.get_Children().get_Item(0) as DoubleAnimation;
            this.EllipseHeightCollapseAnimation = storyboard2.get_Children().get_Item(1) as DoubleAnimation;
            Storyboard storyboard3 = (group.get_States()[2] as VisualState).get_Storyboard();
            this.FocusedColorAnimation = storyboard3.get_Children().get_Item(2) as ColorAnimation;
        }

        private void StationEllipse_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.EllipseWidthExpandAnimation != null)
            {
                this.EllipseWidthExpandAnimation.set_To(new double?(this.FocusedDiameter));
            }
            if (this.EllipseHeightExpandAnimation != null)
            {
                this.EllipseHeightExpandAnimation.set_To(new double?(this.FocusedDiameter));
            }
            VisualStateManager.GoToState(this, "MouseOver", false);
        }

        private void StationEllipse_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.EllipseWidthCollapseAnimation != null)
            {
                this.EllipseWidthCollapseAnimation.set_To(new double?(this.Diameter));
            }
            if (this.EllipseHeightCollapseAnimation != null)
            {
                this.EllipseHeightCollapseAnimation.set_To(new double?(this.Diameter));
            }
            VisualStateManager.GoToState(this, "Normal", true);
        }

        private void StationEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Visibility dataVisibility = this.DataVisibility;
        }

        public Thickness ContentMargin
        {
            get
            {
                return (Thickness) base.GetValue(ContentMarginProperty);
            }
            set
            {
                base.SetValue(ContentMarginProperty, value);
            }
        }

        public Visibility DataVisibility
        {
            get
            {
                return (Visibility) base.GetValue(DataVisibilityProperty);
            }
            set
            {
                base.SetValue(DataVisibilityProperty, value);
                this.StationEllipse.set_Visibility(this.DataVisibility);
            }
        }

        public double Diameter
        {
            get
            {
                return (double) base.GetValue(DiameterProperty);
            }
            set
            {
                base.SetValue(DiameterProperty, value);
            }
        }

        public double FocusedDiameter
        {
            get
            {
                return (double) base.GetValue(FocusedDiameterProperty);
            }
            set
            {
                base.SetValue(FocusedDiameterProperty, value);
            }
        }

        public bool IsFocused
        {
            get
            {
                return (bool) base.GetValue(IsFocusedProperty);
            }
            set
            {
                base.SetValue(IsFocusedProperty, value);
                if (value)
                {
                    if (this.FocusedColorAnimation != null)
                    {
                        this.FocusedColorAnimation.set_From(new Color?(((SolidColorBrush) base.get_Background()).get_Color()));
                    }
                    VisualStateManager.GoToState(this, "Focused", false);
                }
                else
                {
                    if (this.DataVisibility == null)
                    {
                        this.StationEllipse.set_Visibility(0);
                    }
                    this.FocusedEllipse.set_Visibility(1);
                    VisualStateManager.GoToState(this, "Normal", false);
                }
            }
        }

        public ImageBrush NoDataImageBrush
        {
            get
            {
                return (ImageBrush) base.GetValue(NoDataImageBrushProperty);
            }
            set
            {
                base.SetValue(NoDataImageBrushProperty, value);
            }
        }
    }
}

