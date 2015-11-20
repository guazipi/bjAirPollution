namespace BEPB
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    public class TabButton : ToggleButton
    {
        public static readonly DependencyProperty TabStripPlacementProperty = DependencyProperty.Register("TabStripPlacement", typeof(Dock), typeof(TabButton), null);
        private Grid TopLeftSelectedGrid;
        private Grid TopLeftUnselectedGrid;
        private Grid TopRightSelectedGrid;
        private Grid TopRightUnselectedGrid;

        public TabButton()
        {
            base.set_DefaultStyleKey(typeof(TabButton));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.TopLeftSelectedGrid = base.GetTemplateChild("TemplateTopLeftSelected");
            this.TopLeftUnselectedGrid = base.GetTemplateChild("TemplateTopLeftUnselected");
            this.TopRightSelectedGrid = base.GetTemplateChild("TemplateTopRightSelected");
            this.TopRightUnselectedGrid = base.GetTemplateChild("TemplateTopRightUnselected");
            switch (this.TabStripPlacement)
            {
                case Dock.Left:
                    this.TopLeftSelectedGrid.set_Visibility(0);
                    break;

                case Dock.Right:
                    this.TopRightSelectedGrid.set_Visibility(0);
                    break;
            }
            base.add_Checked(new RoutedEventHandler(this, (IntPtr) this.TabButton_Checked));
        }

        private void TabButton_Checked(object sender, RoutedEventArgs e)
        {
            if (base.get_IsChecked() == true)
            {
                switch (this.TabStripPlacement)
                {
                    case Dock.Left:
                        this.TopLeftSelectedGrid.set_Visibility(0);
                        return;

                    case Dock.Top:
                        return;

                    case Dock.Right:
                        this.TopRightSelectedGrid.set_Visibility(0);
                        return;
                }
            }
            else
            {
                switch (this.TabStripPlacement)
                {
                    case Dock.Left:
                        this.TopLeftUnselectedGrid.set_Visibility(0);
                        return;

                    case Dock.Top:
                        break;

                    case Dock.Right:
                        this.TopRightUnselectedGrid.set_Visibility(0);
                        break;

                    default:
                        return;
                }
            }
        }

        public Dock TabStripPlacement
        {
            get
            {
                return (Dock) base.GetValue(TabStripPlacementProperty);
            }
            set
            {
                base.SetValue(TabStripPlacementProperty, value);
            }
        }
    }
}

