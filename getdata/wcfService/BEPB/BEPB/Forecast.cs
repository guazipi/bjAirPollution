namespace BEPB
{
    using BEPB.DataServiceReference;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media;

    public class Forecast : INotifyPropertyChanged
    {
        private string _Day;
        private SolidColorBrush _Day_FontColor;
        private string _Night;
        private SolidColorBrush _Night_FontColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public Forecast()
        {
            this.IsNight = "0";
            this.Night = "--  --";
            this.Day = "--  --";
            this.Night_FontColor = new SolidColorBrush(Colors.get_White());
            this.Day_FontColor = new SolidColorBrush(Colors.get_White());
            this.Night_FontSize = 19.0;
            this.Day_FontSize = 19.0;
        }

        public Forecast(string Zone, string Night, string Day)
        {
            this.IsNight = "0";
            this.Zone = Zone;
            this.Night = Night;
            this.Day = Day;
            this.Night_FontColor = new SolidColorBrush(Colors.get_White());
            this.Day_FontColor = new SolidColorBrush(Colors.get_White());
            this.Night_FontSize = 19.0;
            this.Day_FontSize = 19.0;
            this.Night_PriPollutantTextMargin = new Thickness(0.0, 30.0, 0.0, 0.0);
            this.Day_PriPollutantTextMargin = new Thickness(0.0, 30.0, 0.0, 0.0);
            this.Night_CharacterSpacing = 0.0;
            this.Day_CharacterSpacing = 0.0;
        }

        public void SetData(TB_Message forecast)
        {
        }

        public void SetData(PredictData forecast)
        {
            this.Zone = forecast.Zone;
            if (forecast.Date_Time.Hour != 20)
            {
                if (forecast.Date_Time.Hour != 8)
                {
                    return;
                }
                string priPollutant = forecast.PriPollutant;
                if (priPollutant != null)
                {
                    if (!(priPollutant == "PM2.5"))
                    {
                        if (priPollutant == "SO2")
                        {
                            this.Day_PriPollutant = "二氧化硫";
                        }
                        else if (priPollutant == "NO2")
                        {
                            this.Day_PriPollutant = "二氧化氮";
                        }
                        else if (priPollutant == "O3")
                        {
                            this.Day_PriPollutant = "臭氧";
                        }
                        else if (priPollutant == "CO")
                        {
                            this.Day_PriPollutant = "一氧化碳";
                        }
                        else if (priPollutant == "PM10")
                        {
                            this.Day_PriPollutant = "可吸入颗粒物";
                            this.Day_FontSize = 19.0;
                            this.Day_PriPollutantTextMargin = new Thickness(15.0, 15.0, 15.0, 0.0);
                            this.Day_CharacterSpacing = 200.0;
                        }
                    }
                    else
                    {
                        this.Day_PriPollutant = "细颗粒物";
                    }
                }
            }
            else
            {
                this.IsNight = "1";
                string str = forecast.PriPollutant;
                if (str != null)
                {
                    if (!(str == "PM2.5"))
                    {
                        if (str == "SO2")
                        {
                            this.Night_PriPollutant = "二氧化硫";
                        }
                        else if (str == "NO2")
                        {
                            this.Night_PriPollutant = "二氧化氮";
                        }
                        else if (str == "O3")
                        {
                            this.Night_PriPollutant = "臭氧";
                        }
                        else if (str == "CO")
                        {
                            this.Night_PriPollutant = "一氧化碳";
                        }
                        else if (str == "PM10")
                        {
                            this.Night_PriPollutant = "可吸入颗粒物";
                            this.Night_FontSize = 19.0;
                            this.Night_PriPollutantTextMargin = new Thickness(15.0, 15.0, 15.0, 0.0);
                            this.Night_CharacterSpacing = 200.0;
                        }
                    }
                    else
                    {
                        this.Night_PriPollutant = "细颗粒物";
                    }
                }
                this.Night_AQI = forecast.AQI;
                this.Night_QLevel = forecast.QLevel;
                this.Night_Quality = forecast.Quality;
                this.Night_Description = forecast.Description;
                this.Night_Date_Time = forecast.Date_Time;
                string str2 = this.Night_Quality;
                if (str2 != null)
                {
                    if (!(str2 == "优"))
                    {
                        if (str2 == "良")
                        {
                            this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[2];
                            this.Night_FontColor = new SolidColorBrush(Colors.get_Black());
                        }
                        else if (str2 == "轻度污染")
                        {
                            this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[3];
                        }
                        else if (str2 == "中度污染")
                        {
                            this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[4];
                        }
                        else if (str2 == "重度污染")
                        {
                            this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[5];
                        }
                        else if (str2 == "严重污染")
                        {
                            this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[6];
                        }
                    }
                    else
                    {
                        this.Night_BackColor = (Application.get_Current() as App).AQILevelColorsList[1];
                        this.Night_FontColor = new SolidColorBrush(Colors.get_Black());
                        this.Night_PriPollutant = "--";
                    }
                }
                this.Night = this.Night_PriPollutant + "  " + this.Night_AQI;
                return;
            }
            this.Day_AQI = forecast.AQI;
            this.Day_QLevel = forecast.QLevel;
            this.Day_Quality = forecast.Quality;
            this.Day_Description = forecast.Description;
            this.Day_Date_Time = forecast.Date_Time;
            string str4 = this.Day_Quality;
            if (str4 != null)
            {
                if (!(str4 == "优"))
                {
                    if (str4 == "良")
                    {
                        this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[2];
                        this.Day_FontColor = new SolidColorBrush(Colors.get_Black());
                    }
                    else if (str4 == "轻度污染")
                    {
                        this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[3];
                    }
                    else if (str4 == "中度污染")
                    {
                        this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[4];
                    }
                    else if (str4 == "重度污染")
                    {
                        this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[5];
                    }
                    else if (str4 == "严重污染")
                    {
                        this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[6];
                    }
                }
                else
                {
                    this.Day_BackColor = (Application.get_Current() as App).AQILevelColorsList[1];
                    this.Day_FontColor = new SolidColorBrush(Colors.get_Black());
                    this.Day_PriPollutant = "--";
                }
            }
            this.Day = this.Day_PriPollutant + "  " + this.Day_AQI;
        }

        public string Day
        {
            get
            {
                return this._Day;
            }
            set
            {
                this._Day = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Day"));
                }
            }
        }

        public string Day_AQI { get; set; }

        public SolidColorBrush Day_BackColor { get; set; }

        public double Day_CharacterSpacing { get; set; }

        public DateTime Day_Date_Time { get; set; }

        public string Day_Description { get; set; }

        public SolidColorBrush Day_FontColor
        {
            get
            {
                return this._Day_FontColor;
            }
            set
            {
                this._Day_FontColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Day_FontColor"));
                }
            }
        }

        public double Day_FontSize { get; set; }

        public string Day_PriPollutant { get; set; }

        public Thickness Day_PriPollutantTextMargin { get; set; }

        public string Day_QLevel { get; set; }

        public string Day_Quality { get; set; }

        public string IsNight { get; set; }

        public string Night
        {
            get
            {
                return this._Night;
            }
            set
            {
                this._Night = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Night"));
                }
            }
        }

        public string Night_AQI { get; set; }

        public SolidColorBrush Night_BackColor { get; set; }

        public double Night_CharacterSpacing { get; set; }

        public DateTime Night_Date_Time { get; set; }

        public string Night_Description { get; set; }

        public SolidColorBrush Night_FontColor
        {
            get
            {
                return this._Night_FontColor;
            }
            set
            {
                this._Night_FontColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Night_FontColor"));
                }
            }
        }

        public double Night_FontSize { get; set; }

        public string Night_PriPollutant { get; set; }

        public Thickness Night_PriPollutantTextMargin { get; set; }

        public string Night_QLevel { get; set; }

        public string Night_Quality { get; set; }

        public string Zone { get; set; }
    }
}

