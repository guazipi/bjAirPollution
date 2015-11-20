namespace BEPB
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;

    public class WRWData
    {
        private string _FaceSign;
        private string _Pollutant;
        private string _Quality;
        private string _RealTimeQL;
        private string _Value;

        public WRWData()
        {
            this.MaxValue = 0.0;
            this.Value = "--";
            this.IAQI = "--";
            this.QLevel = "--";
            this.Quality = "--";
            this.AVG24h = "--";
            this.DataVisibility = 1;
            this.QualityFace = BEPB.QualityFace.NoData;
            this.WRWPrompt = "数据未经审核，仅供参考";
            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[0];
            this.FontColor = new SolidColorBrush(Colors.get_White());
            this.Data24hList = new Dictionary<int, KeyValuePair<DateTime, float?>>();
        }

        public string AVG24h { get; set; }

        public SolidColorBrush BackColor { get; set; }

        public string CotUnit { get; set; }

        public Dictionary<int, KeyValuePair<DateTime, float?>> Data24hList { get; set; }

        public Visibility DataVisibility { get; set; }

        public string FaceSign
        {
            get
            {
                return this._FaceSign;
            }
            set
            {
                this._FaceSign = value;
                string str = this._FaceSign;
                if (str != null)
                {
                    if (!(str == "1"))
                    {
                        if (!(str == "2"))
                        {
                            if (str == "3")
                            {
                                this.QualityFace = BEPB.QualityFace.Sad;
                            }
                            return;
                        }
                    }
                    else
                    {
                        this.QualityFace = BEPB.QualityFace.Happy;
                        return;
                    }
                    this.QualityFace = BEPB.QualityFace.Normal;
                }
            }
        }

        public SolidColorBrush FontColor { get; set; }

        public string Group { get; set; }

        public string IAQI { get; set; }

        public double MaxValue { get; set; }

        public string Pollutant
        {
            get
            {
                return this._Pollutant;
            }
            set
            {
                this._Pollutant = value;
                string str = this._Pollutant;
                if (str != null)
                {
                    if (!(str == "PM2.5"))
                    {
                        if (!(str == "SO2"))
                        {
                            if (!(str == "NO2"))
                            {
                                if (!(str == "O3"))
                                {
                                    if (!(str == "CO"))
                                    {
                                        if (str == "PM10")
                                        {
                                            this.CotUnit = "微克/立方米";
                                        }
                                        return;
                                    }
                                    this.CotUnit = "毫克/立方米";
                                    return;
                                }
                                this.CotUnit = "微克/立方米";
                                return;
                            }
                            this.CotUnit = "微克/立方米";
                            return;
                        }
                    }
                    else
                    {
                        this.CotUnit = "微克/立方米";
                        return;
                    }
                    this.CotUnit = "微克/立方米";
                }
            }
        }

        public string QLevel { get; set; }

        public string Quality
        {
            get
            {
                return this._Quality;
            }
            set
            {
                this._Quality = value;
            }
        }

        public BEPB.QualityFace QualityFace { get; set; }

        public string RealTimeQL
        {
            get
            {
                return this._RealTimeQL;
            }
            set
            {
                this._RealTimeQL = value;
                string str = this._RealTimeQL;
                if (str != null)
                {
                    if (!(str == "一级"))
                    {
                        if (!(str == "二级"))
                        {
                            if (!(str == "三级"))
                            {
                                if (!(str == "四级"))
                                {
                                    if (!(str == "五级"))
                                    {
                                        if (str == "六级")
                                        {
                                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[6];
                                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                                        }
                                        return;
                                    }
                                    this.BackColor = (Application.get_Current() as App).AQILevelColorsList[5];
                                    this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                                    return;
                                }
                                this.BackColor = (Application.get_Current() as App).AQILevelColorsList[4];
                                this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                                return;
                            }
                            this.BackColor = (Application.get_Current() as App).AQILevelColorsList[3];
                            this.FontColor = new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xea, 0xe1));
                            return;
                        }
                    }
                    else
                    {
                        this.BackColor = (Application.get_Current() as App).AQILevelColorsList[1];
                        this.FontColor = new SolidColorBrush(Colors.get_Black());
                        return;
                    }
                    this.BackColor = (Application.get_Current() as App).AQILevelColorsList[2];
                    this.FontColor = new SolidColorBrush(Colors.get_Black());
                }
            }
        }

        public string ShortName { get; set; }

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }

        public string WRWPrompt { get; set; }
    }
}

