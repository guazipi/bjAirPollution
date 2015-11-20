namespace BEPB
{
    using BEPB.DataServiceReference;
    using Microsoft.Maps.MapControl;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Json;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using System.Security.Cryptography;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Text;
    using System.Windows;
    using System.Windows.Browser;
    using System.Windows.Controls;
    using System.Windows.Controls.DataVisualization.Charting;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    public class MainPage : UserControl
    {
        private bool _contentLoaded;
        internal Image Actually;
        internal DoubleAnimation ActuallyExpandAnimation;
        internal Border ActuallyFrame;
        internal Grid ActuallyFrame_Old;
        internal Grid ActuallyGrid;
        internal ColumnDefinition ActuallyLeftTabItem;
        internal Grid ActuallyPanelHeader;
        internal ColumnDefinition ActuallyRightTabItem;
        private double ActuallyTabItemWidth = 160.0;
        private AirDataContext airDataContext;
        internal Border AirQualityFrame;
        internal Marquee AlertWnd;
        internal Grid aqi_26;
        internal Grid aqi_27;
        internal Grid aqi_28;
        internal Grid aqi_29;
        internal Grid aqi_30;
        internal DataGrid AQIDataGrid;
        internal Ellipse aqiEllipse1;
        internal Ellipse aqiEllipse2;
        internal Ellipse aqiEllipse3;
        internal Ellipse aqiEllipse4;
        internal Ellipse aqiEllipse5;
        internal Ellipse aqiEllipse6;
        internal DoubleAnimation AQIExpandAnimation;
        internal Grid AQIPanel;
        internal Grid AQIPopupBackground;
        internal Border AQIPopupBorder;
        internal Grid AQIPopupBottom;
        internal TabItem AQITabItem;
        internal Grid AQITabItemGrid;
        private Location BeijingCenter;
        private double BeijingEast = 117.54;
        private double BeijingNorth = 41.1;
        private double BeijingSouth = 39.4;
        private double BeijingWest = 115.39;
        private bool bLeftFrameExpanded = true;
        private bool bMoveAnimating;
        private Brush brFive;
        private BSMapMode bsMapMode;
        internal ToggleButton btn_dx;
        internal ToggleButton btn_sl;
        internal ToggleButton btn_yx;
        internal PushedImageButton btnActuallyExpand;
        internal Button btnAlertMessage;
        internal ToggleButton btnAQIExpand;
        internal ToggleButton btnExpand;
        internal TextBlock btnExpandTooTip;
        internal PushedImageButton btnForecastExpand;
        internal PushedImageButton btnQualityExpand;
        internal ToggleButton btnWRWExpand;
        internal BusyIndicator busyIndicator;
        private bool bWRWDataLoaded;
        internal MapPolygon ChangPing;
        internal MapPolygon ChaoYang;
        internal MapPolygon CityCenter;
        internal MapPolygon CityCenterBorder;
        internal MapPolygon CityCenterBorder2;
        internal Pushpin CityCenterText;
        private DataGridFrozenGrid Clicked_FrozenGrid;
        private StationPushpin ClickedStation;
        internal Storyboard COStoryboard;
        internal Storyboard COStoryboard_Old;
        private string CurrentChannelName = "";
        private string CurrentWRWName = "";
        private DataServiceClient dataService;
        internal MapPolygon DaXing;
        internal Border DayForecastPanel;
        internal DataGrid dgAQI;
        internal DataGrid dgAQI_Old;
        private bool dgAQIDataGridRowClicked;
        internal DataGrid dgAQIDetailText;
        internal Grid dgAQIGrid;
        internal DataGrid dgWRW;
        internal DataGrid dgWRW_Old;
        private bool dgWRWDataGridRowClicked;
        internal MapLayer Districts;
        internal MapLayer DistrictsName;
        internal MapPolygon DongCheng;
        private DispatcherTimer DoubleClickTimer;
        private Location DowntownCenter;
        private double EndZoomLevel = 9.0;
        internal MapTileLayer epbMapTileLayer;
        internal Storyboard Expand;
        internal Grid ExpandButtonGrid;
        internal MapPolygon FangShan;
        internal MapPolygon FengTai;
        internal MapLayer Five;
        internal FloatPopup FloatAQIPopup;
        internal FloatPopup FloatForecastPopup;
        internal FloatPopup FloatWRWPopup;
        internal ColumnDefinition ForecaseLeftTabItem;
        internal ColumnDefinition ForecaseRightTabItem;
        internal Image Forecast;
        internal Border ForecastBorder;
        internal Grid ForecastDay;
        internal Grid ForecastDayStationName;
        internal DoubleAnimation ForecastExpandAnimation;
        internal DataGrid forecastGrid;
        internal Border ForecastGridBorder;
        internal Grid forecastMsg;
        internal Grid ForecastNight;
        internal Grid ForecastNightConent;
        internal Grid ForecastNightStationName;
        internal Grid ForecastPanelHeader;
        internal Grid ForecastPopupHeader;
        private double ForecastTabItemWidth = 174.0;
        private int FrozenGrid_ClickedTimes;
        internal MapPolygon HaiDian;
        internal MapPolygon HuaiRou;
        public bool IsFirst = true;
        private MapPolygon LastSelectedFive;
        private Brush LastSelectedFiveBrush;
        private StationPushpin LastStation;
        private DateTime LastStationClick;
        internal Grid LayoutRoot;
        internal Run lbl_DateTime_AQI;
        internal Run lbl_DateTime_Old;
        internal Run lbl_DateTime_WRW;
        internal Grid LeftFrame;
        internal DoubleAnimation LeftFrameExpandAnimation;
        internal Storyboard LeftFrameNewExpand;
        internal Rectangle LeftFrameTopRectangle;
        internal Rectangle LeftFrameTopRectangle_Old;
        private double LeftFrameWidth = 420.0;
        internal Rectangle LeftFrameWrwCollapsedBottomRectangle;
        internal Rectangle Line1;
        internal Rectangle Line2;
        internal Rectangle Line3;
        internal Rectangle Line4;
        private double LineLength = 172.0;
        internal CMap map;
        internal MapLayer MapMask;
        internal TextBox MapRange;
        private double mapScale = 1.0;
        internal MapLayer MapStations;
        internal MapPolygon MenTouGou;
        internal MapPolygon MiYun;
        internal Image Mobile;
        internal BEPB.NavigationCtrl NavigationCtrl;
        internal Storyboard NO2Storyboard;
        internal Storyboard NO2Storyboard_Old;
        internal MapPolygon NorthEast;
        internal MapPolygon NorthEastBorder;
        internal Pushpin NorthEastText;
        internal MapPolygon NorthWest;
        internal MapPolygon NorthWestBorder;
        internal Pushpin NorthWestText;
        internal Storyboard O31Storyboard;
        internal Storyboard O31Storyboard_Old;
        internal Image p_aqi_detail;
        internal Image p_bottom_aqi;
        internal StackPanel p_bottom_aqiGrid;
        internal MapPolygon PingGu;
        internal Storyboard PM10Storyboard;
        internal Storyboard PM10Storyboard_Old;
        internal Storyboard PM25Storyboard;
        internal Storyboard PM25Storyboard_Old;
        private Location PopNorthEast1 = new Location(40.4, 117.55);
        private Location PopNorthEast2 = new Location(40.74, 117.01);
        private Location PopNorthWest1 = new Location(40.65, 115.78);
        private Location PopNorthWest2 = new Location(40.18, 115.65);
        private Location PopSouthEast1 = new Location(39.95, 117.03);
        private Location PopSouthEast2 = new Location(40.15, 117.45);
        private Location PopSouthWest = new Location(40.1, 115.3);
        private double PopupHOriginOffset = 200.0;
        private double PopupVOriginOffset = 100.0;
        internal Image Quality;
        internal DoubleAnimation QualityExpandAnimation;
        internal Grid QualityGrid;
        internal Grid QualityHeader;
        internal ColumnDefinition QualityLeftTabItem;
        internal Grid QualityPanelHeader;
        internal ColumnDefinition QualityRightTabItem;
        internal ListBox RenderImagesListBox;
        private double screenHeight;
        private double screenWidth;
        internal MapPolygon ShiJingShan;
        internal MapPolygon ShunYi;
        internal Storyboard SO2Storyboard;
        internal Storyboard SO2Storyboard_Old;
        internal MapPolygon SouthEast;
        internal MapPolygon SouthEastBorder;
        internal Pushpin SouthEastText;
        internal MapPolygon SouthWest;
        internal MapPolygon SouthWestBorder;
        internal Pushpin SouthWestText;
        private double StartZoomLevel = 8.0;
        internal Image Support;
        internal TabControl Tab;
        internal Grid TabDiv;
        internal Grid TabDivActually;
        internal Grid TabDivQuality;
        private DispatcherTimer timer;
        internal MapPolygon TongZhou;
        internal TextBlock txtbWebCounts;
        internal ToggleButton wrw_co;
        internal ToggleButton wrw_co_Old;
        internal ToggleButton wrw_no2;
        internal ToggleButton wrw_no2_Old;
        internal ToggleButton wrw_o31;
        internal ToggleButton wrw_o31_Old;
        internal ToggleButton wrw_pm10;
        internal ToggleButton wrw_pm10_Old;
        internal ToggleButton wrw_pm25;
        internal ToggleButton wrw_pm25_Old;
        internal ToggleButton wrw_so2;
        internal ToggleButton wrw_so2_Old;
        internal Canvas wrwButtons;
        internal Canvas wrwButtons_Old;
        internal Border wrwButtonsBorder;
        internal Border wrwButtonsBorder_Old;
        private int WRWChannelClicked = 1;
        internal Chart WRWChart;
        internal Grid WRWChartPanel;
        internal TextBlock WRWChartText;
        internal TextBlock WRWChartTitle;
        internal DoubleAnimation WRWExpandAnimation;
        internal Grid WRWPopupBackground;
        internal Border WRWPopupBorder;
        internal Grid wrwqp_11;
        internal Grid wrwqp_12;
        internal Grid wrwqp_16;
        internal Grid wrwqp_8;
        internal Grid wrwqp_9;
        private int WRWTabClicked;
        internal TabItem WRWTabItem;
        internal Grid WRWTabItemGrid;
        internal Image wrwtl;
        internal TextBlock wrwtlData;
        internal Grid wrwtlGrid;
        internal Rectangle wrwtlRect1;
        internal Rectangle wrwtlRect2;
        internal Rectangle wrwtlRect3;
        internal Rectangle wrwtlRect4;
        internal Rectangle wrwtlRect5;
        internal Rectangle wrwtlRect6;
        internal TextBlock wrwtlTitle;
        internal DateTimeAxis XAxis;
        internal MapPolygon XiCheng;
        internal MapPolygon YanQing;
        internal LinearAxis YAxis;
        internal Grid yb_2;
        internal Grid yb_30;
        internal Grid yb_39;
        internal Grid yb_40;
        internal Grid yb_61;
        internal Grid yb_62;
        internal Grid yb_65;
        internal Grid yb_66;
        internal Grid yb_jl4_2;
        internal Pushpin 昌平区Name;
        internal Pushpin 朝阳区Name;
        internal Pushpin 大兴区Name;
        internal Pushpin 东城区Name;
        internal Pushpin 房山区Name;
        internal Pushpin 丰台区Name;
        internal Pushpin 海淀区Name;
        internal Pushpin 怀柔区Name;
        internal Pushpin 门头沟区Name;
        internal Pushpin 密云县Name;
        internal Pushpin 平谷区Name;
        internal Pushpin 石景山区Name;
        internal Pushpin 顺义区Name;
        internal Pushpin 通州区Name;
        internal Pushpin 西城区Name;
        internal Pushpin 延庆县Name;

        public MainPage()
        {
            this.InitializeComponent();
            App app = Application.get_Current() as App;
            this.txtbWebCounts.set_Text(app.WebCountsText);
            this.airDataContext = base.get_Resources().get_Item("AirDataContext") as AirDataContext;
            PagedCollectionView view = new PagedCollectionView(app.StationsList) {
                GroupDescriptions = { new PropertyGroupDescription("Group") }
            };
            this.dgAQI.ItemsSource = view;
            view = new PagedCollectionView(app.StationsList) {
                GroupDescriptions = { new PropertyGroupDescription("Group") }
            };
            this.dgWRW.ItemsSource = view;
        }

        private void AQIExpand_Click(object sender, RoutedEventArgs e)
        {
            double targetWidth = 315.0;
            double aQIPopupHeight = this.GetAQIPopupHeight();
            this.FloatAQIPopup.Expand(targetWidth, aQIPopupHeight);
        }

        private void AQIPopupExpand_Completed(object sender, EventArgs e)
        {
            bool valueOrDefault = this.btnAQIExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnAQIExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        this.btnAQIExpand.set_Background(base.get_Resources().get_Item("ExpandImageBrush") as ImageBrush);
                        break;

                    case true:
                        this.btnAQIExpand.set_Background(base.get_Resources().get_Item("CollapsedImageBrush") as ImageBrush);
                        return;

                    default:
                        return;
                }
            }
        }

        private void btnAlertMessage_Click(object sender, RoutedEventArgs e)
        {
            this.AlertWnd.Open();
        }

        private void btnLeftFrameExpand_Click(object sender, RoutedEventArgs e)
        {
            bool valueOrDefault = this.btnExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        this.LeftFrameExpandAnimation.set_From(0.0);
                        this.LeftFrameExpandAnimation.set_To(new double?((double) Convert.ToInt32(this.LeftFrame.get_Tag().ToString())));
                        this.Expand.Begin();
                        break;

                    case true:
                        this.LeftFrameExpandAnimation.set_From(new double?((double) Convert.ToInt32(this.LeftFrame.get_Tag().ToString())));
                        this.LeftFrameExpandAnimation.set_To(0.0);
                        this.Expand.Begin();
                        return;

                    default:
                        return;
                }
            }
        }

        private void btnLeftFrameExpandNew_Click(object sender, RoutedEventArgs e)
        {
            if (this.bLeftFrameExpanded)
            {
                this.ForecastGridBorder.set_Tag(this.ForecastGridBorder.get_ActualHeight().ToString());
                this.ForecastExpandAnimation.set_From(new double?(this.ForecastGridBorder.get_ActualHeight()));
                this.ForecastExpandAnimation.set_To(0.0);
                this.ActuallyExpandAnimation.set_From(new double?((double) Convert.ToInt32(this.ActuallyGrid.get_Tag().ToString())));
                this.ActuallyExpandAnimation.set_To(0.0);
                this.QualityExpandAnimation.set_From(new double?((double) Convert.ToInt32(this.dgAQIGrid.get_Tag().ToString())));
                this.QualityExpandAnimation.set_To(0.0);
                this.LeftFrameNewExpand.Begin();
            }
            else
            {
                this.ForecastExpandAnimation.set_From(0.0);
                this.ForecastExpandAnimation.set_To(new double?((double) Convert.ToInt32(this.ForecastGridBorder.get_Tag().ToString())));
                this.ActuallyExpandAnimation.set_From(0.0);
                this.ActuallyExpandAnimation.set_To(new double?((double) Convert.ToInt32(this.ActuallyGrid.get_Tag().ToString())));
                this.QualityExpandAnimation.set_From(0.0);
                this.QualityExpandAnimation.set_To(new double?((double) Convert.ToInt32(this.dgAQIGrid.get_Tag().ToString())));
                this.LeftFrameNewExpand.Begin();
            }
        }

        public void BuildChartData(WRWData wrwData)
        {
            Dictionary<int, KeyValuePair<DateTime, float?>> dictionary = wrwData.Data24hList;
            LinearAxis axis = this.WRWChart.FindName("YAxis") as LinearAxis;
            string pollutant = wrwData.Pollutant;
            if (pollutant != null)
            {
                if (!(pollutant == "PM2.5"))
                {
                    if (pollutant == "PM10")
                    {
                        if (wrwData.MaxValue <= 200.0)
                        {
                            axis.Maximum = 200.0;
                            axis.Interval = 50.0;
                        }
                        else if (wrwData.MaxValue <= 400.0)
                        {
                            axis.Maximum = 500.0;
                            axis.Interval = 125.0;
                        }
                        else if (wrwData.MaxValue <= 1200.0)
                        {
                            axis.Maximum = 1200.0;
                            axis.Interval = 300.0;
                        }
                    }
                    else if (pollutant == "SO2")
                    {
                        if (wrwData.MaxValue <= 180.0)
                        {
                            axis.Maximum = 200.0;
                            axis.Interval = 50.0;
                        }
                        else if (wrwData.MaxValue <= 500.0)
                        {
                            axis.Maximum = 500.0;
                            axis.Interval = 125.0;
                        }
                        else if (wrwData.MaxValue <= 1200.0)
                        {
                            axis.Maximum = 1200.0;
                            axis.Interval = 300.0;
                        }
                    }
                    else if (pollutant == "NO2")
                    {
                        if (wrwData.MaxValue <= 150.0)
                        {
                            axis.Maximum = 200.0;
                            axis.Interval = 50.0;
                        }
                        else if (wrwData.MaxValue <= 500.0)
                        {
                            axis.Maximum = 500.0;
                            axis.Interval = 125.0;
                        }
                        else if (wrwData.MaxValue <= 1200.0)
                        {
                            axis.Maximum = 1200.0;
                            axis.Interval = 300.0;
                        }
                    }
                    else if (pollutant == "O3")
                    {
                        if (wrwData.MaxValue <= 250.0)
                        {
                            axis.Maximum = 200.0;
                            axis.Interval = 50.0;
                        }
                        else if (wrwData.MaxValue <= 500.0)
                        {
                            axis.Maximum = 500.0;
                            axis.Interval = 125.0;
                        }
                        else if (wrwData.MaxValue <= 1200.0)
                        {
                            axis.Maximum = 1200.0;
                            axis.Interval = 300.0;
                        }
                    }
                    else if (pollutant == "CO")
                    {
                        if (wrwData.MaxValue <= 6.0)
                        {
                            axis.Maximum = 8.0;
                            axis.Interval = 2.0;
                        }
                        else if (wrwData.MaxValue <= 20.0)
                        {
                            axis.Maximum = 24.0;
                            axis.Interval = 6.0;
                        }
                        else if (wrwData.MaxValue <= 60.0)
                        {
                            axis.Maximum = 60.0;
                            axis.Interval = 15.0;
                        }
                    }
                }
                else if (wrwData.MaxValue <= 150.0)
                {
                    axis.Maximum = 160.0;
                    axis.Interval = 40.0;
                }
                else if (wrwData.MaxValue <= 300.0)
                {
                    axis.Maximum = 320.0;
                    axis.Interval = 80.0;
                }
                else if (wrwData.MaxValue <= 1000.0)
                {
                    axis.Maximum = 1000.0;
                    axis.Interval = 200.0;
                }
            }
            if ((wrwData.Pollutant == "PM2.5") || (wrwData.Pollutant == "PM10"))
            {
                this.WRWChartTitle.set_Text("过去24小时均值：" + wrwData.AVG24h + " " + wrwData.CotUnit);
                float? nullable = null;
                if (!string.IsNullOrEmpty(wrwData.AVG24h) && !(wrwData.AVG24h == "-9999"))
                {
                    nullable = new float?(Convert.ToSingle(wrwData.AVG24h));
                }
                List<KeyValuePair<DateTime, float?>> list = new List<KeyValuePair<DateTime, float?>>();
                for (int j = 0x17; j >= 0; j--)
                {
                    DateTime time = DateTime.Now.AddHours((double) (-1 * j));
                    DateTime key = new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0);
                    KeyValuePair<DateTime, float?> pair = new KeyValuePair<DateTime, float?>(key, nullable);
                    list.Add(pair);
                }
                LineSeries item = new LineSeries {
                    Title = "24小时浓度均值    ",
                    IndependentValueBinding = new Binding("Key"),
                    DependentValueBinding = new Binding("Value"),
                    DataPointStyle = base.get_Resources().get_Item("Yellow_LineDataPointStyle") as Style,
                    ItemsSource = list
                };
                this.WRWChart.Series.Add(item);
            }
            else
            {
                this.WRWChartTitle.set_Text("");
            }
            this.IsFirst = true;
            for (int i = 0; i < (dictionary.Count - 1); i++)
            {
                List<KeyValuePair<DateTime, float?>> points = new List<KeyValuePair<DateTime, float?>>();
                KeyValuePair<DateTime, float?> pair2 = dictionary[i];
                if (pair2.Value.HasValue)
                {
                    KeyValuePair<DateTime, float?> pair3 = dictionary[i + 1];
                    if (pair3.Value.HasValue)
                    {
                        points.Add(dictionary[i]);
                        points.Add(dictionary[i + 1]);
                        this.FillLineSeries(points, i);
                    }
                }
            }
        }

        public void BuildChartData(string StationName, string ShortName, string CurrentWRWName, WRWData wrwData)
        {
            Dictionary<int, KeyValuePair<DateTime, float?>> dictionary = wrwData.Data24hList;
            this.airDataContext.WRWData24hList.Clear();
            for (int i = 0; i < dictionary.Count; i++)
            {
                KeyValuePair<DateTime, float?> pair = dictionary[0];
                DateTime time = pair.Key.AddHours((double) (-1 * ((dictionary.Count - 1) - i)));
                KeyValuePair<DateTime, float?> pair2 = dictionary[i];
                WRWData24h item = new WRWData24h(StationName, CurrentWRWName, pair2.Value, time, new float?(Convert.ToSingle(wrwData.AVG24h)));
                this.airDataContext.WRWData24hList.Add(item);
            }
        }

        private void CalculateLineIntersection(Point point, Point NextPoint, ref double yLeft, ref double xTop, ref double yRight, ref double xBottom, double Left, double Top, double Right, double Bottom)
        {
            double num = 0.0;
            double num2 = 0.0;
            if (point.get_X() == NextPoint.get_X())
            {
                xTop = xBottom = point.get_X();
                yLeft = yRight = double.NaN;
            }
            else
            {
                num = (point.get_Y() - NextPoint.get_Y()) / (point.get_X() - NextPoint.get_X());
                if (num == 0.0)
                {
                    xTop = xBottom = double.NaN;
                    yLeft = yRight = point.get_Y();
                }
                else
                {
                    num2 = point.get_Y() - (num * point.get_X());
                    yLeft = (num * Left) + num2;
                    yRight = (num * Right) + num2;
                    xTop = (Top - num2) / num;
                    xBottom = (Bottom - num2) / num;
                }
            }
        }

        private void ClickStation()
        {
            Pushpin clickedStation = this.ClickedStation;
            if (clickedStation != null)
            {
                string str = clickedStation.get_Content().ToString();
                string currentChannelName = this.CurrentChannelName;
                if (currentChannelName != null)
                {
                    if (!(currentChannelName == "Quality"))
                    {
                        if (!(currentChannelName == "Actually"))
                        {
                            return;
                        }
                    }
                    else
                    {
                        PagedCollectionView view = this.dgAQI.ItemsSource as PagedCollectionView;
                        foreach (StationData data in view)
                        {
                            if (data.Station == str)
                            {
                                int index = view.IndexOf(data);
                                if (this.dgAQI.SelectedIndex != index)
                                {
                                    this.dgAQI.SelectedIndex = index;
                                }
                                this.SelectStation(this.dgAQI);
                            }
                        }
                        return;
                    }
                    PagedCollectionView itemsSource = this.dgWRW.ItemsSource as PagedCollectionView;
                    foreach (StationData data2 in itemsSource)
                    {
                        if (data2.Station == str)
                        {
                            int num2 = itemsSource.IndexOf(data2);
                            if (this.dgWRW.SelectedIndex != num2)
                            {
                                this.dgWRW.SelectedIndex = num2;
                            }
                            this.SelectStation(this.dgWRW);
                        }
                    }
                }
            }
        }

        private void ClipLine(Point point, Point NextPoint, double yLeft, double xTop, double yRight, double xBottom, double Left, double Top, double Right, double Bottom, ref PointCollection ClippedPolygon)
        {
            if ((xTop == Left) && (yLeft == Top))
            {
                if (((ClippedPolygon.get_Count() == 0) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_X() != Left)) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_Y() != Top))
                {
                    ClippedPolygon.Add(new Point(Left, Top));
                }
            }
            else if ((xTop == Right) && (yRight == Top))
            {
                if (((ClippedPolygon.get_Count() == 0) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_X() != Right)) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_Y() != Top))
                {
                    ClippedPolygon.Add(new Point(Right, Top));
                }
            }
            else if ((xBottom == Right) && (yRight == Bottom))
            {
                if (((ClippedPolygon.get_Count() == 0) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_X() != Right)) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_Y() != Bottom))
                {
                    ClippedPolygon.Add(new Point(Right, Bottom));
                }
            }
            else if ((xBottom == Left) && (yLeft == Bottom))
            {
                if (((ClippedPolygon.get_Count() == 0) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_X() != Left)) || (ClippedPolygon.get_Item(ClippedPolygon.get_Count() - 1).get_Y() != Bottom))
                {
                    ClippedPolygon.Add(new Point(Left, Bottom));
                }
            }
            else if (((Top <= yLeft) && (yLeft <= Bottom)) && ((Left <= xTop) && (xTop <= Right)))
            {
                if (((point.get_X() < Left) && (point.get_Y() > Top)) && ((NextPoint.get_X() > Left) && (NextPoint.get_Y() < Top)))
                {
                    ClippedPolygon.Add(new Point(Left, yLeft));
                    ClippedPolygon.Add(new Point(xTop, Top));
                }
                else if (((point.get_X() > Left) && (point.get_Y() < Top)) && ((NextPoint.get_Y() > Top) && (NextPoint.get_X() < Left)))
                {
                    ClippedPolygon.Add(new Point(xTop, Top));
                    ClippedPolygon.Add(new Point(Left, yLeft));
                }
            }
            else if (((Left <= xTop) && (xTop <= Right)) && ((Top <= yRight) && (yRight <= Bottom)))
            {
                if (((point.get_X() > Right) && (point.get_Y() > Top)) && ((NextPoint.get_X() < Right) && (NextPoint.get_Y() < Top)))
                {
                    ClippedPolygon.Add(new Point(Right, yRight));
                    ClippedPolygon.Add(new Point(xTop, Top));
                }
                else if (((point.get_X() < Right) && (point.get_Y() < Top)) && ((NextPoint.get_X() > Right) && (NextPoint.get_Y() > Top)))
                {
                    ClippedPolygon.Add(new Point(xTop, Top));
                    ClippedPolygon.Add(new Point(Right, yRight));
                }
            }
            else if (((Left <= xBottom) && (xBottom <= Right)) && ((Top <= yRight) && (yRight <= Bottom)))
            {
                if (((point.get_X() > Right) && (point.get_Y() < Bottom)) && ((NextPoint.get_X() < Right) && (NextPoint.get_Y() > Bottom)))
                {
                    ClippedPolygon.Add(new Point(Right, yRight));
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                }
                else if (((point.get_X() < Right) && (point.get_Y() > Bottom)) && ((NextPoint.get_X() > Right) && (NextPoint.get_Y() < Bottom)))
                {
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                    ClippedPolygon.Add(new Point(Right, yRight));
                }
            }
            else if (((Left <= xBottom) && (xBottom <= Right)) && ((Top <= yLeft) && (yLeft <= Bottom)))
            {
                if (((point.get_X() < Left) && (point.get_Y() < Bottom)) && ((NextPoint.get_X() > Left) && (NextPoint.get_Y() > Bottom)))
                {
                    ClippedPolygon.Add(new Point(Left, yLeft));
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                }
                else if (((point.get_X() > Left) && (point.get_Y() > Bottom)) && ((NextPoint.get_X() < Left) && (NextPoint.get_Y() < Bottom)))
                {
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                    ClippedPolygon.Add(new Point(Left, yLeft));
                }
            }
            else if (((Left <= xTop) && (xTop <= Right)) && ((Left <= xBottom) && (xBottom <= Right)))
            {
                if ((point.get_Y() < Top) && (NextPoint.get_Y() > Bottom))
                {
                    ClippedPolygon.Add(new Point(xTop, Top));
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                }
                else if ((point.get_Y() > Bottom) && (NextPoint.get_Y() < Top))
                {
                    ClippedPolygon.Add(new Point(xBottom, Bottom));
                    ClippedPolygon.Add(new Point(xTop, Top));
                }
            }
            else if (((Top <= yLeft) && (yLeft <= Bottom)) && ((Top <= yRight) && (yRight <= Bottom)))
            {
                if ((point.get_X() < Left) && (NextPoint.get_X() > Right))
                {
                    ClippedPolygon.Add(new Point(Left, yLeft));
                    ClippedPolygon.Add(new Point(Right, yRight));
                }
                else if ((point.get_X() > Right) && (NextPoint.get_X() < Left))
                {
                    ClippedPolygon.Add(new Point(Right, yRight));
                    ClippedPolygon.Add(new Point(Left, yLeft));
                }
            }
        }

        private PointCollection ClipPolygon(Polygon polygon, double Left, double Top, double Right, double Bottom)
        {
            Point point;
            Point point2;
            PointCollection clippedPolygon = new PointCollection();
            double xTop = 0.0;
            double yLeft = 0.0;
            double xBottom = 0.0;
            double yRight = 0.0;
            int num5 = 0;
            int num6 = -1;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            for (int i = 0; i < polygon.get_Points().get_Count(); i++)
            {
                point = polygon.get_Points().get_Item(i);
                if (point.get_X() < num7)
                {
                    num7 = point.get_X();
                }
                if (point.get_X() > num8)
                {
                    num8 = point.get_X();
                }
                if (point.get_Y() < num9)
                {
                    num9 = point.get_Y();
                }
                if (point.get_Y() > num10)
                {
                    num10 = point.get_Y();
                }
                if (((Left <= point.get_X()) && (point.get_X() <= Right)) && ((Top <= point.get_Y()) && (point.get_Y() <= Bottom)))
                {
                    num6 = i;
                    break;
                }
            }
            if (num6 == -1)
            {
                for (int k = 0; k < polygon.get_Points().get_Count(); k++)
                {
                    point = polygon.get_Points().get_Item(k);
                    point2 = (k == (polygon.get_Points().get_Count() - 1)) ? polygon.get_Points().get_Item(0) : polygon.get_Points().get_Item(k + 1);
                    this.CalculateLineIntersection(point, point2, ref yLeft, ref xTop, ref yRight, ref xBottom, Left, Top, Right, Bottom);
                    if (((((Top <= yLeft) && (yLeft <= Bottom)) && (((point.get_X() < Left) && (Left < point2.get_X())) || ((point2.get_X() < Left) && (Left < point.get_X())))) || (((Left <= xTop) && (xTop <= Right)) && (((point.get_Y() < Top) && (Top < point2.get_Y())) || ((point2.get_Y() < Top) && (Top < point.get_Y()))))) || ((((Top <= yRight) && (yRight <= Bottom)) && (((point.get_X() < Right) && (Right < point2.get_X())) || ((point2.get_X() < Right) && (Right < point.get_X())))) || (((Left <= xBottom) && (xBottom <= Right)) && (((point.get_Y() < Bottom) && (Bottom < point2.get_Y())) || ((point2.get_Y() < Bottom) && (Bottom < point.get_Y()))))))
                    {
                        this.ClipLine(point, point2, yLeft, xTop, yRight, xBottom, Left, Top, Right, Bottom, ref clippedPolygon);
                        num5 = clippedPolygon.get_Count();
                        num6 = (k == (polygon.get_Points().get_Count() - 1)) ? 0 : (k + 1);
                        break;
                    }
                }
            }
            if (num6 == -1)
            {
                if (((num7 <= Left) && (Right <= num8)) && ((num9 <= Top) && (Bottom <= num10)))
                {
                    clippedPolygon.Add(new Point(Left, Top));
                    clippedPolygon.Add(new Point(Right, Top));
                    clippedPolygon.Add(new Point(Right, Bottom));
                    clippedPolygon.Add(new Point(Left, Bottom));
                }
                return clippedPolygon;
            }
            for (int j = num6; j < (polygon.get_Points().get_Count() + num6); j++)
            {
                point = polygon.get_Points().get_Item((j < polygon.get_Points().get_Count()) ? j : (j - polygon.get_Points().get_Count()));
                point2 = ((j + 1) < polygon.get_Points().get_Count()) ? polygon.get_Points().get_Item(j + 1) : polygon.get_Points().get_Item((j + 1) - polygon.get_Points().get_Count());
                this.CalculateLineIntersection(point, point2, ref yLeft, ref xTop, ref yRight, ref xBottom, Left, Top, Right, Bottom);
                if (((Left <= point.get_X()) && (point.get_X() <= Right)) && ((Top <= point.get_Y()) && (point.get_Y() <= Bottom)))
                {
                    if (((clippedPolygon.get_Count() == 0) || (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() != point.get_X())) || (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() != point.get_Y()))
                    {
                        clippedPolygon.Add(point);
                    }
                    if (((point2.get_X() < Left) || (Right < point2.get_X())) || ((point2.get_Y() < Top) || (Bottom < point2.get_Y())))
                    {
                        if (((Top <= yLeft) && (yLeft <= Bottom)) && ((point2.get_X() < Left) && (Left < point.get_X())))
                        {
                            clippedPolygon.Add(new Point(Left, yLeft));
                        }
                        else if (((Left <= xTop) && (xTop <= Right)) && ((point2.get_Y() < Top) && (Top < point.get_Y())))
                        {
                            clippedPolygon.Add(new Point(xTop, Top));
                        }
                        else if (((Top <= yRight) && (yRight <= Bottom)) && ((point.get_X() < Right) && (Right < point2.get_X())))
                        {
                            clippedPolygon.Add(new Point(Right, yRight));
                        }
                        else if (((Left <= xBottom) && (xBottom <= Right)) && ((point.get_Y() < Bottom) && (Bottom < point2.get_Y())))
                        {
                            clippedPolygon.Add(new Point(xBottom, Bottom));
                        }
                    }
                }
                else
                {
                    if (clippedPolygon.get_Count() > 0)
                    {
                        if (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Left) && (point.get_X() < Left)) && (Left <= point2.get_X()))
                        {
                            if ((yLeft < Top) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() > Top))
                            {
                                clippedPolygon.Add(new Point(Left, Top));
                            }
                            else if ((yLeft > Bottom) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() < Bottom))
                            {
                                clippedPolygon.Add(new Point(Left, Bottom));
                            }
                        }
                        if (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Top) && (point.get_Y() < Top)) && (Top <= point2.get_Y()))
                        {
                            if ((xTop < Left) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() > Left))
                            {
                                clippedPolygon.Add(new Point(Left, Top));
                            }
                            else if ((xTop > Right) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() < Right))
                            {
                                clippedPolygon.Add(new Point(Right, Top));
                            }
                        }
                        if (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Right) && (point2.get_X() <= Right)) && (Right < point.get_X()))
                        {
                            if ((yRight < Top) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() > Top))
                            {
                                clippedPolygon.Add(new Point(Right, Top));
                            }
                            else if ((yRight > Bottom) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() < Bottom))
                            {
                                clippedPolygon.Add(new Point(Right, Bottom));
                            }
                        }
                        if (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Bottom) && (point2.get_Y() <= Bottom)) && (Bottom < point.get_Y()))
                        {
                            if ((xBottom > Right) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() < Right))
                            {
                                clippedPolygon.Add(new Point(Right, Bottom));
                            }
                            else if ((xBottom < Left) && (clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() > Left))
                            {
                                clippedPolygon.Add(new Point(Left, Bottom));
                            }
                        }
                    }
                    if (((Left <= point2.get_X()) && (point2.get_X() <= Right)) && ((Top <= point2.get_Y()) && (point2.get_Y() <= Bottom)))
                    {
                        if (((Top <= yLeft) && (yLeft <= Bottom)) && ((point.get_X() < Left) && (Left < point2.get_X())))
                        {
                            if ((((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Top) && (point.get_Y() == Top)) && (point2.get_Y() == Top)) || (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Bottom) && (point.get_Y() == Bottom)) && (point2.get_Y() == Bottom)))
                            {
                                clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
                            }
                            else
                            {
                                clippedPolygon.Add(new Point(Left, yLeft));
                            }
                        }
                        else if (((Left <= xTop) && (xTop <= Right)) && ((point.get_Y() < Top) && (Top < point2.get_Y())))
                        {
                            if ((((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Left) && (point.get_X() == Left)) && (point2.get_X() == Left)) || (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Right) && (point.get_X() == Right)) && (point2.get_X() == Right)))
                            {
                                clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
                            }
                            else
                            {
                                clippedPolygon.Add(new Point(xTop, Top));
                            }
                        }
                        else if (((Top <= yRight) && (yRight <= Bottom)) && ((point2.get_X() < Right) && (Right < point.get_X())))
                        {
                            if ((((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Top) && (point.get_Y() == Top)) && (point2.get_Y() == Top)) || (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y() == Bottom) && (point.get_Y() == Bottom)) && (point2.get_Y() == Bottom)))
                            {
                                clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
                            }
                            else
                            {
                                clippedPolygon.Add(new Point(Right, yRight));
                            }
                        }
                        else if (((Left <= xBottom) && (xBottom <= Right)) && ((point2.get_Y() < Bottom) && (Bottom < point.get_Y())))
                        {
                            if ((((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Left) && (point.get_X() == Left)) && (point2.get_X() == Left)) || (((clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X() == Right) && (point.get_X() == Right)) && (point2.get_X() == Right)))
                            {
                                clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
                            }
                            else
                            {
                                clippedPolygon.Add(new Point(xBottom, Bottom));
                            }
                        }
                    }
                    else
                    {
                        this.ClipLine(point, point2, yLeft, xTop, yRight, xBottom, Left, Top, Right, Bottom, ref clippedPolygon);
                    }
                }
            }
            if (num5 > 0)
            {
                for (int m = 0; m < num5; m++)
                {
                    clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
                }
                return clippedPolygon;
            }
            if ((clippedPolygon.get_Item(0).get_X() == clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_X()) && (clippedPolygon.get_Item(0).get_Y() == clippedPolygon.get_Item(clippedPolygon.get_Count() - 1).get_Y()))
            {
                clippedPolygon.RemoveAt(clippedPolygon.get_Count() - 1);
            }
            return clippedPolygon;
        }

        private void COStoryboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrw_pm10.set_Visibility(0);
                Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("PM10Storyboard") as Storyboard;
                DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
                if (animation != null)
                {
                    animation.set_To(0.0);
                }
                storyboard.Begin();
                return;
            }
            Storyboard storyboard2 = this.wrwButtons.get_Resources().get_Item("O31Storyboard") as Storyboard;
            DoubleAnimation animation2 = storyboard2.get_Children().get_Item(0) as DoubleAnimation;
            if (animation2 != null)
            {
                animation2.set_To(-332.0);
                string str = this.screenHeight.ToString();
                if (str != null)
                {
                    if (!(str == "1080"))
                    {
                        if ((str == "900") || (str == "768"))
                        {
                        }
                    }
                    else
                    {
                        animation2.set_To(-332.0);
                        goto Label_0123;
                    }
                }
                animation2.set_To(-302.0);
            }
        Label_0123:
            storyboard2.Begin();
        }

        private void DataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender == this.dgAQI) && this.dgAQIDataGridRowClicked)
            {
                this.dgAQIDataGridRowClicked = false;
            }
            else if ((sender == this.dgWRW) && this.dgWRWDataGridRowClicked)
            {
                this.dgWRWDataGridRowClicked = false;
            }
            else
            {
                base.Focus();
            }
        }

        private void DataGridFrozenGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void DataGridRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.OpenForecastFloatPopup();
        }

        private void dataService_DayForecastCompleted(object sender, DayForecastCompletedEventArgs e)
        {
            if ((e.Error == null) && (e.Result != null))
            {
                this.airDataContext.ForecastItemsSource.Clear();
                using (List<TB_Message>.Enumerator enumerator = e.Result.GetEnumerator())
                {
                    Func<BEPB.Forecast, bool> predicate = null;
                    TB_Message data;
                    while (enumerator.MoveNext())
                    {
                        data = enumerator.Current;
                        if (predicate == null)
                        {
                            predicate = x => x.Zone == data.zone;
                        }
                        BEPB.Forecast item = this.airDataContext.ForecastItemsSource.SingleOrDefault<BEPB.Forecast>(predicate);
                        if (item != null)
                        {
                            item.SetData(data);
                        }
                        else
                        {
                            item = new BEPB.Forecast();
                            item.SetData(data);
                            this.airDataContext.ForecastItemsSource.Add(item);
                        }
                    }
                }
            }
        }

        private void dataService_GetAlertCompleted(object sender, GetAlertCompletedEventArgs e)
        {
            if (((e.Error == null) && (e.Result != null)) && (e.Result.Count > 0))
            {
                this.AlertWnd.Messages.Clear();
                foreach (TB_Alert alert in e.Result)
                {
                    AlertMessage item = new AlertMessage {
                        Title = alert.Title,
                        Date_Time = alert.Date_Time.ToString("yyyy-MM-dd HH:mm"),
                        MContent = alert.MContent
                    };
                    this.AlertWnd.Messages.Add(item);
                }
                this.AlertWnd.Open();
            }
        }

        private void dataService_GetRTC24hCompleted(object sender, GetRTC24hCompletedEventArgs e)
        {
            if (((e.Error == null) && (e.Result != null)) && (e.Result.Count > 0))
            {
                this.airDataContext.WRWData24hList.Clear();
                foreach (TB_RTC tb_rtc in e.Result)
                {
                    WRWData24h item = new WRWData24h(tb_rtc.Station, tb_rtc.Pollutant, tb_rtc.Value, tb_rtc.Date_Time, tb_rtc.AVG24h);
                    this.airDataContext.WRWData24hList.Add(item);
                }
            }
        }

        private void dataService_GetRTCCompleted(object sender, GetRTCCompletedEventArgs e)
        {
            if ((e.Error == null) && (e.Result != null))
            {
                App app = Application.get_Current() as App;
                string str = "";
                StationData data = null;
                using (List<TB_RTC>.Enumerator enumerator = e.Result.GetEnumerator())
                {
                    Func<StationData, bool> predicate = null;
                    TB_RTC data;
                    while (enumerator.MoveNext())
                    {
                        data = enumerator.Current;
                        if (data.Station != str)
                        {
                            if (predicate == null)
                            {
                                predicate = x => x.ShortName == data.Station;
                            }
                            data = app.StationsList.SingleOrDefault<StationData>(predicate);
                            if (data == null)
                            {
                                continue;
                            }
                            data.SetData(data);
                            str = data.Station;
                        }
                        if (data.Pollutant == data.PriPollutant)
                        {
                            data.AQI = data.AQI;
                            data.QLevel = data.QLevel;
                            data.Quality = data.Quality;
                        }
                        IAQIData item = new IAQIData();
                        string pollutant = data.Pollutant;
                        if (pollutant != null)
                        {
                            if (!(pollutant == "PM2.5"))
                            {
                                if (pollutant == "SO2")
                                {
                                    goto Label_01DA;
                                }
                                if (pollutant == "CO")
                                {
                                    goto Label_023B;
                                }
                                if (pollutant == "NO2")
                                {
                                    goto Label_029C;
                                }
                                if (pollutant == "O3")
                                {
                                    goto Label_02FD;
                                }
                                if (pollutant == "PM10")
                                {
                                    goto Label_035B;
                                }
                            }
                            else
                            {
                                item.Pollutant = "PM2.5 - 24小时";
                                item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                                item.Quality = data.Quality;
                            }
                        }
                        goto Label_03B7;
                    Label_01DA:
                        item.Pollutant = "SO2 - 1小时";
                        item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                        item.Quality = data.Quality;
                        goto Label_03B7;
                    Label_023B:
                        item.Pollutant = "CO - 1小时";
                        item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                        item.Quality = data.Quality;
                        goto Label_03B7;
                    Label_029C:
                        item.Pollutant = "NO2 - 1小时";
                        item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                        item.Quality = data.Quality;
                        goto Label_03B7;
                    Label_02FD:
                        item.Pollutant = "O3 - 1小时";
                        item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                        item.Quality = data.Quality;
                        goto Label_03B7;
                    Label_035B:
                        item.Pollutant = "PM10 - 24小时";
                        item.IAQI = !data.Eval24h.HasValue ? "--" : data.Eval24h.ToString();
                        item.Quality = data.Quality;
                    Label_03B7:
                        data.IAQIDataList.Add(item);
                        WRWData data3 = new WRWData {
                            ShortName = data.ShortName,
                            Group = data.Group,
                            Pollutant = data.Pollutant,
                            Value = !data.Value.HasValue ? "--" : data.Value.ToString(),
                            AVG24h = !data.AVG24h.HasValue ? "--" : data.AVG24h.ToString(),
                            QLevel = data.QLevel,
                            Quality = data.Quality
                        };
                        data.WRWDataList.Add(data3);
                        StationPushpin station = this.GetStation(data.Station);
                        if (station != null)
                        {
                            station.set_Background(data.BackColor);
                        }
                    }
                }
                this.lbl_DateTime_WRW.set_Text(app.StationsList[0].Date_Time);
                this.lbl_DateTime_AQI.set_Text(app.StationsList[0].Date_Time);
                PagedCollectionView view = new PagedCollectionView(app.StationsList) {
                    GroupDescriptions = { new PropertyGroupDescription("Group") }
                };
                this.dgAQI.ItemsSource = view;
                view = new PagedCollectionView(app.StationsList) {
                    GroupDescriptions = { new PropertyGroupDescription("Group") }
                };
                this.dgWRW.ItemsSource = view;
                this.bWRWDataLoaded = true;
                if (this.bWRWDataLoaded && (this.WRWChannelClicked == 1))
                {
                    this.wrw_pm25.set_Visibility(0);
                    (this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard).Begin();
                }
            }
        }

        private void dataService_GetWebAlertCompleted(object sender, GetWebAlertCompletedEventArgs e)
        {
            string str = this.MapRange.get_Text();
            this.MapRange.set_Text(str + DateTime.Now.ToString("HH:mm:ss") + "  " + e.Result + "\n");
            if (((e.Error == null) && (e.Result != null)) && (e.Result != "{\"Table\":]}"))
            {
                JsonValue value3 = JsonValue.Parse(e.Result)["Table"];
                if (value3.Count > 0)
                {
                    this.AlertWnd.Messages.Clear();
                    foreach (object obj2 in (IEnumerable) value3)
                    {
                        using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(obj2.ToString())))
                        {
                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AlertMessage));
                            this.AlertWnd.AlertMsg = (AlertMessage) serializer.ReadObject(stream);
                        }
                    }
                    this.AlertWnd.set_Visibility(0);
                    this.AlertWnd.Open();
                    this.btnAlertMessage.set_Visibility(0);
                }
            }
        }

        private void dataService_GetWebDataCompleted(object sender, GetWebDataCompletedEventArgs e)
        {
            if ((e.Error == null) && (e.Result != null))
            {
                string jsonString = DecryptAES(e.Result, "qjkHuIy9D/9i=", "Mi9l/+7Zujhy12se6Yjy111A");
                if (jsonString == "{\"Table\":]}")
                {
                    return;
                }
                App app = Application.get_Current() as App;
                JsonValue value3 = JsonValue.Parse(jsonString)["Table"];
                StationData data = null;
                foreach (object obj2 in (IEnumerable) value3)
                {
                    string str2;
                    Func<StationData, bool> predicate = null;
                    RTCData rtcData = null;
                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(obj2.ToString())))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RTCData));
                        rtcData = (RTCData) serializer.ReadObject(stream);
                    }
                    if ((data == null) || (data.ShortName != rtcData.Station))
                    {
                        if (predicate == null)
                        {
                            predicate = x => x.ShortName == rtcData.Station;
                        }
                        data = app.StationsList.SingleOrDefault<StationData>(predicate);
                        if (data == null)
                        {
                            continue;
                        }
                    }
                    data.SetData(rtcData);
                    data.CopyWRWData(this.CurrentWRWName);
                    StationPushpin station = this.GetStation(data.Station);
                    if ((station != null) && ((str2 = this.CurrentChannelName) != null))
                    {
                        if (!(str2 == "Actually"))
                        {
                            if (str2 == "Quality")
                            {
                                goto Label_018B;
                            }
                        }
                        else
                        {
                            station.set_Background(data.WRWBackColor);
                            station.DataVisibility = data.WRWDataVisibility;
                        }
                    }
                    continue;
                Label_018B:
                    station.set_Background(data.BackColor);
                    station.DataVisibility = data.AQIDataVisibility;
                }
                this.lbl_DateTime_WRW.set_Text(app.StationsList[0].Date_Time);
                this.lbl_DateTime_AQI.set_Text(app.StationsList[0].Date_Time);
                this.bWRWDataLoaded = true;
                if (this.bWRWDataLoaded && (this.WRWChannelClicked == 1))
                {
                    this.wrw_pm25.set_Visibility(0);
                    (this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard).Begin();
                    this.WRWChannelClicked = -1;
                }
            }
            this.busyIndicator.IsBusy = false;
        }

        private void dataService_GetWebPredictCompleted(object sender, GetWebPredictCompletedEventArgs e)
        {
            if (((e.Error == null) && (e.Result != null)) && (e.Result != "{\"Table\":]}"))
            {
                JsonValue value3 = JsonValue.Parse(e.Result)["Table"];
                foreach (object obj2 in (IEnumerable) value3)
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(obj2.ToString())))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PredictData));
                        PredictData predictData = (PredictData) serializer.ReadObject(stream);
                        BEPB.Forecast item = this.airDataContext.ForecastItemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == predictData.Zone);
                        if (item != null)
                        {
                            item.SetData(predictData);
                        }
                        else
                        {
                            item = new BEPB.Forecast();
                            item.SetData(predictData);
                            this.airDataContext.ForecastItemsSource.Add(item);
                        }
                    }
                }
            }
        }

        public static string DecryptAES(string decryptString, string decryptKey, string salt)
        {
            AesManaged managed = null;
            MemoryStream stream = null;
            CryptoStream stream2 = null;
            string str;
            try
            {
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(decryptKey, Encoding.UTF8.GetBytes(salt));
                managed = new AesManaged {
                    Key = bytes.GetBytes(managed.KeySize / 8),
                    IV = bytes.GetBytes(managed.BlockSize / 8)
                };
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, managed.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] buffer = Convert.FromBase64String(decryptString);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                str = Encoding.UTF8.GetString(stream.ToArray(), 0, stream.ToArray().Length);
            }
            catch
            {
                str = decryptString;
            }
            finally
            {
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (managed != null)
                {
                    managed.Clear();
                }
            }
            return str;
        }

        private void dgAQI_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this, (IntPtr) this.dgAQIRow_MouseLeftButtonDown), true);
        }

        private void dgAQIRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.dgAQIDataGridRowClicked = true;
            this.SelectStation(this.dgAQI);
        }

        private void dgWRW_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this, (IntPtr) this.dgWRWRow_MouseLeftButtonDown), true);
        }

        private void dgWRWRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.dgWRWDataGridRowClicked = true;
            this.SelectStation(this.dgWRW);
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            this.ClickStation();
        }

        public static string EncryptAES(string encryptString, string encryptKey, string salt)
        {
            AesManaged managed = null;
            MemoryStream stream = null;
            CryptoStream stream2 = null;
            string str;
            try
            {
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(encryptKey, Encoding.UTF8.GetBytes(salt));
                managed = new AesManaged {
                    Key = bytes.GetBytes(managed.KeySize / 8),
                    IV = bytes.GetBytes(managed.BlockSize / 8)
                };
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, managed.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                str = Convert.ToBase64String(stream.ToArray());
            }
            catch
            {
                str = encryptString;
            }
            finally
            {
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (managed != null)
                {
                    managed.Clear();
                }
            }
            return str;
        }

        private void ExpanderButton_Click(object sender, RoutedEventArgs e)
        {
        }

        public void FillLineSeries(List<KeyValuePair<DateTime, float?>> points, int i)
        {
            LineSeries item = new LineSeries();
            if (this.IsFirst)
            {
                item.Title = "浓度变化曲线";
            }
            else
            {
                item.Title = "动态线";
                item.LegendItemStyle = base.get_Resources().get_Item("hiddenLegendStyle") as Style;
            }
            item.IndependentValueBinding = new Binding("Key");
            item.DependentValueBinding = new Binding("Value");
            item.DataPointStyle = base.get_Resources().get_Item("Green_LineDataPointStyle") as Style;
            item.ItemsSource = points;
            this.WRWChart.Series.Add(item);
            this.IsFirst = false;
        }

        private void Five_MouseEnter(object sender, MouseEventArgs e)
        {
            MapPolygon polygon = sender as MapPolygon;
            if ((polygon != null) && (polygon != this.LastSelectedFive))
            {
                this.brFive = polygon.Fill;
                polygon.Fill = new SolidColorBrush(Colors.get_Red());
            }
        }

        private void Five_MouseLeave(object sender, MouseEventArgs e)
        {
            MapPolygon polygon = sender as MapPolygon;
            if ((polygon != null) && (polygon != this.LastSelectedFive))
            {
                polygon.Fill = this.brFive;
            }
        }

        private void Five_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MapPolygon polygon = sender as MapPolygon;
            if (polygon != null)
            {
                ObservableCollection<BEPB.Forecast> itemsSource = this.forecastGrid.ItemsSource as ObservableCollection<BEPB.Forecast>;
                if (itemsSource == null)
                {
                    MessageBox.Show("内部错误：预报窗口没有数据：forecastList == null");
                }
                else
                {
                    BEPB.Forecast item = null;
                    string str = polygon.get_Name();
                    if (str != null)
                    {
                        if (!(str == "NorthEast"))
                        {
                            if (str == "NorthWest")
                            {
                                item = itemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == "西北部");
                            }
                            else if (str == "CityCenter")
                            {
                                item = itemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == "城六区");
                            }
                            else if (str == "SouthEast")
                            {
                                item = itemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == "东南部");
                            }
                            else if (str == "SouthWest")
                            {
                                item = itemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == "西南部");
                            }
                        }
                        else
                        {
                            item = itemsSource.SingleOrDefault<BEPB.Forecast>(x => x.Zone == "东北部");
                        }
                    }
                    if (item != null)
                    {
                        int index = itemsSource.IndexOf(item);
                        if (this.forecastGrid.SelectedIndex != index)
                        {
                            this.forecastGrid.SelectedIndex = index;
                        }
                        this.OpenForecastFloatPopup();
                    }
                }
            }
        }

        private void forecastGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this, (IntPtr) this.DataGridRow_MouseLeftButtonDown), true);
        }

        private double GetAQIPopupHeight()
        {
            bool valueOrDefault = this.btnAQIExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnAQIExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        return 224.0;

                    case true:
                        return 372.0;
                }
            }
            return 224.0;
        }

        public float? GetAVG24h(string Over24h)
        {
            string[] strArray = Over24h.Split(new char[] { ',' });
            float num = 0f;
            int num2 = 0;
            foreach (string str in strArray)
            {
                if (str == "-9999")
                {
                    num2++;
                }
                else
                {
                    num += Convert.ToSingle(str);
                }
            }
            return new float?(num / ((float) (0x18 - num2)));
        }

        private double GetForecastPopupHeight()
        {
            switch (this.airDataContext.CurrentZoneForecast.IsNight)
            {
                case "0":
                    return 254.0;

                case "1":
                    return 462.0;
            }
            return 254.0;
        }

        private StationPushpin GetStation(string StationName)
        {
            foreach (StationPushpin pushpin in this.MapStations.get_Children())
            {
                if (pushpin.get_Name() == StationName)
                {
                    return pushpin;
                }
            }
            return null;
        }

        private double GetWRWPopupHeight()
        {
            bool valueOrDefault = this.btnWRWExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnWRWExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        return 168.0;

                    case true:
                        return 419.0;
                }
            }
            return 168.0;
        }

        private void HandleExpandRowGroup(string Tag, string RowGroupName, bool bExpand)
        {
            string str = Tag;
            if (str != null)
            {
                if (!(str == "AQI"))
                {
                    if (!(str == "WRW"))
                    {
                        return;
                    }
                }
                else
                {
                    PagedCollectionView view = this.dgAQI.ItemsSource as PagedCollectionView;
                    if ((view != null) && (view.Groups.Count > 0))
                    {
                        if (bExpand)
                        {
                            for (int j = 0; j < view.Groups.Count; j++)
                            {
                                CollectionViewGroup collectionViewGroup = view.Groups[j] as CollectionViewGroup;
                                if ((collectionViewGroup != null) && (collectionViewGroup.get_Name().ToString() != RowGroupName))
                                {
                                    this.dgAQI.CollapseRowGroup(collectionViewGroup, false);
                                }
                            }
                            return;
                        }
                        for (int i = 0; i < view.Groups.Count; i++)
                        {
                            CollectionViewGroup group2 = view.Groups[i] as CollectionViewGroup;
                            if ((group2 != null) && (group2.get_Name().ToString() == RowGroupName))
                            {
                                CollectionViewGroup group3 = view.Groups[(i < (view.Groups.Count - 1)) ? (i + 1) : 0] as CollectionViewGroup;
                                if (group3 != null)
                                {
                                    this.dgAQI.ExpandRowGroup(group3, false);
                                    return;
                                }
                                return;
                            }
                        }
                    }
                    return;
                }
                PagedCollectionView itemsSource = this.dgWRW.ItemsSource as PagedCollectionView;
                if ((itemsSource != null) && (itemsSource.Groups.Count > 0))
                {
                    if (bExpand)
                    {
                        for (int k = 0; k < itemsSource.Groups.Count; k++)
                        {
                            CollectionViewGroup group4 = itemsSource.Groups[k] as CollectionViewGroup;
                            if ((group4 != null) && (group4.get_Name().ToString() != RowGroupName))
                            {
                                this.dgWRW.CollapseRowGroup(group4, false);
                            }
                        }
                    }
                    else
                    {
                        for (int m = 0; m < itemsSource.Groups.Count; m++)
                        {
                            CollectionViewGroup group5 = itemsSource.Groups[m] as CollectionViewGroup;
                            if ((group5 != null) && (group5.get_Name().ToString() == RowGroupName))
                            {
                                CollectionViewGroup group6 = itemsSource.Groups[(m < (itemsSource.Groups.Count - 1)) ? (m + 1) : 0] as CollectionViewGroup;
                                if (group6 != null)
                                {
                                    this.dgWRW.ExpandRowGroup(group6, false);
                                    return;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            if ((image != null) && (string.IsNullOrEmpty(this.CurrentChannelName) || (this.CurrentChannelName != image.get_Name())))
            {
                BitmapImage image2 = new BitmapImage();
                string str = image.get_Name();
                if (str != null)
                {
                    if (!(str == "Actually"))
                    {
                        if (str == "Quality")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/AQI-.png", UriKind.Relative));
                        }
                        else if (str == "Forecast")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/fqyb-.png", UriKind.Relative));
                        }
                        else if (str == "Support")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/fwzc-.png", UriKind.Relative));
                        }
                        else if (str == "Mobile")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/sjb-.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        image2.set_UriSource(new Uri("/BEPB;component/Images/ssnd-.png", UriKind.Relative));
                    }
                }
                image.set_Source(image2);
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            if ((image != null) && (string.IsNullOrEmpty(this.CurrentChannelName) || (this.CurrentChannelName != image.get_Name())))
            {
                BitmapImage image2 = new BitmapImage();
                string str = image.get_Name();
                if (str != null)
                {
                    if (!(str == "Actually"))
                    {
                        if (str == "Quality")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/AQI.png", UriKind.Relative));
                        }
                        else if (str == "Forecast")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/fqyb.png", UriKind.Relative));
                        }
                        else if (str == "Support")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/fwzc.png", UriKind.Relative));
                        }
                        else if (str == "Mobile")
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/sjb.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        image2.set_UriSource(new Uri("/BEPB;component/Images/ssnd.png", UriKind.Relative));
                    }
                }
                image.set_Source(image2);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                if ((!string.IsNullOrEmpty(this.CurrentChannelName) && (this.CurrentChannelName != image.get_Name())) && ((image.get_Name() != "Support") && (image.get_Name() != "Mobile")))
                {
                    BitmapImage image2 = new BitmapImage();
                    string currentChannelName = this.CurrentChannelName;
                    if (currentChannelName != null)
                    {
                        if (!(currentChannelName == "Actually"))
                        {
                            if (currentChannelName == "Quality")
                            {
                                image2.set_UriSource(new Uri("/BEPB;component/Images/AQI.png", UriKind.Relative));
                                this.Quality.set_Source(image2);
                            }
                            else if (currentChannelName == "Forecast")
                            {
                                image2.set_UriSource(new Uri("/BEPB;component/Images/fqyb.png", UriKind.Relative));
                                this.Forecast.set_Source(image2);
                            }
                        }
                        else
                        {
                            image2.set_UriSource(new Uri("/BEPB;component/Images/ssnd.png", UriKind.Relative));
                            this.Actually.set_Source(image2);
                        }
                    }
                    this.CurrentChannelName = image.get_Name();
                }
                if (this.LastStation != null)
                {
                    this.LastStation.IsFocused = false;
                }
                string str2 = image.get_Name();
                if (str2 != null)
                {
                    if (!(str2 == "Actually"))
                    {
                        if (!(str2 == "Quality"))
                        {
                            if (!(str2 == "Forecast"))
                            {
                                if (!(str2 == "Support"))
                                {
                                    if (str2 == "Mobile")
                                    {
                                        HtmlPage.get_Window().Navigate(new Uri("http://www.bjmemc.com.cn/g377.aspx", UriKind.Absolute), "_blank");
                                    }
                                    return;
                                }
                                HtmlPage.get_Window().Navigate(new Uri("http://www.bjmemc.com.cn/g370.aspx", UriKind.Absolute), "_blank");
                                return;
                            }
                            this.DayForecastPanel.set_Visibility(0);
                            this.ActuallyFrame.set_Visibility(1);
                            this.AirQualityFrame.set_Visibility(1);
                            this.bsMapMode.ZoomHome(true);
                            this.bsMapMode.bCanZoom = false;
                            this.airDataContext.bCanZoomIn = false;
                            this.airDataContext.bCanZoomOut = false;
                            this.NavigationCtrl.bCanZoom = false;
                            this.Five.set_Visibility(0);
                            this.Districts.set_Visibility(1);
                            this.MapStations.set_Visibility(1);
                            this.p_bottom_aqiGrid.set_Visibility(1);
                            this.wrwtlGrid.set_Visibility(1);
                            return;
                        }
                    }
                    else
                    {
                        this.DayForecastPanel.set_Visibility(1);
                        this.ActuallyFrame.set_Visibility(0);
                        this.AirQualityFrame.set_Visibility(1);
                        this.bsMapMode.bCanZoom = true;
                        this.airDataContext.bCanZoomIn = this.bsMapMode.bCanZoomIn;
                        this.airDataContext.bCanZoomOut = this.bsMapMode.bCanZoomOut;
                        this.NavigationCtrl.bCanZoom = true;
                        this.wrwButtonsBorder.set_Visibility(0);
                        if (this.WRWChannelClicked == 0)
                        {
                            this.WRWChannelClicked = 1;
                        }
                        if ((this.WRWChannelClicked == 1) && this.bWRWDataLoaded)
                        {
                            this.wrw_pm25.set_Visibility(0);
                            (this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard).Begin();
                            this.WRWChannelClicked = -1;
                        }
                        foreach (StationData data in (Application.get_Current() as App).StationsList)
                        {
                            StationPushpin station = this.GetStation(data.Station);
                            if (station != null)
                            {
                                station.set_Background(data.WRWBackColor);
                                station.DataVisibility = data.WRWDataVisibility;
                            }
                        }
                        this.Five.set_Visibility(1);
                        this.Districts.set_Visibility(0);
                        this.MapStations.set_Visibility(0);
                        this.wrwtlGrid.set_Visibility(0);
                        this.p_bottom_aqiGrid.set_Visibility(1);
                        return;
                    }
                    this.DayForecastPanel.set_Visibility(1);
                    this.ActuallyFrame.set_Visibility(1);
                    this.AirQualityFrame.set_Visibility(0);
                    this.bsMapMode.bCanZoom = true;
                    this.airDataContext.bCanZoomIn = this.bsMapMode.bCanZoomIn;
                    this.airDataContext.bCanZoomOut = this.bsMapMode.bCanZoomOut;
                    this.NavigationCtrl.bCanZoom = true;
                    foreach (StationData data2 in (Application.get_Current() as App).StationsList)
                    {
                        StationPushpin pushpin2 = this.GetStation(data2.Station);
                        if (pushpin2 != null)
                        {
                            pushpin2.set_Background(data2.BackColor);
                            pushpin2.DataVisibility = data2.AQIDataVisibility;
                        }
                    }
                    this.Five.set_Visibility(1);
                    this.Districts.set_Visibility(0);
                    this.MapStations.set_Visibility(0);
                    this.wrwtlGrid.set_Visibility(1);
                    this.p_bottom_aqiGrid.set_Visibility(0);
                }
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/BEPB;component/MainPage.xaml", UriKind.Relative));
                this.LayoutRoot = (Grid) base.FindName("LayoutRoot");
                this.Actually = (Image) base.FindName("Actually");
                this.Quality = (Image) base.FindName("Quality");
                this.Forecast = (Image) base.FindName("Forecast");
                this.Support = (Image) base.FindName("Support");
                this.Mobile = (Image) base.FindName("Mobile");
                this.busyIndicator = (BusyIndicator) base.FindName("busyIndicator");
                this.map = (CMap) base.FindName("map");
                this.epbMapTileLayer = (MapTileLayer) base.FindName("epbMapTileLayer");
                this.MapMask = (MapLayer) base.FindName("MapMask");
                this.Districts = (MapLayer) base.FindName("Districts");
                this.CityCenterBorder2 = (MapPolygon) base.FindName("CityCenterBorder2");
                this.HuaiRou = (MapPolygon) base.FindName("HuaiRou");
                this.MiYun = (MapPolygon) base.FindName("MiYun");
                this.YanQing = (MapPolygon) base.FindName("YanQing");
                this.ChangPing = (MapPolygon) base.FindName("ChangPing");
                this.PingGu = (MapPolygon) base.FindName("PingGu");
                this.ShunYi = (MapPolygon) base.FindName("ShunYi");
                this.MenTouGou = (MapPolygon) base.FindName("MenTouGou");
                this.HaiDian = (MapPolygon) base.FindName("HaiDian");
                this.ChaoYang = (MapPolygon) base.FindName("ChaoYang");
                this.TongZhou = (MapPolygon) base.FindName("TongZhou");
                this.ShiJingShan = (MapPolygon) base.FindName("ShiJingShan");
                this.DongCheng = (MapPolygon) base.FindName("DongCheng");
                this.XiCheng = (MapPolygon) base.FindName("XiCheng");
                this.FangShan = (MapPolygon) base.FindName("FangShan");
                this.FengTai = (MapPolygon) base.FindName("FengTai");
                this.DaXing = (MapPolygon) base.FindName("DaXing");
                this.DistrictsName = (MapLayer) base.FindName("DistrictsName");
                this.东城区Name = (Pushpin) base.FindName("东城区Name");
                this.西城区Name = (Pushpin) base.FindName("西城区Name");
                this.朝阳区Name = (Pushpin) base.FindName("朝阳区Name");
                this.丰台区Name = (Pushpin) base.FindName("丰台区Name");
                this.石景山区Name = (Pushpin) base.FindName("石景山区Name");
                this.海淀区Name = (Pushpin) base.FindName("海淀区Name");
                this.门头沟区Name = (Pushpin) base.FindName("门头沟区Name");
                this.房山区Name = (Pushpin) base.FindName("房山区Name");
                this.通州区Name = (Pushpin) base.FindName("通州区Name");
                this.顺义区Name = (Pushpin) base.FindName("顺义区Name");
                this.昌平区Name = (Pushpin) base.FindName("昌平区Name");
                this.大兴区Name = (Pushpin) base.FindName("大兴区Name");
                this.怀柔区Name = (Pushpin) base.FindName("怀柔区Name");
                this.平谷区Name = (Pushpin) base.FindName("平谷区Name");
                this.密云县Name = (Pushpin) base.FindName("密云县Name");
                this.延庆县Name = (Pushpin) base.FindName("延庆县Name");
                this.Five = (MapLayer) base.FindName("Five");
                this.NorthEastBorder = (MapPolygon) base.FindName("NorthEastBorder");
                this.NorthWestBorder = (MapPolygon) base.FindName("NorthWestBorder");
                this.SouthWestBorder = (MapPolygon) base.FindName("SouthWestBorder");
                this.CityCenterBorder = (MapPolygon) base.FindName("CityCenterBorder");
                this.SouthEastBorder = (MapPolygon) base.FindName("SouthEastBorder");
                this.NorthEast = (MapPolygon) base.FindName("NorthEast");
                this.NorthWest = (MapPolygon) base.FindName("NorthWest");
                this.SouthWest = (MapPolygon) base.FindName("SouthWest");
                this.CityCenter = (MapPolygon) base.FindName("CityCenter");
                this.SouthEast = (MapPolygon) base.FindName("SouthEast");
                this.NorthEastText = (Pushpin) base.FindName("NorthEastText");
                this.NorthWestText = (Pushpin) base.FindName("NorthWestText");
                this.CityCenterText = (Pushpin) base.FindName("CityCenterText");
                this.SouthEastText = (Pushpin) base.FindName("SouthEastText");
                this.SouthWestText = (Pushpin) base.FindName("SouthWestText");
                this.MapStations = (MapLayer) base.FindName("MapStations");
                this.NavigationCtrl = (BEPB.NavigationCtrl) base.FindName("NavigationCtrl");
                this.btn_yx = (ToggleButton) base.FindName("btn_yx");
                this.btn_dx = (ToggleButton) base.FindName("btn_dx");
                this.btn_sl = (ToggleButton) base.FindName("btn_sl");
                this.btnAlertMessage = (Button) base.FindName("btnAlertMessage");
                this.wrwtl = (Image) base.FindName("wrwtl");
                this.wrwtlGrid = (Grid) base.FindName("wrwtlGrid");
                this.wrwtlTitle = (TextBlock) base.FindName("wrwtlTitle");
                this.wrwtlRect1 = (Rectangle) base.FindName("wrwtlRect1");
                this.wrwtlRect2 = (Rectangle) base.FindName("wrwtlRect2");
                this.wrwtlRect3 = (Rectangle) base.FindName("wrwtlRect3");
                this.wrwtlRect4 = (Rectangle) base.FindName("wrwtlRect4");
                this.wrwtlRect5 = (Rectangle) base.FindName("wrwtlRect5");
                this.wrwtlRect6 = (Rectangle) base.FindName("wrwtlRect6");
                this.wrwtlData = (TextBlock) base.FindName("wrwtlData");
                this.p_bottom_aqi = (Image) base.FindName("p_bottom_aqi");
                this.p_bottom_aqiGrid = (StackPanel) base.FindName("p_bottom_aqiGrid");
                this.aqiEllipse1 = (Ellipse) base.FindName("aqiEllipse1");
                this.aqiEllipse2 = (Ellipse) base.FindName("aqiEllipse2");
                this.aqiEllipse3 = (Ellipse) base.FindName("aqiEllipse3");
                this.aqiEllipse4 = (Ellipse) base.FindName("aqiEllipse4");
                this.aqiEllipse5 = (Ellipse) base.FindName("aqiEllipse5");
                this.aqiEllipse6 = (Ellipse) base.FindName("aqiEllipse6");
                this.p_aqi_detail = (Image) base.FindName("p_aqi_detail");
                this.dgAQIDetailText = (DataGrid) base.FindName("dgAQIDetailText");
                this.RenderImagesListBox = (ListBox) base.FindName("RenderImagesListBox");
                this.LeftFrame = (Grid) base.FindName("LeftFrame");
                this.Expand = (Storyboard) base.FindName("Expand");
                this.LeftFrameExpandAnimation = (DoubleAnimation) base.FindName("LeftFrameExpandAnimation");
                this.LeftFrameNewExpand = (Storyboard) base.FindName("LeftFrameNewExpand");
                this.ForecastExpandAnimation = (DoubleAnimation) base.FindName("ForecastExpandAnimation");
                this.ActuallyExpandAnimation = (DoubleAnimation) base.FindName("ActuallyExpandAnimation");
                this.QualityExpandAnimation = (DoubleAnimation) base.FindName("QualityExpandAnimation");
                this.ActuallyFrame_Old = (Grid) base.FindName("ActuallyFrame_Old");
                this.Tab = (TabControl) base.FindName("Tab");
                this.AQITabItem = (TabItem) base.FindName("AQITabItem");
                this.AQITabItemGrid = (Grid) base.FindName("AQITabItemGrid");
                this.dgAQI_Old = (DataGrid) base.FindName("dgAQI_Old");
                this.WRWTabItem = (TabItem) base.FindName("WRWTabItem");
                this.WRWTabItemGrid = (Grid) base.FindName("WRWTabItemGrid");
                this.LeftFrameTopRectangle_Old = (Rectangle) base.FindName("LeftFrameTopRectangle_Old");
                this.dgWRW_Old = (DataGrid) base.FindName("dgWRW_Old");
                this.lbl_DateTime_Old = (Run) base.FindName("lbl_DateTime_Old");
                this.wrwButtonsBorder_Old = (Border) base.FindName("wrwButtonsBorder_Old");
                this.wrwButtons_Old = (Canvas) base.FindName("wrwButtons_Old");
                this.PM25Storyboard_Old = (Storyboard) base.FindName("PM25Storyboard_Old");
                this.PM10Storyboard_Old = (Storyboard) base.FindName("PM10Storyboard_Old");
                this.SO2Storyboard_Old = (Storyboard) base.FindName("SO2Storyboard_Old");
                this.NO2Storyboard_Old = (Storyboard) base.FindName("NO2Storyboard_Old");
                this.O31Storyboard_Old = (Storyboard) base.FindName("O31Storyboard_Old");
                this.COStoryboard_Old = (Storyboard) base.FindName("COStoryboard_Old");
                this.wrw_pm25_Old = (ToggleButton) base.FindName("wrw_pm25_Old");
                this.wrw_pm10_Old = (ToggleButton) base.FindName("wrw_pm10_Old");
                this.wrw_so2_Old = (ToggleButton) base.FindName("wrw_so2_Old");
                this.wrw_no2_Old = (ToggleButton) base.FindName("wrw_no2_Old");
                this.wrw_o31_Old = (ToggleButton) base.FindName("wrw_o31_Old");
                this.wrw_co_Old = (ToggleButton) base.FindName("wrw_co_Old");
                this.ActuallyFrame = (Border) base.FindName("ActuallyFrame");
                this.TabDivActually = (Grid) base.FindName("TabDivActually");
                this.ActuallyLeftTabItem = (ColumnDefinition) base.FindName("ActuallyLeftTabItem");
                this.ActuallyRightTabItem = (ColumnDefinition) base.FindName("ActuallyRightTabItem");
                this.ActuallyPanelHeader = (Grid) base.FindName("ActuallyPanelHeader");
                this.btnActuallyExpand = (PushedImageButton) base.FindName("btnActuallyExpand");
                this.lbl_DateTime_WRW = (Run) base.FindName("lbl_DateTime_WRW");
                this.LeftFrameWrwCollapsedBottomRectangle = (Rectangle) base.FindName("LeftFrameWrwCollapsedBottomRectangle");
                this.ActuallyGrid = (Grid) base.FindName("ActuallyGrid");
                this.LeftFrameTopRectangle = (Rectangle) base.FindName("LeftFrameTopRectangle");
                this.dgWRW = (DataGrid) base.FindName("dgWRW");
                this.wrwButtonsBorder = (Border) base.FindName("wrwButtonsBorder");
                this.wrwButtons = (Canvas) base.FindName("wrwButtons");
                this.PM25Storyboard = (Storyboard) base.FindName("PM25Storyboard");
                this.PM10Storyboard = (Storyboard) base.FindName("PM10Storyboard");
                this.SO2Storyboard = (Storyboard) base.FindName("SO2Storyboard");
                this.NO2Storyboard = (Storyboard) base.FindName("NO2Storyboard");
                this.O31Storyboard = (Storyboard) base.FindName("O31Storyboard");
                this.COStoryboard = (Storyboard) base.FindName("COStoryboard");
                this.wrw_pm25 = (ToggleButton) base.FindName("wrw_pm25");
                this.wrw_so2 = (ToggleButton) base.FindName("wrw_so2");
                this.wrw_no2 = (ToggleButton) base.FindName("wrw_no2");
                this.wrw_o31 = (ToggleButton) base.FindName("wrw_o31");
                this.wrw_co = (ToggleButton) base.FindName("wrw_co");
                this.wrw_pm10 = (ToggleButton) base.FindName("wrw_pm10");
                this.AirQualityFrame = (Border) base.FindName("AirQualityFrame");
                this.TabDivQuality = (Grid) base.FindName("TabDivQuality");
                this.QualityHeader = (Grid) base.FindName("QualityHeader");
                this.QualityLeftTabItem = (ColumnDefinition) base.FindName("QualityLeftTabItem");
                this.QualityRightTabItem = (ColumnDefinition) base.FindName("QualityRightTabItem");
                this.QualityPanelHeader = (Grid) base.FindName("QualityPanelHeader");
                this.btnQualityExpand = (PushedImageButton) base.FindName("btnQualityExpand");
                this.QualityGrid = (Grid) base.FindName("QualityGrid");
                this.lbl_DateTime_AQI = (Run) base.FindName("lbl_DateTime_AQI");
                this.dgAQIGrid = (Grid) base.FindName("dgAQIGrid");
                this.dgAQI = (DataGrid) base.FindName("dgAQI");
                this.DayForecastPanel = (Border) base.FindName("DayForecastPanel");
                this.TabDiv = (Grid) base.FindName("TabDiv");
                this.yb_jl4_2 = (Grid) base.FindName("yb_jl4_2");
                this.ForecaseLeftTabItem = (ColumnDefinition) base.FindName("ForecaseLeftTabItem");
                this.ForecaseRightTabItem = (ColumnDefinition) base.FindName("ForecaseRightTabItem");
                this.ForecastPanelHeader = (Grid) base.FindName("ForecastPanelHeader");
                this.btnForecastExpand = (PushedImageButton) base.FindName("btnForecastExpand");
                this.ForecastGridBorder = (Border) base.FindName("ForecastGridBorder");
                this.forecastGrid = (DataGrid) base.FindName("forecastGrid");
                this.forecastMsg = (Grid) base.FindName("forecastMsg");
                this.ExpandButtonGrid = (Grid) base.FindName("ExpandButtonGrid");
                this.Line1 = (Rectangle) base.FindName("Line1");
                this.Line2 = (Rectangle) base.FindName("Line2");
                this.Line3 = (Rectangle) base.FindName("Line3");
                this.Line4 = (Rectangle) base.FindName("Line4");
                this.btnExpand = (ToggleButton) base.FindName("btnExpand");
                this.btnExpandTooTip = (TextBlock) base.FindName("btnExpandTooTip");
                this.FloatWRWPopup = (FloatPopup) base.FindName("FloatWRWPopup");
                this.WRWPopupBorder = (Border) base.FindName("WRWPopupBorder");
                this.WRWPopupBackground = (Grid) base.FindName("WRWPopupBackground");
                this.wrwqp_8 = (Grid) base.FindName("wrwqp_8");
                this.wrwqp_9 = (Grid) base.FindName("wrwqp_9");
                this.wrwqp_11 = (Grid) base.FindName("wrwqp_11");
                this.wrwqp_12 = (Grid) base.FindName("wrwqp_12");
                this.WRWChartPanel = (Grid) base.FindName("WRWChartPanel");
                this.WRWExpandAnimation = (DoubleAnimation) base.FindName("WRWExpandAnimation");
                this.WRWChart = (Chart) base.FindName("WRWChart");
                this.WRWChartTitle = (TextBlock) base.FindName("WRWChartTitle");
                this.XAxis = (DateTimeAxis) base.FindName("XAxis");
                this.YAxis = (LinearAxis) base.FindName("YAxis");
                this.WRWChartText = (TextBlock) base.FindName("WRWChartText");
                this.wrwqp_16 = (Grid) base.FindName("wrwqp_16");
                this.btnWRWExpand = (ToggleButton) base.FindName("btnWRWExpand");
                this.FloatAQIPopup = (FloatPopup) base.FindName("FloatAQIPopup");
                this.AQIPopupBorder = (Border) base.FindName("AQIPopupBorder");
                this.AQIPopupBackground = (Grid) base.FindName("AQIPopupBackground");
                this.aqi_26 = (Grid) base.FindName("aqi_26");
                this.aqi_27 = (Grid) base.FindName("aqi_27");
                this.aqi_28 = (Grid) base.FindName("aqi_28");
                this.aqi_29 = (Grid) base.FindName("aqi_29");
                this.aqi_30 = (Grid) base.FindName("aqi_30");
                this.AQIPanel = (Grid) base.FindName("AQIPanel");
                this.AQIExpandAnimation = (DoubleAnimation) base.FindName("AQIExpandAnimation");
                this.AQIDataGrid = (DataGrid) base.FindName("AQIDataGrid");
                this.AQIPopupBottom = (Grid) base.FindName("AQIPopupBottom");
                this.btnAQIExpand = (ToggleButton) base.FindName("btnAQIExpand");
                this.FloatForecastPopup = (FloatPopup) base.FindName("FloatForecastPopup");
                this.ForecastBorder = (Border) base.FindName("ForecastBorder");
                this.yb_2 = (Grid) base.FindName("yb_2");
                this.ForecastPopupHeader = (Grid) base.FindName("ForecastPopupHeader");
                this.ForecastNight = (Grid) base.FindName("ForecastNight");
                this.ForecastNightStationName = (Grid) base.FindName("ForecastNightStationName");
                this.yb_30 = (Grid) base.FindName("yb_30");
                this.yb_39 = (Grid) base.FindName("yb_39");
                this.yb_40 = (Grid) base.FindName("yb_40");
                this.ForecastNightConent = (Grid) base.FindName("ForecastNightConent");
                this.ForecastDay = (Grid) base.FindName("ForecastDay");
                this.ForecastDayStationName = (Grid) base.FindName("ForecastDayStationName");
                this.yb_61 = (Grid) base.FindName("yb_61");
                this.yb_62 = (Grid) base.FindName("yb_62");
                this.yb_65 = (Grid) base.FindName("yb_65");
                this.yb_66 = (Grid) base.FindName("yb_66");
                this.AlertWnd = (Marquee) base.FindName("AlertWnd");
                this.MapRange = (TextBox) base.FindName("MapRange");
                this.txtbWebCounts = (TextBlock) base.FindName("txtbWebCounts");
            }
        }

        private void LeftFrameExpand_Completed(object sender, EventArgs e)
        {
            bool valueOrDefault = this.btnExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        this.btnExpand.set_Background(base.get_Resources().get_Item("LeftFrameCollapsedImageBrush") as ImageBrush);
                        this.btnExpandTooTip.set_Text("收起");
                        ((BSMapMode) this.map.Mode).LeftFrameWidth = this.LeftFrameWidth;
                        ((BSMapMode) this.map.Mode).SetMapRange();
                        break;

                    case true:
                        this.btnExpand.set_Background(base.get_Resources().get_Item("LeftFrameExpandImageBrush") as ImageBrush);
                        this.btnExpandTooTip.set_Text("放下");
                        ((BSMapMode) this.map.Mode).LeftFrameWidth = 0.0;
                        ((BSMapMode) this.map.Mode).SetMapRange();
                        return;

                    default:
                        return;
                }
            }
        }

        private void LeftFrameExpandNew_Completed(object sender, EventArgs e)
        {
            switch (this.bLeftFrameExpanded)
            {
                case false:
                    this.ForecastGridBorder.set_Height(double.NaN);
                    this.btnForecastExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpUp.png", UriKind.Relative));
                    this.btnForecastExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpDown.png", UriKind.Relative));
                    this.btnForecastExpand.set_Content("收起");
                    this.btnActuallyExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpUp.png", UriKind.Relative));
                    this.btnActuallyExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpDown.png", UriKind.Relative));
                    this.btnActuallyExpand.set_Content("收起");
                    this.btnQualityExpand.set_Content("收起");
                    this.btnQualityExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpUp.png", UriKind.Relative));
                    this.btnQualityExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/UpDown.png", UriKind.Relative));
                    ((BSMapMode) this.map.Mode).LeftFrameWidth = this.LeftFrameWidth;
                    ((BSMapMode) this.map.Mode).SetMapRange();
                    this.bLeftFrameExpanded = true;
                    return;

                case true:
                    this.btnForecastExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownUp.png", UriKind.Relative));
                    this.btnForecastExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownDown.png", UriKind.Relative));
                    this.btnForecastExpand.set_Content("展开");
                    this.btnActuallyExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownUp.png", UriKind.Relative));
                    this.btnActuallyExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownDown.png", UriKind.Relative));
                    this.btnActuallyExpand.set_Content("展开");
                    this.btnQualityExpand.NormalImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownUp.png", UriKind.Relative));
                    this.btnQualityExpand.PushedImage.set_UriSource(new Uri("/BEPB;component/Images/LeftFrame/Expand/DownDown.png", UriKind.Relative));
                    this.btnQualityExpand.set_Content("展开");
                    ((BSMapMode) this.map.Mode).LeftFrameWidth = 0.0;
                    ((BSMapMode) this.map.Mode).SetMapRange();
                    this.bLeftFrameExpanded = false;
                    return;
            }
        }

        private void MainPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.Focus();
        }

        private void map_ViewChangeEnd(object sender, MapEventArgs e)
        {
            if (this.bMoveAnimating)
            {
                this.bMoveAnimating = false;
                this.OpenAQIWRWFloatPopup();
            }
        }

        private void MapStation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan span = (TimeSpan) (DateTime.Now - this.LastStationClick);
            this.ClickedStation = sender as StationPushpin;
            this.LastStationClick = DateTime.Now;
            if (span.TotalMilliseconds < 300.0)
            {
                this.MapRange.set_Text(this.MapRange.get_Text() + span.TotalMilliseconds.ToString() + " ms\n");
                this.DoubleClickTimer.Stop();
            }
            else
            {
                this.DoubleClickTimer.Start();
            }
        }

        private void MapToolBar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton)
            {
                ToggleButton button = sender as ToggleButton;
                string str = button.get_Name();
                if (str != null)
                {
                    if (!(str == "btn_yx"))
                    {
                        if (!(str == "btn_dx"))
                        {
                            if (str == "btn_sl")
                            {
                                if ((Application.get_Current() as App).bLocalMapImage)
                                {
                                    LocalTiandituTileSource source5 = this.epbMapTileLayer.TileSources[0] as LocalTiandituTileSource;
                                    if (source5 == null)
                                    {
                                        return;
                                    }
                                    source5.MapSource = MapSource.VEC;
                                }
                                else
                                {
                                    TiandituTileSource source6 = this.epbMapTileLayer.TileSources[0] as TiandituTileSource;
                                    if (source6 == null)
                                    {
                                        return;
                                    }
                                    source6.MapSource = MapSource.VEC;
                                }
                                this.东城区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.西城区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.朝阳区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.丰台区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.石景山区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.海淀区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.门头沟区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.房山区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.通州区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.顺义区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.昌平区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.大兴区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.怀柔区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.平谷区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.密云县Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.延庆县Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.NorthEastBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.NorthWestBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.CityCenterBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.SouthEastBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.SouthWestBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.HuaiRou.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.MiYun.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.YanQing.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.ChangPing.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.PingGu.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.ShunYi.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.MenTouGou.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.HaiDian.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.ChaoYang.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.TongZhou.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.ShiJingShan.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.DongCheng.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.XiCheng.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.FangShan.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.FengTai.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.DaXing.Stroke = new SolidColorBrush(Colors.get_Black());
                                this.NorthEastText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.NorthWestText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.CityCenterText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.SouthEastText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                                this.SouthWestText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                            }
                            return;
                        }
                    }
                    else
                    {
                        if ((Application.get_Current() as App).bLocalMapImage)
                        {
                            LocalTiandituTileSource source = this.epbMapTileLayer.TileSources[0] as LocalTiandituTileSource;
                            if (source == null)
                            {
                                return;
                            }
                            source.MapSource = MapSource.IMG;
                        }
                        else
                        {
                            TiandituTileSource source2 = this.epbMapTileLayer.TileSources[0] as TiandituTileSource;
                            if (source2 == null)
                            {
                                return;
                            }
                            source2.MapSource = MapSource.IMG;
                        }
                        this.东城区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.西城区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.朝阳区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.丰台区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.石景山区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.海淀区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.门头沟区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.房山区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.通州区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.顺义区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.昌平区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.大兴区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.怀柔区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.平谷区Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.密云县Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.延庆县Name.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.NorthEastBorder.Stroke = new SolidColorBrush(Colors.get_White());
                        this.NorthWestBorder.Stroke = new SolidColorBrush(Colors.get_White());
                        this.CityCenterBorder.Stroke = new SolidColorBrush(Colors.get_White());
                        this.SouthEastBorder.Stroke = new SolidColorBrush(Colors.get_White());
                        this.SouthWestBorder.Stroke = new SolidColorBrush(Colors.get_White());
                        this.HuaiRou.Stroke = new SolidColorBrush(Colors.get_White());
                        this.MiYun.Stroke = new SolidColorBrush(Colors.get_White());
                        this.YanQing.Stroke = new SolidColorBrush(Colors.get_White());
                        this.ChangPing.Stroke = new SolidColorBrush(Colors.get_White());
                        this.PingGu.Stroke = new SolidColorBrush(Colors.get_White());
                        this.ShunYi.Stroke = new SolidColorBrush(Colors.get_White());
                        this.MenTouGou.Stroke = new SolidColorBrush(Colors.get_White());
                        this.HaiDian.Stroke = new SolidColorBrush(Colors.get_White());
                        this.ChaoYang.Stroke = new SolidColorBrush(Colors.get_White());
                        this.TongZhou.Stroke = new SolidColorBrush(Colors.get_White());
                        this.ShiJingShan.Stroke = new SolidColorBrush(Colors.get_White());
                        this.DongCheng.Stroke = new SolidColorBrush(Colors.get_White());
                        this.XiCheng.Stroke = new SolidColorBrush(Colors.get_White());
                        this.FangShan.Stroke = new SolidColorBrush(Colors.get_White());
                        this.FengTai.Stroke = new SolidColorBrush(Colors.get_White());
                        this.DaXing.Stroke = new SolidColorBrush(Colors.get_White());
                        this.NorthEastText.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.NorthWestText.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.CityCenterText.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.SouthEastText.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        this.SouthWestText.set_Foreground(new SolidColorBrush(Colors.get_White()));
                        return;
                    }
                    if ((Application.get_Current() as App).bLocalMapImage)
                    {
                        LocalTiandituTileSource source3 = this.epbMapTileLayer.TileSources[0] as LocalTiandituTileSource;
                        if (source3 == null)
                        {
                            return;
                        }
                        source3.MapSource = MapSource.TER;
                    }
                    else
                    {
                        TiandituTileSource source4 = this.epbMapTileLayer.TileSources[0] as TiandituTileSource;
                        if (source4 == null)
                        {
                            return;
                        }
                        source4.MapSource = MapSource.TER;
                    }
                    this.东城区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.西城区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.朝阳区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.丰台区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.石景山区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.海淀区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.门头沟区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.房山区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.通州区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.顺义区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.昌平区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.大兴区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.怀柔区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.平谷区Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.密云县Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.延庆县Name.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.NorthEastBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.NorthWestBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.CityCenterBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.SouthEastBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.SouthWestBorder.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.HuaiRou.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.MiYun.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.YanQing.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.ChangPing.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.PingGu.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.ShunYi.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.MenTouGou.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.HaiDian.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.ChaoYang.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.TongZhou.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.ShiJingShan.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.DongCheng.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.XiCheng.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.FangShan.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.FengTai.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.DaXing.Stroke = new SolidColorBrush(Colors.get_Black());
                    this.NorthEastText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.NorthWestText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.CityCenterText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.SouthEastText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                    this.SouthWestText.set_Foreground(new SolidColorBrush(Colors.get_Black()));
                }
            }
        }

        private void MapToolBar_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void MapToolBar_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void NO2Storyboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrw_o31.set_Visibility(0);
                Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("O31Storyboard") as Storyboard;
                DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
                if (animation != null)
                {
                    animation.set_To(0.0);
                }
                storyboard.Begin();
                return;
            }
            Storyboard storyboard2 = this.wrwButtons.get_Resources().get_Item("SO2Storyboard") as Storyboard;
            DoubleAnimation animation2 = storyboard2.get_Children().get_Item(0) as DoubleAnimation;
            if (animation2 != null)
            {
                animation2.set_To(-332.0);
                string str = this.screenHeight.ToString();
                if (str != null)
                {
                    if (!(str == "1080"))
                    {
                        if ((str == "900") || (str == "768"))
                        {
                        }
                    }
                    else
                    {
                        animation2.set_To(-332.0);
                        goto Label_0123;
                    }
                }
                animation2.set_To(-302.0);
            }
        Label_0123:
            storyboard2.Begin();
        }

        private void O31Storyboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrw_co.set_Visibility(0);
                Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("COStoryboard") as Storyboard;
                DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
                if (animation != null)
                {
                    animation.set_To(0.0);
                }
                storyboard.Begin();
                return;
            }
            Storyboard storyboard2 = this.wrwButtons.get_Resources().get_Item("NO2Storyboard") as Storyboard;
            DoubleAnimation animation2 = storyboard2.get_Children().get_Item(0) as DoubleAnimation;
            if (animation2 != null)
            {
                animation2.set_To(-332.0);
                string str = this.screenHeight.ToString();
                if (str != null)
                {
                    if (!(str == "1080"))
                    {
                        if ((str == "900") || (str == "768"))
                        {
                        }
                    }
                    else
                    {
                        animation2.set_To(-332.0);
                        goto Label_0123;
                    }
                }
                animation2.set_To(-302.0);
            }
        Label_0123:
            storyboard2.Begin();
        }

        private void OpenAQIWRWFloatPopup()
        {
            DataGrid dgWRW = null;
            Func<WRWData, bool> predicate = null;
            if (this.CurrentChannelName == "Actually")
            {
                dgWRW = this.dgWRW;
            }
            else if (this.CurrentChannelName == "Quality")
            {
                dgWRW = this.dgAQI;
            }
            if (dgWRW != null)
            {
                StationData selectedItem = dgWRW.SelectedItem as StationData;
                Point point = this.map.LocationToViewportPoint(this.LastStation.Location);
                point.set_X(point.get_X() * this.mapScale);
                point.set_Y(point.get_Y() * this.mapScale);
                string str = dgWRW.get_Name();
                if (str != null)
                {
                    if (!(str == "dgAQI"))
                    {
                        if (str == "dgWRW")
                        {
                            if (predicate == null)
                            {
                                predicate = x => x.Pollutant == this.CurrentWRWName;
                            }
                            WRWData data2 = selectedItem.WRWDataList.SingleOrDefault<WRWData>(predicate);
                            if (data2 != null)
                            {
                                this.FloatWRWPopup.set_DataContext(data2);
                            }
                            else
                            {
                                MessageBox.Show(this.CurrentWRWName + " Data == null");
                            }
                            this.WRWChartTitle.set_Text("");
                            this.WRWChart.Series.Clear();
                            double popupWidth = 419.0;
                            double wRWPopupHeight = this.GetWRWPopupHeight();
                            this.FloatWRWPopup.set_Width(popupWidth);
                            this.FloatWRWPopup.set_Height(wRWPopupHeight);
                            this.SetPopupOffset(point, selectedItem.District, popupWidth, wRWPopupHeight, ref this.FloatWRWPopup);
                            this.FloatWRWPopup.Open(point, new Rect(10.0, 10.0, this.map.get_ActualWidth() - 10.0, this.map.get_ActualHeight() - 10.0));
                            this.airDataContext.WRWData24hList.Clear();
                        }
                    }
                    else
                    {
                        this.FloatAQIPopup.set_DataContext(selectedItem);
                        double num = 315.0;
                        double aQIPopupHeight = this.GetAQIPopupHeight();
                        this.FloatAQIPopup.set_Width(num);
                        this.FloatAQIPopup.set_Height(aQIPopupHeight);
                        this.SetPopupOffset(point, selectedItem.District, num, aQIPopupHeight, ref this.FloatAQIPopup);
                        this.FloatAQIPopup.Open(point, new Rect(10.0, 10.0, this.map.get_ActualWidth() - 10.0, this.map.get_ActualHeight() - 10.0));
                    }
                }
            }
        }

        private void OpenForecastFloatPopup()
        {
            Point point = new Point(0.0, 0.0);
            if (this.forecastGrid.SelectedItem != null)
            {
                this.airDataContext.CurrentZoneForecast = this.forecastGrid.SelectedItem as BEPB.Forecast;
                this.forecastMsg.set_Visibility(0);
                string zone = this.airDataContext.CurrentZoneForecast.Zone;
                if (zone != null)
                {
                    if (!(zone == "城六区"))
                    {
                        if (zone == "西北部")
                        {
                            if (this.LastSelectedFive != this.NorthWest)
                            {
                                if (this.LastSelectedFive != null)
                                {
                                    this.LastSelectedFive.Fill = this.LastSelectedFiveBrush;
                                }
                                this.LastSelectedFive = this.NorthWest;
                                this.LastSelectedFiveBrush = this.brFive;
                            }
                            this.NorthWest.Fill = new SolidColorBrush(Colors.get_Red());
                            point = this.map.LocationToViewportPoint(this.NorthWestText.Location);
                        }
                        else if (zone == "东北部")
                        {
                            if (this.LastSelectedFive != this.NorthEast)
                            {
                                if (this.LastSelectedFive != null)
                                {
                                    this.LastSelectedFive.Fill = this.LastSelectedFiveBrush;
                                }
                                this.LastSelectedFive = this.NorthEast;
                                this.LastSelectedFiveBrush = this.brFive;
                            }
                            this.NorthEast.Fill = new SolidColorBrush(Colors.get_Red());
                            point = this.map.LocationToViewportPoint(this.NorthEastText.Location);
                        }
                        else if (zone == "东南部")
                        {
                            if (this.LastSelectedFive != this.SouthEast)
                            {
                                if (this.LastSelectedFive != null)
                                {
                                    this.LastSelectedFive.Fill = this.LastSelectedFiveBrush;
                                }
                                this.LastSelectedFive = this.SouthEast;
                                this.LastSelectedFiveBrush = this.brFive;
                            }
                            this.SouthEast.Fill = new SolidColorBrush(Colors.get_Red());
                            point = this.map.LocationToViewportPoint(this.SouthEastText.Location);
                        }
                        else if (zone == "西南部")
                        {
                            if (this.LastSelectedFive != this.SouthWest)
                            {
                                if (this.LastSelectedFive != null)
                                {
                                    this.LastSelectedFive.Fill = this.LastSelectedFiveBrush;
                                }
                                this.LastSelectedFive = this.SouthWest;
                                this.LastSelectedFiveBrush = this.brFive;
                            }
                            this.SouthWest.Fill = new SolidColorBrush(Colors.get_Red());
                            point = this.map.LocationToViewportPoint(this.SouthWestText.Location);
                        }
                    }
                    else
                    {
                        if (this.LastSelectedFive != this.CityCenter)
                        {
                            if (this.LastSelectedFive != null)
                            {
                                this.LastSelectedFive.Fill = this.LastSelectedFiveBrush;
                            }
                            this.LastSelectedFive = this.CityCenter;
                            this.LastSelectedFiveBrush = this.brFive;
                        }
                        this.CityCenter.Fill = new SolidColorBrush(Colors.get_Red());
                        point = this.map.LocationToViewportPoint(this.CityCenterText.Location);
                    }
                }
            }
            this.ForecastBorder.set_DataContext(this.airDataContext.CurrentZoneForecast);
            double popupWidth = 315.0;
            double popupHeight = 254.0;
            string isNight = this.airDataContext.CurrentZoneForecast.IsNight;
            if (isNight != null)
            {
                if (!(isNight == "0"))
                {
                    if (isNight == "1")
                    {
                        popupHeight = 462.0;
                    }
                }
                else
                {
                    popupHeight = 254.0;
                }
            }
            this.FloatForecastPopup.set_Width(popupWidth);
            this.FloatForecastPopup.set_Height(popupHeight);
            point.set_X(point.get_X() * this.mapScale);
            point.set_Y(point.get_Y() * this.mapScale);
            this.SetPopupOffset(point, this.airDataContext.CurrentZoneForecast.Zone, popupWidth, popupHeight, ref this.FloatForecastPopup);
            this.FloatForecastPopup.Open(point, new Rect(10.0, 10.0, this.map.get_ActualWidth() - 10.0, this.map.get_ActualHeight() - 10.0));
        }

        private void p_bottom_aqi_MouseEnter(object sender, MouseEventArgs e)
        {
            this.dgAQIDetailText.set_Visibility(0);
        }

        private void p_bottom_aqi_MouseLeave(object sender, MouseEventArgs e)
        {
            this.dgAQIDetailText.set_Visibility(1);
        }

        private void PM10Storyboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrwButtons.set_Clip(null);
                return;
            }
            Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard;
            DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
            if (animation != null)
            {
                animation.set_BeginTime(new TimeSpan(0, 0, 0));
                string str = this.screenHeight.ToString();
                if (str != null)
                {
                    if (!(str == "1080"))
                    {
                        if ((str == "900") || (str == "768"))
                        {
                        }
                    }
                    else
                    {
                        animation.set_To(-332.0);
                        goto Label_00D3;
                    }
                }
                animation.set_To(-302.0);
            }
        Label_00D3:
            storyboard.Begin();
        }

        private void PM25Storyboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrw_so2.set_Visibility(0);
                Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("SO2Storyboard") as Storyboard;
                DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
                if (animation != null)
                {
                    animation.set_To(0.0);
                }
                storyboard.Begin();
            }
        }

        private void SelectStation(DataGrid sender)
        {
            if (this.FloatAQIPopup.IsOpen)
            {
                this.FloatAQIPopup.IsOpen = false;
            }
            if (this.FloatWRWPopup.IsOpen)
            {
                this.FloatWRWPopup.IsOpen = false;
            }
            DataGrid grid = sender;
            if ((grid != null) && (grid.SelectedIndex != -1))
            {
                if (this.LastStation != null)
                {
                    this.LastStation.IsFocused = false;
                }
                StationData selectedItem = grid.SelectedItem as StationData;
                this.LastStation = this.GetStation(selectedItem.Station);
                if (this.LastStation.DataVisibility != 1)
                {
                    this.LastStation.IsFocused = true;
                    Point viewportPoint = new Point(this.LeftFrame.get_ActualWidth(), 0.0);
                    Location location = this.map.ViewportPointToLocation(viewportPoint);
                    LocationRect rect = new LocationRect {
                        West = this.map.BoundingRectangle.West + ((location.Longitude - this.map.BoundingRectangle.West) / this.mapScale),
                        North = this.map.BoundingRectangle.North,
                        East = this.map.BoundingRectangle.West + ((this.map.BoundingRectangle.East - this.map.BoundingRectangle.West) / this.mapScale),
                        South = this.map.BoundingRectangle.North - ((this.map.BoundingRectangle.North - this.map.BoundingRectangle.South) / this.mapScale)
                    };
                    Location location2 = new Location {
                        Longitude = this.map.BoundingRectangle.West + ((this.map.Center.Longitude - this.map.BoundingRectangle.West) / this.mapScale),
                        Latitude = this.map.BoundingRectangle.North - ((this.map.Center.Latitude - this.map.BoundingRectangle.South) / this.mapScale)
                    };
                    if (((rect.West <= this.LastStation.Location.Longitude) && (this.LastStation.Location.Longitude <= rect.East)) && ((rect.South <= this.LastStation.Location.Latitude) && (this.LastStation.Location.Latitude <= rect.North)))
                    {
                        this.OpenAQIWRWFloatPopup();
                    }
                    else
                    {
                        Location location3 = new Location {
                            Longitude = this.LastStation.Location.Longitude,
                            Latitude = this.LastStation.Location.Latitude
                        };
                        if (this.LastStation.Location.Longitude < rect.West)
                        {
                            if ((this.LastStation.Location.Longitude - this.BeijingWest) > (location2.Longitude - rect.West))
                            {
                                location3.Longitude = this.LastStation.Location.Longitude;
                            }
                            else
                            {
                                location3.Longitude = this.BeijingWest + (location2.Longitude - rect.West);
                            }
                        }
                        else if (this.LastStation.Location.Longitude > rect.East)
                        {
                            if ((this.BeijingEast - this.LastStation.Location.Longitude) > (rect.East - location2.Longitude))
                            {
                                location3.Longitude = this.LastStation.Location.Longitude;
                            }
                            else
                            {
                                location3.Longitude = this.BeijingEast - (rect.East - location2.Longitude);
                            }
                        }
                        if (this.LastStation.Location.Latitude > rect.North)
                        {
                            if ((this.BeijingNorth - this.LastStation.Location.Latitude) > (rect.North - location2.Latitude))
                            {
                                location3.Latitude = this.LastStation.Location.Latitude;
                            }
                            else
                            {
                                location3.Latitude = this.BeijingNorth - (rect.North - location2.Latitude);
                            }
                        }
                        else if (this.LastStation.Location.Latitude < rect.South)
                        {
                            if ((this.LastStation.Location.Latitude - this.BeijingSouth) > (location2.Latitude - rect.South))
                            {
                                location3.Latitude = this.LastStation.Location.Latitude;
                            }
                            else
                            {
                                location3.Latitude = this.BeijingSouth + (location2.Latitude - rect.South);
                            }
                        }
                        Location center = new Location {
                            Longitude = location3.Longitude + (((this.map.BoundingRectangle.East - this.map.BoundingRectangle.West) / 2.0) * (1.0 - (1.0 / this.mapScale))),
                            Latitude = location3.Latitude - (((this.map.BoundingRectangle.North - this.map.BoundingRectangle.South) / 2.0) * (1.0 - (1.0 / this.mapScale)))
                        };
                        this.bMoveAnimating = true;
                        this.bsMapMode.SetView(center, this.bsMapMode.ZoomLevel, 0.0, 0.0, this.bMoveAnimating);
                    }
                }
            }
        }

        private void SetPopupOffset(Point point, string District, double PopupWidth, double PopupHeight, ref FloatPopup floatPopup)
        {
            Dictionary<string, Point> dictionary = new Dictionary<string, Point>();
            switch (District)
            {
                case "西北部":
                    this.PopupHOriginOffset = 80.0;
                    this.PopupVOriginOffset = -40.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    break;

                case "东北部":
                    this.PopupHOriginOffset = 180.0;
                    this.PopupVOriginOffset = 0.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    break;

                case "城六区":
                    this.PopupHOriginOffset = 230.0;
                    this.PopupVOriginOffset = 230.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    break;

                case "西南部":
                    this.PopupHOriginOffset = 160.0;
                    this.PopupVOriginOffset = 60.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    break;

                case "东南部":
                    this.PopupHOriginOffset = 170.0;
                    this.PopupVOriginOffset = 120.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    break;

                case "延庆县":
                    this.PopupHOriginOffset = 60.0;
                    this.PopupVOriginOffset = -60.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    break;

                case "昌平区":
                    this.PopupHOriginOffset = 150.0;
                    this.PopupVOriginOffset = 0.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;

                case "怀柔区":
                case "密云县":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    break;

                case "顺义区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    break;

                case "平谷区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    break;

                case "东城区":
                case "西城区":
                case "朝阳区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;

                case "海淀区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;

                case "石景山区":
                case "丰台区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;

                case "门头沟区":
                case "房山区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Right;
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;

                case "通州区":
                case "大兴区":
                    this.PopupHOriginOffset = 200.0;
                    this.PopupVOriginOffset = 100.0;
                    floatPopup.ArrowPlacement = Dock.Left;
                    dictionary.Add("SouthEast1", this.map.LocationToViewportPoint(this.PopSouthEast1));
                    dictionary.Add("SouthEast2", this.map.LocationToViewportPoint(this.PopSouthEast2));
                    dictionary.Add("SouthWest", this.map.LocationToViewportPoint(this.PopSouthWest));
                    dictionary.Add("NorthWest2", this.map.LocationToViewportPoint(this.PopNorthWest2));
                    dictionary.Add("NorthEast1", this.map.LocationToViewportPoint(this.PopNorthEast1));
                    dictionary.Add("NorthWest1", this.map.LocationToViewportPoint(this.PopNorthWest1));
                    dictionary.Add("NorthEast2", this.map.LocationToViewportPoint(this.PopNorthEast2));
                    break;
            }
            double num = 0.0;
            double num2 = 0.0;
            if (this.DayForecastPanel.get_Visibility() == null)
            {
                num = this.DayForecastPanel.get_ActualWidth();
                num2 = this.DayForecastPanel.get_ActualHeight();
            }
            else if (this.ActuallyFrame.get_Visibility() == null)
            {
                num = this.ActuallyFrame.get_ActualWidth();
                num2 = this.ActuallyFrame.get_ActualHeight();
            }
            foreach (KeyValuePair<string, Point> pair in dictionary)
            {
                Point point2 = pair.Value;
                point2.set_X(point2.get_X() * this.mapScale);
                point2.set_Y(point2.get_Y() * this.mapScale);
                double num3 = point2.get_X();
                bool flag = false;
                switch (pair.Key)
                {
                    case "NorthWest1":
                    {
                        if (point2.get_Y() < (num2 + PopupHeight))
                        {
                            num3 = point2.get_X() - num;
                        }
                        double num4 = 1.0;
                        if (num2 == 0.0)
                        {
                            num4 = 0.6;
                        }
                        if ((num3 >= (PopupWidth * num4)) && (point2.get_Y() >= PopupHeight))
                        {
                            this.PopupHOriginOffset = point.get_X() - point2.get_X();
                            this.PopupVOriginOffset = point2.get_Y() - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Right;
                            flag = true;
                        }
                        break;
                    }
                    case "NorthWest2":
                    {
                        if (point2.get_Y() < (num2 + PopupHeight))
                        {
                            num3 = point2.get_X() - num;
                        }
                        double num5 = 1.0;
                        if (num2 == 0.0)
                        {
                            num5 = 0.9;
                        }
                        if ((num3 >= (PopupWidth * num5)) && (point2.get_Y() >= PopupHeight))
                        {
                            this.PopupHOriginOffset = point.get_X() - point2.get_X();
                            this.PopupVOriginOffset = point2.get_Y() - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Right;
                            flag = true;
                        }
                        break;
                    }
                    case "SouthWest":
                        if (((this.map.get_ActualHeight() - num2) - 10.0) < PopupHeight)
                        {
                            num3 = point2.get_X() - num;
                        }
                        if (num3 >= PopupWidth)
                        {
                            this.PopupHOriginOffset = point.get_X() - point2.get_X();
                            if (point2.get_Y() < num2)
                            {
                                this.PopupVOriginOffset = ((num2 + 10.0) + PopupHeight) - point.get_Y();
                            }
                            else
                            {
                                this.PopupVOriginOffset = (point2.get_Y() + PopupHeight) - point.get_Y();
                            }
                            floatPopup.ArrowPlacement = Dock.Right;
                            flag = true;
                        }
                        break;

                    case "NorthEast1":
                        if ((this.map.get_ActualWidth() - point2.get_X()) >= (PopupWidth * 0.9))
                        {
                            this.PopupHOriginOffset = point2.get_X() - point.get_X();
                            this.PopupVOriginOffset = point2.get_Y() - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Left;
                            flag = true;
                        }
                        break;

                    case "NorthEast2":
                        if (((this.map.get_ActualWidth() - point2.get_X()) >= (PopupWidth * 0.9)) && (point2.get_Y() > (PopupHeight * 0.7)))
                        {
                            this.PopupHOriginOffset = point2.get_X() - point.get_X();
                            this.PopupVOriginOffset = point2.get_Y() - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Left;
                            flag = true;
                        }
                        break;

                    case "SouthEast1":
                        if (((this.map.get_ActualWidth() - point2.get_X()) >= (PopupWidth * 0.9)) && ((this.map.get_ActualHeight() - point2.get_Y()) > (PopupHeight * 0.8)))
                        {
                            this.PopupHOriginOffset = point2.get_X() - point.get_X();
                            this.PopupVOriginOffset = (point2.get_Y() + PopupHeight) - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Left;
                            flag = true;
                        }
                        break;

                    case "SouthEast2":
                        if ((this.map.get_ActualWidth() - point2.get_X()) >= (PopupWidth * 0.9))
                        {
                            this.PopupHOriginOffset = point2.get_X() - point.get_X();
                            this.PopupVOriginOffset = (point2.get_Y() + PopupHeight) - point.get_Y();
                            floatPopup.ArrowPlacement = Dock.Left;
                            flag = true;
                        }
                        break;
                }
                if (flag)
                {
                    break;
                }
            }
            floatPopup.HOriginOffset = this.PopupHOriginOffset;
            floatPopup.VOriginOffset = this.PopupVOriginOffset;
        }

        private void SO2Storyboard_Completed(object sender, EventArgs e)
        {
            if (this.btnExpand.get_IsChecked() == false)
            {
                this.wrw_no2.set_Visibility(0);
                Storyboard storyboard = this.wrwButtons.get_Resources().get_Item("NO2Storyboard") as Storyboard;
                DoubleAnimation animation = storyboard.get_Children().get_Item(0) as DoubleAnimation;
                if (animation != null)
                {
                    animation.set_To(0.0);
                }
                storyboard.Begin();
                return;
            }
            Storyboard storyboard2 = this.wrwButtons.get_Resources().get_Item("PM10Storyboard") as Storyboard;
            DoubleAnimation animation2 = storyboard2.get_Children().get_Item(0) as DoubleAnimation;
            if (animation2 != null)
            {
                string str = this.screenHeight.ToString();
                if (str != null)
                {
                    if (!(str == "1080"))
                    {
                        if ((str == "900") || (str == "768"))
                        {
                        }
                    }
                    else
                    {
                        animation2.set_To(-332.0);
                        goto Label_010F;
                    }
                }
                animation2.set_To(-302.0);
            }
        Label_010F:
            storyboard2.Begin();
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl control = sender as TabControl;
            if (control != null)
            {
                if (control.SelectedIndex == 0)
                {
                    control.set_Background(base.get_Resources().get_Item("LeftFrameBackground400ImageBrush") as ImageBrush);
                    if (this.wrwButtonsBorder != null)
                    {
                        this.wrwButtonsBorder.set_Visibility(1);
                    }
                    if (this.dgAQI != null)
                    {
                        PagedCollectionView itemsSource = this.dgAQI.ItemsSource as PagedCollectionView;
                        foreach (StationData data in itemsSource)
                        {
                            StationPushpin station = this.GetStation(data.Station);
                            if (station != null)
                            {
                                if (station.IsFocused)
                                {
                                    station.IsFocused = false;
                                }
                                station.set_Background(data.BackColor);
                            }
                        }
                    }
                    if (this.wrwtlGrid != null)
                    {
                        this.wrwtlGrid.set_Visibility(1);
                    }
                    if (this.p_bottom_aqiGrid != null)
                    {
                        this.p_bottom_aqiGrid.set_Visibility(0);
                    }
                }
                else
                {
                    if (this.screenHeight >= 1080.0)
                    {
                        control.set_Background(base.get_Resources().get_Item("LeftFrameBackground400ImageBrush") as ImageBrush);
                        this.LeftFrameTopRectangle.set_Fill(base.get_Resources().get_Item("LeftFrameBackground420WrwTopImageBrush") as ImageBrush);
                    }
                    else
                    {
                        control.set_Background(base.get_Resources().get_Item("LeftFrameBackground400ImageBrush") as ImageBrush);
                        this.LeftFrameTopRectangle.set_Fill(base.get_Resources().get_Item("LeftFrameBackground400WrwTopImageBrush") as ImageBrush);
                    }
                    this.wrwButtonsBorder.set_Visibility(0);
                    if (this.WRWTabClicked == 0)
                    {
                        this.WRWTabClicked = 1;
                    }
                    if ((this.WRWTabClicked == 1) && this.bWRWDataLoaded)
                    {
                        this.wrw_pm25.set_Visibility(0);
                        (this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard).Begin();
                        this.WRWTabClicked = -1;
                    }
                    foreach (StationData data2 in this.dgWRW.ItemsSource)
                    {
                        StationPushpin pushpin2 = this.GetStation(data2.Station);
                        if (pushpin2 != null)
                        {
                            if (pushpin2.IsFocused)
                            {
                                pushpin2.IsFocused = false;
                            }
                            pushpin2.set_Background(new SolidColorBrush(Color.FromArgb(0xff, 0x40, 0x86, 0xa4)));
                        }
                    }
                    this.wrwtlGrid.set_Visibility(0);
                    this.p_bottom_aqiGrid.set_Visibility(1);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.MapRange.set_Text(this.MapRange.get_Text() + DateTime.Now.ToString("HH:mm:ss") + "  timer_Tick\n");
            this.dataService.GetWebDataAsync("GetRTC");
            this.dataService.GetWebAlertAsync();
            this.dataService.GetWebPredictAsync();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<BindingElement> bindingElementsInTopDownChannelStackOrder = new List<BindingElement> {
                new BinaryMessageEncodingBindingElement()
            };
            HttpTransportBindingElement item = new HttpTransportBindingElement {
                MaxBufferSize = 0x7fffffff,
                MaxReceivedMessageSize = 0x7fffffffL
            };
            bindingElementsInTopDownChannelStackOrder.Add(item);
            CustomBinding binding = new CustomBinding(bindingElementsInTopDownChannelStackOrder);
            this.dataService = new DataServiceClient(binding, new EndpointAddress(new Uri(Application.get_Current().get_Host().get_Source(), "../DataService.svc"), new AddressHeader[0]));
            this.dataService.GetWebPredictCompleted += new EventHandler<GetWebPredictCompletedEventArgs>(this.dataService_GetWebPredictCompleted);
            this.dataService.GetWebPredictAsync();
            this.dataService.GetWebDataCompleted += new EventHandler<GetWebDataCompletedEventArgs>(this.dataService_GetWebDataCompleted);
            this.dataService.GetWebDataAsync("GetRTC");
            this.dataService.GetWebAlertCompleted += new EventHandler<GetWebAlertCompletedEventArgs>(this.dataService_GetWebAlertCompleted);
            this.dataService.GetWebAlertAsync();
            this.dataService.DayForecastCompleted += new EventHandler<DayForecastCompletedEventArgs>(this.dataService_DayForecastCompleted);
            this.dataService.GetRTCCompleted += new EventHandler<GetRTCCompletedEventArgs>(this.dataService_GetRTCCompleted);
            this.dataService.GetRTC24hCompleted += new EventHandler<GetRTC24hCompletedEventArgs>(this.dataService_GetRTC24hCompleted);
            this.dataService.GetAlertCompleted += new EventHandler<GetAlertCompletedEventArgs>(this.dataService_GetAlertCompleted);
            this.timer = new DispatcherTimer();
            this.timer.set_Interval(new TimeSpan(0, 10, 0));
            this.timer.add_Tick(new EventHandler(this.timer_Tick));
            this.timer.Start();
            this.CurrentChannelName = this.Actually.get_Name();
            this.Actually.set_Source(new BitmapImage(new Uri("/BEPB;component/Images/ssnd-.png", UriKind.Relative)));
            (this.wrwButtons.get_Resources().get_Item("PM25Storyboard") as Storyboard).Begin();
            this.WRWChannelClicked = -1;
            this.CurrentWRWName = this.wrw_pm25.get_Tag().ToString();
            this.wrw_pm25.set_Background(base.get_Resources().get_Item("PM25_ImageBrush") as ImageBrush);
            this.dgWRW.Columns[1].Header = "PM2.5 浓度(微克/立方米)";
            this.BeijingCenter = new Location(this.BeijingSouth + ((this.BeijingNorth - this.BeijingSouth) / 2.0), this.BeijingWest + ((this.BeijingEast - this.BeijingWest) / 2.0));
            this.DowntownCenter = new Location(39.93157, 116.41005);
            double num = 28.0;
            double num2 = 12.0;
            double num3 = 14.0;
            double num4 = 20.0;
            double num5 = 0.0;
            ScriptObject property = (ScriptObject) HtmlPage.get_Window().GetProperty("screen");
            this.screenWidth = (double) property.GetProperty("width");
            this.screenHeight = (double) property.GetProperty("height");
            if (this.screenHeight >= 1080.0)
            {
                this.LineLength = 172.0;
                this.ActuallyGrid.set_Background(base.get_Resources().get_Item("LeftFrameBackground420WrwImageBrush") as ImageBrush);
                this.LeftFrameTopRectangle.set_Fill(base.get_Resources().get_Item("LeftFrameBackground420WrwTopImageBrush") as ImageBrush);
                this.LeftFrameWrwCollapsedBottomRectangle.set_Fill(base.get_Resources().get_Item("LeftFrameBackground420BottomImageBrush") as ImageBrush);
                this.StartZoomLevel = 9.0;
                this.EndZoomLevel = 11.0;
                this.BeijingCenter.Latitude += 0.00625;
                this.BeijingCenter.Longitude -= 0.15;
                this.mapScale = 1.0;
                this.东城区Name.set_FontSize(14.0);
                this.东城区Name.set_Content("东城区");
                this.东城区Name.Location = new Location(39.916, 116.408);
                this.西城区Name.set_FontSize(16.0);
                this.西城区Name.set_Content("西城区");
                this.西城区Name.Location = new Location(39.914, 116.358);
                this.朝阳区Name.set_FontSize(36.0);
                this.朝阳区Name.set_Content("朝    阳    区");
                this.朝阳区Name.Location = new Location(39.96, 116.52);
                this.丰台区Name.set_FontSize(36.0);
                this.丰台区Name.set_Content("丰          台          区");
                this.丰台区Name.Location = new Location(39.84, 116.27);
                this.石景山区Name.set_FontSize(22.0);
                this.石景山区Name.set_Content("石  景  山  区");
                this.石景山区Name.Location = new Location(39.90564, 116.2);
                this.海淀区Name.set_FontSize(36.0);
                this.海淀区Name.set_Content("海    淀    区");
                this.海淀区Name.Location = new Location(40.0, 116.26);
                this.门头沟区Name.set_FontSize(52.0);
                this.门头沟区Name.set_Content("门      头      沟      区");
                this.门头沟区Name.Location = new Location(40.0, 115.8);
                this.房山区Name.set_FontSize(52.0);
                this.房山区Name.set_Content("房            山            区");
                this.房山区Name.Location = new Location(39.74786, 115.83);
                this.通州区Name.set_FontSize(52.0);
                this.通州区Name.set_Content("通        州        区");
                this.通州区Name.Location = new Location(39.791, 116.745);
                this.顺义区Name.set_FontSize(52.0);
                this.顺义区Name.set_Content("顺        义        区");
                this.顺义区Name.Location = new Location(40.16, 116.72);
                this.昌平区Name.set_FontSize(52.0);
                this.昌平区Name.set_Content("昌            平            区");
                this.昌平区Name.Location = new Location(40.22072, 116.2312);
                this.大兴区Name.set_FontSize(52.0);
                this.大兴区Name.set_Content("大          兴          区");
                this.大兴区Name.Location = new Location(39.665, 116.45);
                this.怀柔区Name.set_FontSize(52.0);
                this.怀柔区Name.set_Content("怀        柔        区");
                this.怀柔区Name.Location = new Location(40.42, 116.5);
                this.平谷区Name.set_FontSize(52.0);
                this.平谷区Name.set_Content("平      谷      区");
                this.平谷区Name.Location = new Location(40.17, 117.12133);
                this.密云县Name.set_FontSize(52.0);
                this.密云县Name.set_Content("密            云            县");
                this.密云县Name.Location = new Location(40.55, 116.97);
                this.延庆县Name.set_FontSize(52.0);
                this.延庆县Name.set_Content("延            庆            县");
                this.延庆县Name.Location = new Location(40.52, 116.1);
                num = 28.0;
                this.FloatForecastPopup.HOriginOffset = 100.0;
                this.FloatForecastPopup.VOriginOffset = 100.0;
                this.FloatAQIPopup.HOriginOffset = 100.0;
                this.FloatAQIPopup.VOriginOffset = 100.0;
                this.FloatWRWPopup.HOriginOffset = 100.0;
                this.FloatWRWPopup.VOriginOffset = 100.0;
            }
            else if (this.screenHeight >= 1024.0)
            {
                this.LineLength = 157.0;
                this.LeftFrameWidth = 400.0;
                this.ForecastTabItemWidth = 157.0;
                this.ActuallyTabItemWidth = 145.0;
                this.dgAQI.Columns[4].Width = new DataGridLength(80.0);
                this.StartZoomLevel = 9.0;
                this.EndZoomLevel = 11.0;
                this.BeijingCenter.Longitude -= 0.2;
            }
            else if (this.screenHeight >= 900.0)
            {
                this.LineLength = 157.0;
                this.LeftFrameWidth = 400.0;
                this.ForecastTabItemWidth = 157.0;
                this.ActuallyTabItemWidth = 145.0;
                this.dgAQI.Columns[4].Width = new DataGridLength(80.0);
                this.StartZoomLevel = 8.0;
                this.EndZoomLevel = 10.0;
                this.BeijingCenter.Latitude -= 0.35;
                this.BeijingCenter.Longitude += 0.8;
                this.mapScale = 1.4;
                num = 16.0;
                num2 = 9.0;
                num5 = 22.0;
                this.FloatForecastPopup.HOriginOffset = 80.0;
                this.FloatForecastPopup.VOriginOffset = 80.0;
                this.FloatAQIPopup.HOriginOffset = 80.0;
                this.FloatAQIPopup.VOriginOffset = 80.0;
                this.FloatWRWPopup.HOriginOffset = 80.0;
                this.FloatWRWPopup.VOriginOffset = 80.0;
            }
            else if (this.screenHeight >= 768.0)
            {
                this.LineLength = 157.0;
                this.LeftFrameWidth = 400.0;
                this.ForecastTabItemWidth = 157.0;
                this.ActuallyTabItemWidth = 145.0;
                this.dgAQI.Columns[4].Width = new DataGridLength(80.0);
                this.StartZoomLevel = 8.0;
                this.EndZoomLevel = 10.0;
                this.BeijingCenter.Latitude += 0.02;
                if (this.screenWidth >= 1366.0)
                {
                    this.BeijingCenter.Longitude -= 0.3;
                }
                else
                {
                    this.BeijingCenter.Longitude -= 0.6;
                }
                this.mapScale = 1.0;
                num = 16.0;
                this.FloatForecastPopup.HOriginOffset = 80.0;
                this.FloatForecastPopup.VOriginOffset = 80.0;
                this.FloatAQIPopup.HOriginOffset = 80.0;
                this.FloatAQIPopup.VOriginOffset = 80.0;
                this.FloatWRWPopup.HOriginOffset = 80.0;
                this.FloatWRWPopup.VOriginOffset = 80.0;
            }
            else if (this.screenHeight >= 600.0)
            {
                this.StartZoomLevel = 8.0;
                this.EndZoomLevel = 10.0;
                this.mapScale = 1.0;
            }
            this.Line1.set_Width(this.LineLength);
            this.Line2.set_Width(this.LineLength);
            this.Line3.set_Width(this.LineLength);
            this.Line4.set_Width(this.LineLength);
            this.ExpandButtonGrid.set_Width(this.LeftFrameWidth);
            this.LeftFrame.set_Width(this.LeftFrameWidth);
            this.ForecaseLeftTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.ForecaseRightTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.ActuallyLeftTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.ActuallyRightTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.QualityLeftTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.QualityRightTabItem.set_Width(new GridLength(this.ForecastTabItemWidth));
            this.AQITabItemGrid.set_Width(this.ActuallyTabItemWidth + 1.0);
            this.WRWTabItemGrid.set_Width(this.ActuallyTabItemWidth);
            if ((Application.get_Current() as App).bLocalMapImage)
            {
                this.epbMapTileLayer.TileSources.Add(new LocalTiandituTileSource());
            }
            else
            {
                this.epbMapTileLayer.TileSources.Add(new TiandituTileSource());
            }
            ScaleTransform transform = new ScaleTransform();
            transform.set_ScaleX(this.mapScale);
            transform.set_ScaleY(this.mapScale);
            this.map.set_RenderTransform(transform);
            this.map.ViewChangeEnd += new EventHandler<MapEventArgs>(this.map_ViewChangeEnd);
            this.bsMapMode = new BSMapMode(new Range<double>(this.StartZoomLevel, this.EndZoomLevel));
            this.map.Mode = this.bsMapMode;
            this.bsMapMode.mapScale = this.mapScale;
            this.bsMapMode.LeftFrameWidth = this.LeftFrameWidth;
            this.bsMapMode.BeijingEast = this.BeijingEast;
            this.bsMapMode.BeijingSouth = this.BeijingSouth;
            this.bsMapMode.BeijingNorth = this.BeijingNorth;
            this.bsMapMode.BeijingWest = this.BeijingWest;
            this.bsMapMode.HomeLevel = this.StartZoomLevel;
            this.bsMapMode.HomeCenter = this.BeijingCenter;
            this.bsMapMode.airDataContext = this.airDataContext;
            this.bsMapMode.airDataContext.ZoomLevel = this.bsMapMode.ZoomLevel;
            this.bsMapMode.ZoomHome(false);
            this.NavigationCtrl.bsMapMode = this.bsMapMode;
            this.NavigationCtrl.ZoomMinLevel = this.StartZoomLevel;
            this.NavigationCtrl.ZoomMaxLevel = this.EndZoomLevel;
            this.NavigationCtrl.ZoomLevel = this.bsMapMode.airDataContext.ZoomLevel;
            DistrictsNameVisibilityConverter converter = base.get_Resources().get_Item("DistrictsNameVisibilityConverter") as DistrictsNameVisibilityConverter;
            converter.bsMapMode = this.bsMapMode;
            this.NorthEastText.set_FontSize(num);
            this.NorthWestText.set_FontSize(num);
            this.CityCenterText.set_FontSize(num);
            this.SouthEastText.set_FontSize(num);
            this.SouthWestText.set_FontSize(num);
            foreach (StationData data in (Application.get_Current() as App).StationsList)
            {
                StationPushpin pushpin = new StationPushpin();
                pushpin.set_Name(data.Station);
                pushpin.set_Content(data.Station);
                pushpin.Location = new Location(data.Lat, data.Lon);
                pushpin.PositionOrigin = PositionOrigin.Center;
                pushpin.Diameter = num3 / this.mapScale;
                pushpin.FocusedDiameter = num4 / this.mapScale;
                pushpin.set_FontSize(num2);
                pushpin.ContentMargin = new Thickness(pushpin.ContentMargin.get_Left(), pushpin.ContentMargin.get_Top() / this.mapScale, pushpin.ContentMargin.get_Right(), pushpin.ContentMargin.get_Bottom());
                pushpin.NoDataImageBrush = base.get_Resources().get_Item("NoDataImageBrush") as ImageBrush;
                pushpin.add_MouseLeftButtonUp(new MouseButtonEventHandler(this, (IntPtr) this.MapStation_MouseLeftButtonUp));
                PathToolTip tip = new PathToolTip();
                tip.set_Content(data);
                tip.set_ContentTemplate(base.get_Resources().get_Item("StationToolTipContentTemplate") as DataTemplate);
                tip.MapScale = this.mapScale;
                tip.set_VerticalOffset(num5);
                ToolTipService.SetToolTip(pushpin, tip);
                this.MapStations.get_Children().Add(pushpin);
            }
            this.DoubleClickTimer = new DispatcherTimer();
            this.DoubleClickTimer.set_Interval(new TimeSpan(0, 0, 0, 0, 300));
            this.DoubleClickTimer.add_Tick(new EventHandler(this.DoubleClickTimer_Tick));
            base.add_MouseLeftButtonDown(new MouseButtonEventHandler(this, (IntPtr) this.MainPage_MouseLeftButtonDown));
            this.dgAQI.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this, (IntPtr) this.DataGrid_MouseLeftButtonDown), true);
            this.dgWRW.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this, (IntPtr) this.DataGrid_MouseLeftButtonDown), true);
            List<AQILevel> list2 = new List<AQILevel> {
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[1], "0-50", "一级", "优", "空气质量令人满意，基本无空气污染", "各类人群可正常活动"),
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[2], "51-100", "二级", "良", "空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响", "极少数异常敏感人群应减少户外活动"),
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[3], "101-150", "三级", "轻度污染", "易感人群症状有轻度加剧，健康人群出现刺激症状", "儿童、老年人及心脏病、呼吸系统疾病患者应减少长时间、高强度的户外锻炼"),
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[4], "151-200", "四级", "中度污染", "进一步加剧易感人群症状，可能对健康人群心脏、呼吸系统有影响", "儿童、老年人及心脏病、呼吸系统疾病患者避免长时间、高强度的户外锻炼，一般人群适量减少户外活动"),
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[5], "201-300", "五级", "重度污染", "心脏病和肺病患者症状显著加剧，运动耐受力降低，健康人群普遍出现症状", "儿童、老年人和心脏病、肺病患者应停留在室内，停止户外活动，一般人群减少户外活动"),
                new AQILevel((Application.get_Current() as App).AQILevelColorsList[6], ">300", "六级", "严重污染", "健康人群运动耐受力降低，有明显强烈症状，提前出现某些症状", "儿童、老年人和病人应该留在室内，避免体力消耗，一般人群应避免户外活动")
            };
            this.dgAQIDetailText.ItemsSource = list2;
            this.wrwtlRect1.set_Fill((Application.get_Current() as App).AQILevelColorsList[1]);
            this.wrwtlRect2.set_Fill((Application.get_Current() as App).AQILevelColorsList[2]);
            this.wrwtlRect3.set_Fill((Application.get_Current() as App).AQILevelColorsList[3]);
            this.wrwtlRect4.set_Fill((Application.get_Current() as App).AQILevelColorsList[4]);
            this.wrwtlRect5.set_Fill((Application.get_Current() as App).AQILevelColorsList[5]);
            this.wrwtlRect6.set_Fill((Application.get_Current() as App).AQILevelColorsList[6]);
            this.aqiEllipse1.set_Fill((Application.get_Current() as App).AQILevelColorsList[1]);
            this.aqiEllipse2.set_Fill((Application.get_Current() as App).AQILevelColorsList[2]);
            this.aqiEllipse3.set_Fill((Application.get_Current() as App).AQILevelColorsList[3]);
            this.aqiEllipse4.set_Fill((Application.get_Current() as App).AQILevelColorsList[4]);
            this.aqiEllipse5.set_Fill((Application.get_Current() as App).AQILevelColorsList[5]);
            this.aqiEllipse6.set_Fill((Application.get_Current() as App).AQILevelColorsList[6]);
            App app = Application.get_Current() as App;
            app.MapRange = this.MapRange;
            this.map.Focus();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.FloatForecastPopup.IsOpen)
            {
                this.FloatForecastPopup.IsOpen = false;
            }
            if (this.FloatAQIPopup.IsOpen)
            {
                this.FloatAQIPopup.IsOpen = false;
            }
            if (this.FloatWRWPopup.IsOpen)
            {
                this.FloatWRWPopup.IsOpen = false;
            }
        }

        private void wrw_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            if (button != null)
            {
                string str;
                if ((!string.IsNullOrEmpty(this.CurrentWRWName) && (this.CurrentWRWName != button.get_Tag().ToString())) && ((str = this.CurrentWRWName) != null))
                {
                    if (!(str == "PM2.5"))
                    {
                        if (str == "SO2")
                        {
                            this.wrw_so2.set_Background(base.get_Resources().get_Item("SO2ImageBrush") as ImageBrush);
                        }
                        else if (str == "NO2")
                        {
                            this.wrw_no2.set_Background(base.get_Resources().get_Item("NO2ImageBrush") as ImageBrush);
                        }
                        else if (str == "O3")
                        {
                            this.wrw_o31.set_Background(base.get_Resources().get_Item("O31ImageBrush") as ImageBrush);
                        }
                        else if (str == "CO")
                        {
                            this.wrw_co.set_Background(base.get_Resources().get_Item("COImageBrush") as ImageBrush);
                        }
                        else if (str == "PM10")
                        {
                            this.wrw_pm10.set_Background(base.get_Resources().get_Item("PM10ImageBrush") as ImageBrush);
                        }
                    }
                    else
                    {
                        this.wrw_pm25.set_Background(base.get_Resources().get_Item("PM25ImageBrush") as ImageBrush);
                    }
                }
                this.CurrentWRWName = button.get_Tag().ToString();
                IEnumerable itemsSource = this.dgWRW.ItemsSource;
                foreach (StationData data in (Application.get_Current() as App).StationsList)
                {
                    data.CopyWRWData(this.CurrentWRWName);
                    StationPushpin station = this.GetStation(data.Station);
                    if (station != null)
                    {
                        station.DataVisibility = data.WRWDataVisibility;
                        if (station.DataVisibility == null)
                        {
                            station.set_Background(data.WRWBackColor);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(this.CurrentWRWName))
                {
                    new BitmapImage();
                    string currentWRWName = this.CurrentWRWName;
                    if (currentWRWName != null)
                    {
                        if (!(currentWRWName == "PM2.5"))
                        {
                            if (currentWRWName == "SO2")
                            {
                                this.wrwtlTitle.set_Text("SO2 浓度示意图例（微克/立方米）");
                                this.wrwtlData.set_Text("0      150       500      650      800     1600");
                                this.dgWRW.Columns[1].Header = "SO2 浓度（微克/立方米）";
                            }
                            else if (currentWRWName == "NO2")
                            {
                                this.wrwtlTitle.set_Text("NO2 浓度示意图例（微克/立方米）");
                                this.wrwtlData.set_Text("0      100       200      700    1200     2340");
                                this.dgWRW.Columns[1].Header = "NO2 浓度（微克/立方米）";
                            }
                            else if (currentWRWName == "O3")
                            {
                                this.wrwtlTitle.set_Text("O3 浓度示意图例（微克/立方米）");
                                this.wrwtlData.set_Text("0      160       200      300      400      800");
                                this.dgWRW.Columns[1].Header = "O3 浓度（微克/立方米）";
                            }
                            else if (currentWRWName == "CO")
                            {
                                this.wrwtlTitle.set_Text("CO 浓度示意图例（毫克/立方米）");
                                this.wrwtlData.set_Text("0         5         10        35        60        90");
                                this.dgWRW.Columns[1].Header = "CO 浓度（毫克/立方米）";
                            }
                            else if (currentWRWName == "PM10")
                            {
                                this.wrwtlTitle.set_Text("PM10 浓度示意图例（微克/立方米）");
                                this.wrwtlData.set_Text("0        50       150      250      350      420");
                                this.dgWRW.Columns[1].Header = "PM10 浓度（微克/立方米）";
                            }
                        }
                        else
                        {
                            this.wrwtlTitle.set_Text("PM2.5 浓度示意图例（微克/立方米）");
                            this.wrwtlData.set_Text("0        35        75       115      150      250");
                            this.dgWRW.Columns[1].Header = "PM2.5 浓度(微克/立方米)";
                        }
                    }
                }
                if (this.LastStation != null)
                {
                    this.LastStation.IsFocused = false;
                }
            }
        }

        private void wrw_MouseEnter(object sender, MouseEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            if ((button != null) && (string.IsNullOrEmpty(this.CurrentWRWName) || (this.CurrentWRWName != button.get_Tag().ToString())))
            {
                ImageBrush brush = null;
                string str = button.get_Name();
                if (str != null)
                {
                    if (!(str == "wrw_pm25"))
                    {
                        if (str == "wrw_pm10")
                        {
                            brush = base.get_Resources().get_Item("PM10_ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_so2")
                        {
                            brush = base.get_Resources().get_Item("SO2_ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_no2")
                        {
                            brush = base.get_Resources().get_Item("NO2_ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_o31")
                        {
                            brush = base.get_Resources().get_Item("O31_ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_co")
                        {
                            brush = base.get_Resources().get_Item("CO_ImageBrush") as ImageBrush;
                        }
                    }
                    else
                    {
                        brush = base.get_Resources().get_Item("PM25_ImageBrush") as ImageBrush;
                    }
                }
                button.set_Background(brush);
            }
        }

        private void wrw_MouseLeave(object sender, MouseEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            if ((button != null) && (string.IsNullOrEmpty(this.CurrentWRWName) || (this.CurrentWRWName != button.get_Tag().ToString())))
            {
                ImageBrush brush = null;
                string str = button.get_Name();
                if (str != null)
                {
                    if (!(str == "wrw_pm25"))
                    {
                        if (str == "wrw_pm10")
                        {
                            brush = base.get_Resources().get_Item("PM10ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_so2")
                        {
                            brush = base.get_Resources().get_Item("SO2ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_no2")
                        {
                            brush = base.get_Resources().get_Item("NO2ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_o31")
                        {
                            brush = base.get_Resources().get_Item("O31ImageBrush") as ImageBrush;
                        }
                        else if (str == "wrw_co")
                        {
                            brush = base.get_Resources().get_Item("COImageBrush") as ImageBrush;
                        }
                    }
                    else
                    {
                        brush = base.get_Resources().get_Item("PM25ImageBrush") as ImageBrush;
                    }
                }
                button.set_Background(brush);
            }
        }

        private void WRWExpand_Click(object sender, RoutedEventArgs e)
        {
            double targetWidth = 419.0;
            double wRWPopupHeight = this.GetWRWPopupHeight();
            this.FloatWRWPopup.Expand(targetWidth, wRWPopupHeight);
        }

        private void WRWPopupExpand_Completed(object sender, EventArgs e)
        {
            bool valueOrDefault = this.btnWRWExpand.get_IsChecked().GetValueOrDefault();
            if (this.btnWRWExpand.get_IsChecked().HasValue)
            {
                switch (valueOrDefault)
                {
                    case false:
                        this.btnWRWExpand.set_Background(base.get_Resources().get_Item("ExpandImageBrush") as ImageBrush);
                        break;

                    case true:
                        this.btnWRWExpand.set_Background(base.get_Resources().get_Item("CollapsedImageBrush") as ImageBrush);
                        return;

                    default:
                        return;
                }
            }
        }

        private void WRWPopupStoryboard_Completed(object sender, EventArgs e)
        {
            StationData selectedItem = this.dgWRW.SelectedItem as StationData;
            if (selectedItem != null)
            {
                string station = selectedItem.Station;
                string shortName = selectedItem.ShortName;
            }
            WRWData wrwData = this.FloatWRWPopup.get_DataContext() as WRWData;
            this.BuildChartData(wrwData);
        }
    }
}

