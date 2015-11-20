namespace BEPB
{
    using BEPB.DataServiceReference;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media;

    public class StationData : INotifyPropertyChanged
    {
        private string _AirDataType;
        private string _AQI;
        private Visibility _AQIDataVisibility;
        private SolidColorBrush _BackColor;
        private SolidColorBrush _FontColor;
        private string _Group;
        private string _PriPollutant;
        private string _Prompt;
        private string _QLevel;
        private string _Quality;
        private string _RealTimeQL;
        private string _ShortName;
        private SolidColorBrush _WRWBackColor;
        private string _WRWCotUnit;
        private Visibility _WRWDataVisibility;
        private string _WRWValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public StationData()
        {
            this.Station = "--";
            this.ShortName = "--";
            this.Group = "--";
            this.District = "--";
            this.Lat = 0.0;
            this.Lon = 0.0;
            this.Area = "--";
            this.Zone = "--";
            this.AQI = "--";
            this.PriPollutant = "--";
            this.QLevel = "--";
            this.RealTimeQL = "--";
            this.Quality = "--";
            this.AirDataType = "--";
            this.Prompt = "--";
            this.Date_Time = "--";
            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[0];
            this.FontColor = new SolidColorBrush(Colors.get_White());
            this.WRWValue = "--";
            this.WRWCotUnit = "--";
            this.WRWBackColor = (Application.get_Current() as App).AQILevelColorsList[0];
            this.WRWDataVisibility = 1;
            this.AQIDataVisibility = 1;
            this.NoDataPrompt = "遇校准、维护、仪器故障、通讯中断、停电等情况，会发生短时数据缺测现象";
            this.IAQIDataList = new List<IAQIData>();
            IAQIData item = new IAQIData {
                Pollutant = "PM2.5\t  - 24 小时"
            };
            this.IAQIDataList.Add(item);
            item = new IAQIData {
                Pollutant = "PM10\t  - 24 小时"
            };
            this.IAQIDataList.Add(item);
            item = new IAQIData {
                Pollutant = "SO2\t  -  1  小时"
            };
            this.IAQIDataList.Add(item);
            item = new IAQIData {
                Pollutant = "NO2\t  -  1  小时"
            };
            this.IAQIDataList.Add(item);
            item = new IAQIData {
                Pollutant = "O3\t\t  -  1  小时"
            };
            this.IAQIDataList.Add(item);
            item = new IAQIData {
                Pollutant = "CO\t\t  -  1  小时"
            };
            this.IAQIDataList.Add(item);
            this.WRWDataList = new List<WRWData>();
            WRWData data2 = new WRWData {
                Pollutant = "PM2.5"
            };
            this.WRWDataList.Add(data2);
            data2 = new WRWData {
                Pollutant = "SO2"
            };
            this.WRWDataList.Add(data2);
            data2 = new WRWData {
                Pollutant = "NO2"
            };
            this.WRWDataList.Add(data2);
            data2 = new WRWData {
                Pollutant = "O3"
            };
            this.WRWDataList.Add(data2);
            data2 = new WRWData {
                Pollutant = "CO"
            };
            this.WRWDataList.Add(data2);
            data2 = new WRWData {
                Pollutant = "PM10"
            };
            this.WRWDataList.Add(data2);
        }

        public float? ConvertToFloat(string param)
        {
            if (!string.IsNullOrEmpty(param) && !(param == "-9999"))
            {
                return new float?(Convert.ToSingle(param));
            }
            return null;
        }

        public void CopyWRWData(string WRWName)
        {
            WRWData data = this.WRWDataList.SingleOrDefault<WRWData>(x => x.Pollutant == WRWName);
            if (data != null)
            {
                this.WRWDataVisibility = data.DataVisibility;
                this.WRWBackColor = data.BackColor;
                this.WRWValue = data.Value;
                this.WRWCotUnit = data.CotUnit;
            }
        }

        public void SetData(TB_RTC data)
        {
        }

        public void SetData(RTCData rtcData)
        {
            double result = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            string iAQI = "--";
            if ((double.TryParse(rtcData.IAQI, out result) && (-9000.0 <= result)) && (result <= 9000.0))
            {
                iAQI = rtcData.IAQI;
            }
            string aQI = "--";
            if ((double.TryParse(rtcData.AQI, out num2) && (-9000.0 <= num2)) && (num2 <= 9000.0))
            {
                aQI = rtcData.AQI;
            }
            string str3 = "--";
            if ((double.TryParse(rtcData.Avg24h, out num3) && (-9000.0 <= num3)) && (num3 <= 9000.0))
            {
                str3 = rtcData.Avg24h;
            }
            if (!string.IsNullOrEmpty(rtcData.Pollutant) && (iAQI != "--"))
            {
                this.AQIDataVisibility = 0;
            }
            this.Date_Time = rtcData.Date_Time.ToString("f");
            if (rtcData.Pollutant == rtcData.PriPollutant.Split(new char[] { ',' })[0])
            {
                if (rtcData.Quality == "优")
                {
                    this.PriPollutant = "--";
                }
                else
                {
                    this.PriPollutant = rtcData.Pollutant;
                }
                this.AQI = aQI;
                this.QLevel = string.IsNullOrEmpty(rtcData.QLevel) ? "--" : rtcData.QLevel;
                this.Quality = string.IsNullOrEmpty(rtcData.Quality) ? "--" : rtcData.Quality;
            }
            IAQIData data = null;
            string pollutant = rtcData.Pollutant;
            if (pollutant != null)
            {
                if (!(pollutant == "PM2.5"))
                {
                    if (pollutant == "PM10")
                    {
                        data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "PM10\t  - 24 小时");
                    }
                    else if (pollutant == "SO2")
                    {
                        data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "SO2\t  -  1  小时");
                    }
                    else if (pollutant == "NO2")
                    {
                        data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "NO2\t  -  1  小时");
                    }
                    else if (pollutant == "O3")
                    {
                        data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "O3\t\t  -  1  小时");
                    }
                    else if (pollutant == "CO")
                    {
                        data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "CO\t\t  -  1  小时");
                    }
                }
                else
                {
                    data = this.IAQIDataList.SingleOrDefault<IAQIData>(x => x.Pollutant == "PM2.5\t  - 24 小时");
                }
            }
            if (data != null)
            {
                data.IAQI = iAQI;
                data.Quality = string.IsNullOrEmpty(rtcData.Quality) ? "--" : rtcData.Quality;
            }
            WRWData data2 = this.WRWDataList.SingleOrDefault<WRWData>(x => x.Pollutant == rtcData.Pollutant);
            if (data2 != null)
            {
                data2.RealTimeQL = rtcData.RealTimeQL;
                data2.FaceSign = rtcData.FaceSign;
                if ((data2.Pollutant == "CO") || (str3 == "--"))
                {
                    data2.AVG24h = str3;
                }
                else
                {
                    int num4 = (int) num3;
                    if ((num3 - num4) >= 0.5)
                    {
                        num4++;
                    }
                    data2.AVG24h = num4.ToString();
                }
                data2.IAQI = iAQI;
                data2.QLevel = string.IsNullOrEmpty(rtcData.QLevel) ? "--" : rtcData.QLevel;
                data2.Quality = string.IsNullOrEmpty(rtcData.Quality) ? "--" : rtcData.Quality;
                string[] source = rtcData.Over24h.Split(new char[] { ',' });
                if (source.Count<string>() > 0)
                {
                    DateTime time;
                    double num5 = 0.0;
                    if ((double.TryParse(source[source.Count<string>() - 1], out num5) && (-9000.0 <= num5)) && (num5 <= 9000.0))
                    {
                        data2.DataVisibility = 0;
                        int num6 = 0;
                        if (data2.Pollutant == "CO")
                        {
                            num6 = (int) (num5 * 10.0);
                            if (((num5 * 10.0) - num6) >= 0.5)
                            {
                                num6++;
                            }
                            data2.Value = (((double) num6) / 10.0).ToString();
                        }
                        else
                        {
                            num6 = (int) num5;
                            if ((num5 - num6) >= 0.5)
                            {
                                num6++;
                            }
                            data2.Value = num6.ToString();
                        }
                    }
                    data2.Data24hList.Clear();
                    int num7 = 0;
                    if (source.Count<string>() < 0x18)
                    {
                        num7 = 0x18 - source.Count<string>();
                        for (int j = 0; j < num7; j++)
                        {
                            time = DateTime.Now.AddHours((double) (-1 * (0x17 - j)));
                            DateTime key = new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0);
                            float? nullable2 = null;
                            data2.Data24hList.Add(j, new KeyValuePair<DateTime, float?>(key, nullable2));
                        }
                    }
                    for (int i = 0; i < source.Count<string>(); i++)
                    {
                        float? nullable = null;
                        if ((double.TryParse(source[i], out num5) && (-9000.0 <= num5)) && (num5 <= 9000.0))
                        {
                            nullable = new float?((float) num5);
                        }
                        if (nullable.HasValue)
                        {
                            double maxValue = data2.MaxValue;
                            float? nullable3 = nullable;
                            if ((maxValue < ((double) nullable3.GetValueOrDefault())) && nullable3.HasValue)
                            {
                                data2.MaxValue = (double) nullable.Value;
                            }
                        }
                        time = DateTime.Now.AddHours((double) (-1 * ((source.Count<string>() - 1) - i)));
                        DateTime time3 = new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0);
                        data2.Data24hList.Add(num7 + i, new KeyValuePair<DateTime, float?>(time3, nullable));
                    }
                }
            }
        }

        public string AirDataType
        {
            get
            {
                return this._AirDataType;
            }
            set
            {
                this._AirDataType = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AirDataType"));
                }
            }
        }

        public string AQI
        {
            get
            {
                return this._AQI;
            }
            set
            {
                this._AQI = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AQI"));
                }
            }
        }

        public Visibility AQIDataVisibility
        {
            get
            {
                return this._AQIDataVisibility;
            }
            set
            {
                this._AQIDataVisibility = value;
                if (this._AQIDataVisibility == null)
                {
                    this.NoDataPrompt = null;
                }
                else
                {
                    this.NoDataPrompt = "遇校准、维护、仪器故障、通讯中断、停电等情况，会发生短时数据缺测现象";
                }
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AQIDataVisibility"));
                }
            }
        }

        public string Area { get; set; }

        public SolidColorBrush BackColor
        {
            get
            {
                return this._BackColor;
            }
            set
            {
                this._BackColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BackColor"));
                }
            }
        }

        public string Date_Time { get; set; }

        public string District { get; set; }

        public SolidColorBrush FontColor
        {
            get
            {
                return this._FontColor;
            }
            set
            {
                this._FontColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FontColor"));
                }
            }
        }

        public string Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
                if (this.WRWDataList != null)
                {
                    foreach (WRWData data in this.WRWDataList)
                    {
                        data.Group = this._Group;
                    }
                }
            }
        }

        public List<IAQIData> IAQIDataList { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public string NoDataPrompt { get; set; }

        public string PriPollutant
        {
            get
            {
                return this._PriPollutant;
            }
            set
            {
                this._PriPollutant = value;
                string str = this._PriPollutant;
                if (str != null)
                {
                    if (!(str == "PM2.5") && !(str == "PM10"))
                    {
                        if (((str == "SO2") || (str == "NO2")) || ((str == "O3") || (str == "CO")))
                        {
                            this.AirDataType = "当前小时";
                        }
                    }
                    else
                    {
                        this.AirDataType = "过去24小时";
                    }
                }
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("PriPollutant"));
                }
            }
        }

        public string Prompt
        {
            get
            {
                return this._Prompt;
            }
            set
            {
                this._Prompt = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Prompt"));
                }
            }
        }

        public string QLevel
        {
            get
            {
                return this._QLevel;
            }
            set
            {
                this._QLevel = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("QLevel"));
                }
            }
        }

        public string Quality
        {
            get
            {
                return this._Quality;
            }
            set
            {
                this._Quality = value;
                string str = this._Quality;
                if (str != null)
                {
                    if (!(str == "优"))
                    {
                        if (str == "良")
                        {
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[2];
                            this.FontColor = new SolidColorBrush(Colors.get_Black());
                            this.Prompt = "极少数异常敏感人群应减少户外活动";
                        }
                        else if (str == "轻度污染")
                        {
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[3];
                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                            this.Prompt = "儿童、老年人及心脏病、呼吸系统疾病患者应减少长时间、高强度的户外锻炼";
                        }
                        else if (str == "中度污染")
                        {
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[4];
                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                            this.Prompt = "儿童、老年人及心脏病、呼吸系统疾病患者避免长时间、高强度的户外锻炼，一般人群适量减少户外运动";
                        }
                        else if (str == "重度污染")
                        {
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[5];
                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                            this.Prompt = "儿童、老年人和心脏病、肺病患者应停留在室内，停止户外运动，一般人群减少户外运动";
                        }
                        else if (str == "严重污染")
                        {
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[6];
                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                            this.Prompt = "儿童、老年人和病人应当留在室内，避免体力消耗，一般人群应避免户外活动";
                        }
                    }
                    else
                    {
                        this.BackColor = (Application.get_Current() as App).AQILevelColorsList[1];
                        this.FontColor = new SolidColorBrush(Colors.get_Black());
                        this.Prompt = "各类人群可正常活动";
                    }
                }
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Quality"));
                }
            }
        }

        public string RealTimeQL
        {
            get
            {
                return this._RealTimeQL;
            }
            set
            {
                this._RealTimeQL = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("RealTimeQL"));
                }
            }
        }

        public string ShortName
        {
            get
            {
                return this._ShortName;
            }
            set
            {
                this._ShortName = value;
                if (this.WRWDataList != null)
                {
                    foreach (WRWData data in this.WRWDataList)
                    {
                        data.ShortName = this._ShortName;
                    }
                }
            }
        }

        public string Station { get; set; }

        public SolidColorBrush WRWBackColor
        {
            get
            {
                return this._WRWBackColor;
            }
            set
            {
                this._WRWBackColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WRWBackColor"));
                }
            }
        }

        public string WRWCotUnit
        {
            get
            {
                return this._WRWCotUnit;
            }
            set
            {
                this._WRWCotUnit = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WRWCotUnit"));
                }
            }
        }

        public List<WRWData> WRWDataList { get; set; }

        public Visibility WRWDataVisibility
        {
            get
            {
                return this._WRWDataVisibility;
            }
            set
            {
                this._WRWDataVisibility = value;
                if (this._WRWDataVisibility == null)
                {
                    this.NoDataPrompt = null;
                }
                else
                {
                    this.NoDataPrompt = "遇校准、维护、仪器故障、通讯中断、停电等情况，会发生短时数据缺测现象";
                }
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WRWDataVisibility"));
                }
            }
        }

        public string WRWValue
        {
            get
            {
                return this._WRWValue;
            }
            set
            {
                this._WRWValue = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("WRWValue"));
                }
            }
        }

        public string Zone { get; set; }
    }
}

