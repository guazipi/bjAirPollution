namespace BEPB
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    [TemplatePart(Name="Content", Type=typeof(ListBox))]
    public class Marquee : Control
    {
        private DataGrid AlertDataGrid;
        private DoubleAnimation AlertExpandAnimation;
        private Storyboard AlertExpandStoryboard;
        public static readonly DependencyProperty AlertLevelProperty = DependencyProperty.Register("AlertLevel", typeof(BEPB.AlertLevel), typeof(Marquee), null);
        public static readonly DependencyProperty AlertMsgProperty = DependencyProperty.Register("AlertMsg", typeof(AlertMessage), typeof(Marquee), null);
        private Border AlertTypeDescBorder;
        private double AlertTypeDescBorderHeight = 156.0;
        private App app = (Application.get_Current() as App);
        private const double BaseSpeed = 25.0;
        private bool bExpanded = true;
        private bool bOpened = true;
        private ToggleButton btnAlertExpand;
        private double CaptionHeight = 25.0;
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(Marquee), null);
        private double ClipHeight;
        private double ClipLeft;
        private double ClipTop;
        private double ClipWidth;
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(System.Windows.CornerRadius), typeof(Marquee), null);
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(BEPB.Direction), typeof(Marquee), null);
        private DoubleAnimation DownAnimation;
        private DoubleAnimation LeftAnimation;
        private ListBox MessagesListBox;
        public static readonly DependencyProperty MessagesProperty = DependencyProperty.Register("Messages", typeof(ObservableCollection<AlertMessage>), typeof(Marquee), null);
        private Storyboard MoveDown;
        private Storyboard MoveLeft;
        private Storyboard MoveRight;
        private double MoveTo;
        private Storyboard MoveUp;
        private StackPanel MsgContent;
        private DoubleAnimation RightAnimation;
        private Border Root;
        private DoubleAnimation SlideAnimation;
        private Storyboard SlideInOut;
        public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(double), typeof(Marquee), null);
        private DoubleAnimation UpAnimation;

        public Marquee()
        {
            base.set_DefaultStyleKey(typeof(Marquee));
            this.Messages = new ObservableCollection<AlertMessage>();
        }

        private void AlertExpandStoryboard_Completed(object sender, EventArgs e)
        {
            if (!this.bExpanded)
            {
                this.AlertTypeDescBorder.set_Visibility(0);
                this.AlertTypeDescBorder.set_Height(this.AlertTypeDescBorderHeight);
                this.bExpanded = true;
                this.btnAlertExpand.set_Background(this.Root.get_Resources().get_Item("CollapsedImageBrush") as ImageBrush);
            }
            else
            {
                this.AlertTypeDescBorder.set_Visibility(1);
                this.AlertTypeDescBorder.set_Height(0.0);
                this.bExpanded = false;
                this.btnAlertExpand.set_Background(this.Root.get_Resources().get_Item("ExpandImageBrush") as ImageBrush);
            }
        }

        private void btnAlertExpand_Click(object sender, RoutedEventArgs e)
        {
            if (!this.bExpanded)
            {
                this.AlertTypeDescBorder.set_Visibility(0);
                this.AlertTypeDescBorder.set_Height(0.0);
                this.AlertExpandAnimation.set_From(0.0);
                this.AlertExpandAnimation.set_To(new double?(this.AlertTypeDescBorderHeight));
            }
            else
            {
                this.AlertExpandAnimation.set_From(new double?(this.AlertTypeDescBorderHeight));
                this.AlertExpandAnimation.set_To(0.0);
            }
            this.AlertExpandStoryboard.Begin();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Root.set_Opacity(0.0);
            this.bOpened = false;
        }

        private void MoveUp_Completed(object sender, EventArgs e)
        {
            if (this.Direction == BEPB.Direction.Up)
            {
                if ((this.MessagesListBox.get_ActualHeight() + this.MoveTo) == 0.0)
                {
                    this.UpAnimation.set_From(new double?(this.ClipHeight));
                    double num = this.ClipHeight / (25.0 * this.Speed);
                    int hours = ((int) num) / 0xe10;
                    int minutes = (int) ((num - (hours * 0xe10)) / 60.0);
                    int seconds = (((int) num) - (hours * 0xe10)) - (minutes * 60);
                    TimeSpan span = new TimeSpan(hours, minutes, seconds);
                    this.UpAnimation.set_Duration(new Duration(span));
                    this.MoveTo = 0.0;
                }
                else if ((this.MessagesListBox.get_ActualHeight() + this.MoveTo) > this.ClipHeight)
                {
                    this.UpAnimation.set_From(new double?(this.MoveTo));
                    this.MoveTo -= this.ClipHeight;
                }
                else
                {
                    this.UpAnimation.set_From(new double?(this.MoveTo));
                    double num5 = (this.MessagesListBox.get_ActualHeight() + this.MoveTo) / (25.0 * this.Speed);
                    int num6 = ((int) num5) / 0xe10;
                    int num7 = (int) ((num5 - (num6 * 0xe10)) / 60.0);
                    int num8 = (((int) num5) - (num6 * 0xe10)) - (num7 * 60);
                    TimeSpan span2 = new TimeSpan(num6, num7, num8);
                    this.UpAnimation.set_Duration(new Duration(span2));
                    this.MoveTo = -1.0 * this.MessagesListBox.get_ActualHeight();
                }
                this.UpAnimation.set_To(new double?(this.MoveTo));
                this.MoveUp.Begin();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            base.GetTemplateChild("thumb").add_DragDelta(new DragDeltaEventHandler(this, (IntPtr) this.thumb_DragDelta));
            this.MessagesListBox = base.GetTemplateChild("Content");
            this.MessagesListBox.set_Width((base.get_Width() - (base.get_BorderThickness().get_Left() + base.get_BorderThickness().get_Right())) - (base.get_Padding().get_Left() + base.get_Padding().get_Right()));
            this.MsgContent = base.GetTemplateChild("MsgContent");
            this.MsgContent.set_Width((base.get_Width() - (base.get_BorderThickness().get_Left() + base.get_BorderThickness().get_Right())) - (base.get_Padding().get_Left() + base.get_Padding().get_Right()));
            this.MsgContent.set_DataContext(this.AlertMsg);
            this.AlertTypeDescBorder = base.GetTemplateChild("AlertTypeDescBorder");
            this.AlertTypeDescBorder.set_Width((base.get_Width() - (base.get_BorderThickness().get_Left() + base.get_BorderThickness().get_Right())) - (base.get_Padding().get_Left() + base.get_Padding().get_Right()));
            this.AlertDataGrid = base.GetTemplateChild("AlertDataGrid");
            this.AlertDataGrid.Columns[1].Header = "预警级别";
            this.AlertDataGrid.Columns[2].Header = "说            明";
            this.AlertDataGrid.ItemsSource = this.app.AlertLevelDescsList;
            this.btnAlertExpand = base.GetTemplateChild("btnAlertExpand");
            this.btnAlertExpand.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnAlertExpand_Click));
            this.AlertExpandStoryboard = base.GetTemplateChild("AlertExpandStoryboard");
            this.AlertExpandStoryboard.add_Completed(new EventHandler(this.AlertExpandStoryboard_Completed));
            this.AlertExpandAnimation = base.GetTemplateChild("AlertExpandAnimation");
            double range = 0.0;
            switch (this.Direction)
            {
                case BEPB.Direction.Up:
                    this.MoveTo = 0.0;
                    this.UpAnimation = base.GetTemplateChild("UpAnimation");
                    this.UpAnimation.set_From(new double?(this.ClipHeight / 2.0));
                    this.UpAnimation.set_To(new double?(this.MoveTo));
                    range = this.ClipHeight / 2.0;
                    this.MoveUp = base.GetTemplateChild("MoveUp");
                    this.MoveUp.add_Completed(new EventHandler(this.MoveUp_Completed));
                    break;

                case BEPB.Direction.Down:
                    this.MoveTo = this.ClipHeight;
                    this.DownAnimation = base.GetTemplateChild("DownAnimation");
                    this.DownAnimation.set_From(0.0);
                    this.DownAnimation.set_To(new double?(this.MoveTo));
                    range = this.ClipHeight;
                    this.MoveDown = base.GetTemplateChild("MoveDown");
                    this.MoveDown.Begin();
                    break;

                case BEPB.Direction.Left:
                    this.MoveTo = 0.0;
                    this.LeftAnimation = base.GetTemplateChild("LeftAnimation");
                    this.LeftAnimation.set_From(new double?(this.ClipWidth));
                    this.LeftAnimation.set_To(new double?(this.MoveTo));
                    range = this.ClipWidth;
                    this.MoveLeft = base.GetTemplateChild("MoveLeft");
                    this.MoveLeft.Begin();
                    break;

                case BEPB.Direction.Right:
                    this.MoveTo = this.ClipWidth;
                    this.RightAnimation = base.GetTemplateChild("RightAnimation");
                    this.RightAnimation.set_From(0.0);
                    this.RightAnimation.set_To(new double?(this.MoveTo));
                    range = this.ClipWidth;
                    this.MoveRight = base.GetTemplateChild("MoveRight");
                    this.MoveRight.Begin();
                    break;
            }
            this.SetAnimationDuration(range);
            Button templateChild = base.GetTemplateChild("btnClose");
            templateChild.set_Content("关闭");
            templateChild.add_Click(new RoutedEventHandler(this, (IntPtr) this.btnClose_Click));
            this.Root = base.GetTemplateChild("Root");
            this.SlideAnimation = base.GetTemplateChild("SlideAnimation");
            this.SlideInOut = base.GetTemplateChild("SlideInOut");
            this.SlideInOut.add_Completed(new EventHandler(this.SlideInOut_Completed));
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            switch (this.Direction)
            {
                case BEPB.Direction.Up:
                    this.MoveUp.Pause();
                    return;

                case BEPB.Direction.Down:
                    this.MoveDown.Pause();
                    return;

                case BEPB.Direction.Left:
                    this.MoveLeft.Pause();
                    return;

                case BEPB.Direction.Right:
                    this.MoveRight.Pause();
                    return;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            switch (this.Direction)
            {
                case BEPB.Direction.Up:
                    this.MoveUp.Resume();
                    return;

                case BEPB.Direction.Down:
                    this.MoveDown.Resume();
                    return;

                case BEPB.Direction.Left:
                    this.MoveLeft.Resume();
                    return;

                case BEPB.Direction.Right:
                    this.MoveRight.Resume();
                    return;
            }
        }

        public void Open()
        {
            if ((this.SlideAnimation != null) && !this.bOpened)
            {
                this.SlideAnimation.set_From(0.0);
                this.SlideAnimation.set_To(1.0);
                this.SlideInOut.Begin();
                this.bOpened = true;
            }
        }

        private void SetAnimationDuration(double Range)
        {
            double num = Range / (25.0 * this.Speed);
            int hours = ((int) num) / 0xe10;
            int minutes = (int) ((num - (hours * 0xe10)) / 60.0);
            int seconds = (((int) num) - (hours * 0xe10)) - (minutes * 60);
            TimeSpan span = new TimeSpan(hours, minutes, seconds);
            Duration duration = new Duration(span);
            switch (this.Direction)
            {
                case BEPB.Direction.Up:
                    this.UpAnimation.set_Duration(duration);
                    return;

                case BEPB.Direction.Down:
                    this.DownAnimation.set_Duration(duration);
                    return;

                case BEPB.Direction.Left:
                    this.LeftAnimation.set_Duration(duration);
                    return;

                case BEPB.Direction.Right:
                    this.RightAnimation.set_Duration(duration);
                    return;
            }
        }

        private void SlideInOut_Completed(object sender, EventArgs e)
        {
            if (this.SlideAnimation.get_To() == 0.0)
            {
                this.bOpened = false;
            }
            else
            {
                this.bOpened = true;
            }
        }

        private void thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (base.get_Parent() is Canvas)
            {
                double a = (double) base.GetValue(Canvas.LeftProperty);
                double num2 = (double) base.GetValue(Canvas.TopProperty);
                a += e.get_HorizontalChange();
                num2 += e.get_VerticalChange();
                if (a < 0.0)
                {
                    a = 0.0;
                }
                if (a > (base.get_Parent() as Canvas).get_ActualWidth())
                {
                    a = (base.get_Parent() as Canvas).get_ActualWidth() - base.get_ActualWidth();
                }
                if (num2 < 0.0)
                {
                    num2 = 0.0;
                }
                if (num2 > ((base.get_Parent() as Canvas).get_ActualHeight() - base.get_ActualHeight()))
                {
                    a = (base.get_Parent() as Canvas).get_ActualHeight() - base.get_ActualHeight();
                }
                base.SetValue(Canvas.LeftProperty, Math.Round(a));
                base.SetValue(Canvas.TopProperty, Math.Round(num2));
            }
            else
            {
                HorizontalAlignment alignment = (HorizontalAlignment) base.GetValue(FrameworkElement.HorizontalAlignmentProperty);
                VerticalAlignment alignment2 = (VerticalAlignment) base.GetValue(FrameworkElement.VerticalAlignmentProperty);
                double num3 = base.get_Margin().get_Left();
                double num4 = base.get_Margin().get_Right();
                double num5 = base.get_Margin().get_Top();
                double num6 = base.get_Margin().get_Bottom();
                switch (alignment)
                {
                    case 0:
                        num3 += e.get_HorizontalChange();
                        if (num3 < 0.0)
                        {
                            num3 = 0.0;
                        }
                        if (num3 > ((base.get_Parent() as Grid).get_ActualWidth() - base.get_ActualWidth()))
                        {
                            num3 = (base.get_Parent() as Grid).get_ActualWidth() - base.get_ActualWidth();
                        }
                        break;

                    case 2:
                        num4 -= e.get_HorizontalChange();
                        if (num4 < 0.0)
                        {
                            num4 = 0.0;
                        }
                        if (num4 > ((base.get_Parent() as Grid).get_ActualWidth() - base.get_ActualWidth()))
                        {
                            num4 = (base.get_Parent() as Grid).get_ActualWidth() - base.get_ActualWidth();
                        }
                        break;
                }
                switch (alignment2)
                {
                    case 0:
                        num5 += e.get_VerticalChange();
                        if (num5 < 0.0)
                        {
                            num5 = 0.0;
                        }
                        if (num5 > ((base.get_Parent() as Grid).get_ActualHeight() - base.get_ActualHeight()))
                        {
                            num5 = (base.get_Parent() as Grid).get_ActualHeight() - base.get_ActualHeight();
                        }
                        break;

                    case 2:
                        num6 -= e.get_VerticalChange();
                        if (num6 < 0.0)
                        {
                            num6 = 0.0;
                        }
                        if (num6 > ((base.get_Parent() as Grid).get_ActualHeight() - base.get_ActualHeight()))
                        {
                            num6 = (base.get_Parent() as Grid).get_ActualHeight() - base.get_ActualHeight();
                        }
                        break;
                }
                base.set_Margin(new Thickness(num3, num5, num4, num6));
            }
        }

        public BEPB.AlertLevel AlertLevel
        {
            get
            {
                return (BEPB.AlertLevel) base.GetValue(AlertLevelProperty);
            }
            set
            {
                base.SetValue(AlertLevelProperty, value);
            }
        }

        public AlertMessage AlertMsg
        {
            get
            {
                return (AlertMessage) base.GetValue(AlertMsgProperty);
            }
            set
            {
                base.SetValue(AlertMsgProperty, value);
            }
        }

        public string Caption
        {
            get
            {
                return (string) base.GetValue(CaptionProperty);
            }
            set
            {
                base.SetValue(CaptionProperty, value);
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

        public BEPB.Direction Direction
        {
            get
            {
                return (BEPB.Direction) base.GetValue(DirectionProperty);
            }
            set
            {
                base.SetValue(DirectionProperty, value);
            }
        }

        public ObservableCollection<AlertMessage> Messages
        {
            get
            {
                return (ObservableCollection<AlertMessage>) base.GetValue(MessagesProperty);
            }
            set
            {
                base.SetValue(MessagesProperty, value);
            }
        }

        public double Speed
        {
            get
            {
                return (double) base.GetValue(SpeedProperty);
            }
            set
            {
                if (value > 0.0)
                {
                    base.SetValue(SpeedProperty, value);
                    if (this.MessagesListBox != null)
                    {
                        this.SetAnimationDuration(this.ClipHeight);
                    }
                }
            }
        }
    }
}

